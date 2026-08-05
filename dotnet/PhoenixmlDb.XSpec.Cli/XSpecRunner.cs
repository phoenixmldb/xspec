using System.Text.RegularExpressions;
using System.Xml.Linq;
using PhoenixmlDb.Xslt;

namespace PhoenixmlDb.XSpec.Cli;

/// <summary>
/// Runs a single <c>.xspec</c> suite through XSpec's own XSLT-based compiler and reports
/// what happened, without a JVM or Saxon: PhoenixmlDb.Xslt runs both the compile transform
/// and the compiled test-runner stylesheet.
/// </summary>
/// <remarks>
/// Mirrors the two-step pipeline in XSpec's own <c>bin/xspec.sh</c> (see lines ~430 and
/// ~452): compile the <c>.xspec</c> with <c>compiler/compile-xslt-tests.xsl</c> into a
/// generated stylesheet, then run that generated stylesheet by calling its
/// <c>{http://www.jenitennison.com/xslt/xspec}main</c> initial template with no source
/// document. The generated stylesheet's own <c>x:report</c> output is then parsed.
/// </remarks>
public static class XSpecRunner
{
    private const string XSpecNs = "http://www.jenitennison.com/xslt/xspec";

    // Matches a leading spec-style error code, e.g. "XTTE0505" or "XPTY0004", at the start
    // of an engine exception's Message. XsltException does not carry a structured error-code
    // property (unlike XQueryRuntimeException/XQueryException), so this is how the CLI's own
    // error handler recovers one for display (see phoenixmldb-cli/src/PhoenixmlDb.Xslt.Cli).
    private static readonly Regex ErrorCodePattern = new(@"^([A-Z]{4}\d{4}):", RegexOptions.Compiled);

    /// <summary>
    /// Compiles and runs <paramref name="xspecPath"/>, returning where the pipeline got to
    /// and, if it reached <see cref="XSpecStage.Complete"/>, the outcome of every compiled
    /// <c>x:test</c>.
    /// </summary>
    public static async Task<XSpecResult> RunAsync(string xspecPath, CancellationToken ct)
    {
        var absoluteXspecPath = Path.GetFullPath(xspecPath);
        if (!File.Exists(absoluteXspecPath))
        {
            return new XSpecResult(absoluteXspecPath, XSpecStage.Compile,
                "PHXSPEC-ENOENT", $"XSpec file not found: {absoluteXspecPath}", []);
        }

        var xspecUri = new Uri(absoluteXspecPath);

        string xspecXml;
        try
        {
            xspecXml = await File.ReadAllTextAsync(absoluteXspecPath, ct).ConfigureAwait(false);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            return new XSpecResult(absoluteXspecPath, XSpecStage.Compile, null, ex.Message, []);
        }

        // ---- Stage 1: Compile ----
        // The compiler (compiler/compile-xslt-tests.xsl, transitively including the rest of
        // src/) only exists as embedded resources until EmbeddedXSpecSource.MaterializedRoot
        // extracts it to real files — see that class for why. The compile transform runs with
        // apply-templates against the .xspec source document (bin/xspec.sh passes no -it: for
        // this step; the match="document-node()" template in compiler/base/main.xsl dispatches
        // to the named x:main template itself). x:import inside the .xspec is resolved via the
        // *source document's* base URI, which is why SetSourceDocumentUri is set to the
        // .xspec's own absolute path rather than left unset.
        string generatedStylesheet;
        try
        {
            var compilerRoot = EmbeddedXSpecSource.MaterializedRoot;
            var compilerPath = Path.Combine(compilerRoot, "compiler", "compile-xslt-tests.xsl");
            var compilerXml = await File.ReadAllTextAsync(compilerPath, ct).ConfigureAwait(false);

            var compileTransformer = new XsltTransformer();
            await compileTransformer.LoadStylesheetAsync(compilerXml, new Uri(compilerPath)).ConfigureAwait(false);
            compileTransformer.SetSourceDocumentUri(xspecUri);
            generatedStylesheet = await compileTransformer.TransformAsync(xspecXml, ct).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            var (code, message) = Describe(ex);
            return new XSpecResult(absoluteXspecPath, XSpecStage.Compile, code, message, []);
        }

        // ---- Stage 2: Run ----
        // The base-URI hazard this project exists to expose: the generated stylesheet's own
        // `xsl:import` of the stylesheet-under-test is a literal, unresolved copy of
        // x:description/@stylesheet (see compiler/xslt/main.xsl, `<xsl:attribute name="href"
        // select="@stylesheet" />`) — e.g. "identity.xsl". That import must resolve against
        // the *original* .xspec's directory, not against EmbeddedXSpecSource.MaterializedRoot
        // or any other staging location. The generated text is never written to a temp file;
        // it is loaded directly with baseUri set to the .xspec's own absolute URI, so the
        // relative "identity.xsl" resolves next to the suite where it actually lives.
        string reportXml;
        try
        {
            var runTransformer = new XsltTransformer();
            await runTransformer.LoadStylesheetAsync(generatedStylesheet, xspecUri).ConfigureAwait(false);
            runTransformer.SetInitialTemplate("main", XSpecNs);
            reportXml = await runTransformer.TransformAsync((string?)null, ct).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            var (code, message) = Describe(ex);
            return new XSpecResult(absoluteXspecPath, XSpecStage.Run, code, message, []);
        }

        // ---- Stage 3: Assess ----
        try
        {
            var tests = ParseReport(reportXml);
            return new XSpecResult(absoluteXspecPath, XSpecStage.Complete, null, null, tests);
        }
        catch (Exception ex) when (ex is System.Xml.XmlException or InvalidOperationException)
        {
            return new XSpecResult(absoluteXspecPath, XSpecStage.Assess, null, ex.Message, []);
        }
    }

    /// <summary>
    /// Walks every <c>x:test</c> in the <c>x:report</c> document. A test with an
    /// <c>@pending</c> attribute is <see cref="XSpecOutcome.Pending"/> regardless of
    /// <c>@successful</c> (XSpec still evaluates pending assertions; it just doesn't count
    /// them). Otherwise <c>@successful="true"</c> is a pass and anything else — including a
    /// missing <c>@successful</c>, which XSpec's own report consumers
    /// (src/common/parse-report.xsl's <c>x:is-passed-test</c>/<c>x:is-failed-test</c>) also
    /// treat as "not successful" — is a fail.
    /// </summary>
    private static List<XSpecTestOutcome> ParseReport(string reportXml)
    {
        XNamespace ns = XSpecNs;
        var doc = XDocument.Parse(reportXml);

        var outcomes = new List<XSpecTestOutcome>();
        foreach (var test in doc.Descendants(ns + "test"))
        {
            var outcome = test.Attribute("pending") != null
                ? XSpecOutcome.Pending
                : string.Equals(test.Attribute("successful")?.Value, "true", StringComparison.Ordinal)
                    ? XSpecOutcome.Pass
                    : XSpecOutcome.Fail;

            outcomes.Add(new XSpecTestOutcome(BuildLabel(test, ns), outcome));
        }
        return outcomes;
    }

    /// <summary>
    /// Joins every enclosing <c>x:scenario/x:label</c> (outermost first) with the test's own
    /// <c>x:label</c>, mirroring how src/reporter/junit-report.xsl builds a test case name
    /// (<c>$prefix || x:label</c>) so nested scenarios stay distinguishable.
    /// </summary>
    private static string BuildLabel(XElement test, XNamespace ns)
    {
        var parts = new List<string>();
        foreach (var scenario in test.Ancestors(ns + "scenario").Reverse())
        {
            var label = scenario.Element(ns + "label");
            if (label != null)
                parts.Add(label.Value);
        }

        var ownLabel = test.Element(ns + "label");
        if (ownLabel != null)
            parts.Add(ownLabel.Value);

        return parts.Count > 0 ? string.Join(" / ", parts) : "(unlabeled test)";
    }

    /// <summary>
    /// Recovers an <c>ErrorCode</c> from whichever engine exception type surfaced. XQuery's
    /// own exceptions already carry a structured code; <see cref="PhoenixmlDb.Xslt.Engine.XsltException"/>
    /// only embeds it as a "CODE: message" prefix.
    /// </summary>
    private static (string? Code, string Message) Describe(Exception ex) => ex switch
    {
        PhoenixmlDb.XQuery.Execution.XQueryRuntimeException qre => (qre.ErrorCode, qre.Message),
        PhoenixmlDb.XQuery.Functions.XQueryException qe => (qe.ErrorCode, qe.Message),
        PhoenixmlDb.XQuery.Parser.XQueryParseException pe => (null, pe.Message),
        PhoenixmlDb.Xslt.Engine.XsltException xe => (ExtractErrorCode(xe.Message), xe.Message),
        _ => (null, ex.Message),
    };

    private static string? ExtractErrorCode(string message)
    {
        var match = ErrorCodePattern.Match(message);
        return match.Success ? match.Groups[1].Value : null;
    }
}
