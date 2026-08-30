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

        var skipReason = ClassifySkip(xspecXml);
        if (skipReason != null)
            return new XSpecResult(absoluteXspecPath, XSpecStage.Skipped, null, null, [], skipReason);

        // ---- Stage 1: Compile ----
        string generatedStylesheet;
        try
        {
            generatedStylesheet = await CompileAsync(xspecXml, xspecUri, ct).ConfigureAwait(false);
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
        string reportXml;
        try
        {
            reportXml = await RunGeneratedStylesheetAsync(generatedStylesheet, xspecUri, ct).ConfigureAwait(false);
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
    /// Stage 1: transforms <paramref name="xspecXml"/> with XSpec's own compiler into a
    /// generated XSLT stylesheet's source text.
    /// </summary>
    /// <remarks>
    /// The compiler (compiler/compile-xslt-tests.xsl, transitively including the rest of
    /// src/) only exists as embedded resources until <see cref="EmbeddedXSpecSource.MaterializedRoot"/>
    /// extracts it to real files — see that class for why. The compile transform runs with
    /// apply-templates against the .xspec source document (bin/xspec.sh passes no -it: for
    /// this step; the match="document-node()" template in compiler/base/main.xsl dispatches
    /// to the named x:main template itself). <c>x:import</c> inside the .xspec is resolved via
    /// the *source document's* base URI (see <c>compiler/base/resolve-import/gather/gather-descriptions.xsl</c>,
    /// which loads each import target with <c>fn:document(@href)</c> — resolved against the
    /// attribute node's own base URI, i.e. the source document's), which is why
    /// <paramref name="xspecUri"/> is passed to <see cref="XsltTransformer.SetSourceDocumentUri"/>
    /// rather than left unset. Exposed internally (not just exercised via <see cref="RunAsync"/>)
    /// so a test can assert on how far compilation gets independently of stage 2.
    /// </remarks>
    internal static async Task<string> CompileAsync(string xspecXml, Uri xspecUri, CancellationToken ct)
    {
        var compilerRoot = EmbeddedXSpecSource.MaterializedRoot;
        var compilerPath = Path.Combine(compilerRoot, "compiler", "compile-xslt-tests.xsl");
        var compilerXml = await File.ReadAllTextAsync(compilerPath, ct).ConfigureAwait(false);

        var compileTransformer = new XsltTransformer();
        await compileTransformer.LoadStylesheetAsync(compilerXml, new Uri(compilerPath)).ConfigureAwait(false);
        compileTransformer.SetSourceDocumentUri(xspecUri);
        return await compileTransformer.TransformAsync(xspecXml, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Stage 2: loads and runs a generated stylesheet (the output of <see cref="CompileAsync"/>)
    /// by calling its <c>{http://www.jenitennison.com/xslt/xspec}main</c> initial template with
    /// no source document, returning the serialized <c>x:report</c>.
    /// </summary>
    /// <remarks>
    /// The base-URI hazard this project exists to expose: the generated stylesheet's own
    /// <c>xsl:import</c> of the stylesheet-under-test is a literal, unresolved copy of
    /// <c>x:description/@stylesheet</c> (see compiler/xslt/main.xsl, <c>&lt;xsl:attribute
    /// name="href" select="@stylesheet" /&gt;</c>) — e.g. <c>"identity.xsl"</c>. That import
    /// must resolve against the *original* .xspec's directory, not against
    /// <see cref="EmbeddedXSpecSource.MaterializedRoot"/> or any other staging location. The
    /// generated text is never written to a temp file; it is loaded directly here with baseUri
    /// set to <paramref name="xspecUri"/>, so the relative <c>"identity.xsl"</c> resolves next
    /// to the suite where it actually lives. Exposed internally (not just exercised via
    /// <see cref="RunAsync"/>) so this resolution can be proven directly, with a stub
    /// <paramref name="generatedStylesheet"/> that doesn't depend on stage 1 succeeding — see
    /// <c>BaseUriHazardTests.Stage2Import_ResolvesAgainstOriginalXspecDirectory_NotMaterializedRoot</c>.
    /// </remarks>
    internal static async Task<string> RunGeneratedStylesheetAsync(string generatedStylesheet, Uri xspecUri, CancellationToken ct)
    {
        var runTransformer = new XsltTransformer();
        await runTransformer.LoadStylesheetAsync(generatedStylesheet, xspecUri).ConfigureAwait(false);
        runTransformer.SetInitialTemplate("main", XSpecNs);
        return await runTransformer.TransformAsync((string?)null, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Decides whether a suite is one this runner can meaningfully attempt, returning the reason
    /// it cannot when it is not, and <c>null</c> when it can.
    /// </summary>
    /// <remarks>
    /// Mirrors the dispatch in XSpec's own <c>bin/xspec.sh</c>, including its precedence:
    /// <c>x:description/@schematron</c> marks a Schematron suite (checked FIRST — such a suite
    /// is preprocessed into a stylesheet, and several also carry a <c>@stylesheet</c> that would
    /// otherwise misclassify them), <c>@query</c> marks an XQuery suite (which likewise may carry
    /// a decoy <c>@stylesheet</c>, e.g. test/do-nothing_query.xspec), and only what is left is an
    /// XSLT suite. A suite this runner cannot attempt is reported as
    /// <see cref="XSpecStage.Skipped"/> with a written reason rather than being silently dropped
    /// or, worse, counted as a compile failure against the XSLT engine — it is neither.
    /// </remarks>
    internal static string? ClassifySkip(string xspecXml)
    {
        XElement? root;
        try
        {
            root = XDocument.Parse(xspecXml).Root;
        }
        catch (System.Xml.XmlException)
        {
            // Not well-formed: not a skip. Let the compile stage report it as the failure it is,
            // with the engine's own diagnostic, rather than inventing a reason here.
            return null;
        }

        if (root is null)
            return null;

        if (root.Attribute("schematron") != null)
        {
            return "Schematron suite (x:description/@schematron): needs XSpec's vendored " +
                   "schxslt2 + XQS pipeline, which this runner does not carry.";
        }

        if (root.Attribute("query") != null)
        {
            return "XQuery suite (x:description/@query): this runner drives the XSLT engine only.";
        }

        return null;
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

            // Only failures need the values. Passing assertions would just be noise, and the
            // serialization is not free on a large report.
            string? expected = null, actual = null;
            if (outcome == XSpecOutcome.Fail)
            {
                expected = Serialize(test.Element(ns + "expect"));
                // A test carries its own x:result only when an @test predicate produced a value.
                // Otherwise what the code under test returned lives on the enclosing scenario,
                // shared by every assertion in it.
                actual = Serialize(test.Element(ns + "result"))
                      ?? Serialize(test.Ancestors(ns + "scenario")
                                       .Select(sc => sc.Element(ns + "result"))
                                       .FirstOrDefault(r => r != null));
            }

            outcomes.Add(new XSpecTestOutcome(BuildLabel(test, ns), outcome, expected, actual));
        }
        return outcomes;
    }

    /// <summary>
    /// Renders the payload of an <c>x:expect</c> or <c>x:result</c> for display. XSpec wraps
    /// constructed content in <c>x:content-wrap</c>, which is scaffolding rather than part of
    /// what the author wrote, so it is unwrapped. A <c>@select</c> with no children is an
    /// expression rather than a value and is shown as written.
    /// </summary>
    private static string? Serialize(XElement? element)
    {
        if (element is null)
            return null;

        XNamespace ns = XSpecNs;
        var payload = element.Elements().ToList();
        if (payload.Count == 1 && payload[0].Name == ns + "content-wrap")
            payload = payload[0].Elements().ToList();

        if (payload.Count == 0)
        {
            var text = element.Value.Trim();
            if (text.Length > 0)
                return text;
            return element.Attribute("select")?.Value;
        }

        return string.Join("\n", payload.Select(e => Normalize(e).ToString(SaveOptions.None)));
    }

    /// <summary>
    /// Rebuilds an element so the same namespace always renders the same way. The two sides of a
    /// failed assertion reach the report through different construction paths and pick up
    /// whatever prefix bindings were in scope there, so an identical namespace can serialize as
    /// <c>x:greeting xmlns:x="..."</c> on one side and <c>greeting xmlns="..."</c> on the other.
    /// Printing them like that hides the difference the reader is actually looking for. Copying
    /// the tree without the inherited declarations lets XLinq emit minimal, consistent ones.
    /// </summary>
    private static XElement Normalize(XElement source) =>
        new(source.Name,
            source.Attributes().Where(a => !a.IsNamespaceDeclaration)
                  .Select(a => new XAttribute(a.Name, a.Value)),
            source.Nodes().Select(n => n is XElement child ? Normalize(child) : n));

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
