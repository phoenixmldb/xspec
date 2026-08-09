using PhoenixmlDb.XSpec.Cli;
using Xunit;

namespace PhoenixmlDb.XSpec.Cli.Tests;

public class XSpecRunnerTests
{
    [Fact]
    public void EmbeddedSourceExposesTheCompiler()
    {
        var xsl = EmbeddedXSpecSource.ReadStylesheet("compiler/compile-xslt-tests.xsl");
        Assert.Contains("xsl:stylesheet", xsl);
    }

    [Fact]
    public void EmbeddedSourceExposesVersionFile()
    {
        // version-utils.xsl does unparsed-text('VERSION'); without this the
        // x:xspec-version global throws before any test runs.
        Assert.False(string.IsNullOrWhiteSpace(EmbeddedXSpecSource.ReadStylesheet("VERSION")));
    }

    /// <summary>
    /// Records exactly how far the real XSpec compiler gets today — a characterisation test,
    /// not an aspiration.
    /// </summary>
    /// <remarks>
    /// <para>
    /// These two fixtures were originally asserted to reach <see cref="XSpecStage.Complete"/>.
    /// They never have. Against the pinned PhoenixmlDb.Xslt 1.6.1 both stop at <c>XTDE0930</c> in
    /// the compiler's namespace copying — the same defect <c>BaseUriHazardTests</c> had to work
    /// around, and which that class's own remarks describe as blocking every input. The original
    /// assertions were therefore red from the day they were written. Asserting a future state
    /// does not make it true; it makes the suite red and stops anyone noticing when the actual
    /// behaviour changes.
    /// </para>
    /// <para>
    /// Two blockers are accepted, because which one you see depends on the engine underneath:
    /// </para>
    /// <list type="number">
    /// <item><description>
    /// <c>XTDE0930</c> — the pinned 1.6.1. fn:namespace-uri-for-prefix did not walk ancestors, so
    /// XSpec's <c>x:copy-of-namespaces</c> fed an empty sequence into <c>xsl:namespace</c>.
    /// </description></item>
    /// <item><description>
    /// <c>startIndex cannot be larger than length of string</c> — with the XQuery fix in
    /// (PhoenixmlDb.XQuery routes that function through the shared in-scope namespace walk).
    /// Compilation then gets FURTHER and dies on the next defect: the XSLT engine's user-function
    /// return path finds its output buffer shorter on the way out of a function body than on the
    /// way in.
    /// </description></item>
    /// </list>
    /// <para>
    /// Both are asserted precisely, so this goes RED the moment the engine gets past them —
    /// which is the signal to strengthen it back to the Complete assertion, and to restore
    /// <c>trivial-fail</c>'s point: a failing assertion is a completed run, not a broken one, and
    /// the census must be able to tell an engine bug from a test that simply disagrees.
    /// </para>
    /// </remarks>
    [Theory]
    [InlineData("trivial-pass.xspec")]
    [InlineData("trivial-fail.xspec")]
    public async Task CompilerDoesNotYetReachCompletion_AndFailsAtAKnownBlocker(string fixture)
    {
        var result = await XSpecRunner.RunAsync(
            Path.Combine(Fixtures.Dir, fixture), CancellationToken.None);

        Assert.Equal(XSpecStage.Compile, result.Stage);

        var message = result.ErrorMessage ?? "";
        var known = message.Contains("XTDE0930", StringComparison.Ordinal)
                 || message.Contains("startIndex cannot be larger than length of string", StringComparison.Ordinal);
        Assert.True(known,
            $"expected one of the two known compile blockers, got: {result.ErrorCode} {message}");
    }

    [Fact]
    public void SchematronSuiteIsSkippedWithAReason()
    {
        var reason = XSpecRunner.ClassifySkip(
            """<x:description schematron="avt.sch" xmlns:x="http://www.jenitennison.com/xslt/xspec"/>""");

        Assert.NotNull(reason);
        Assert.Contains("Schematron", reason, StringComparison.Ordinal);
    }

    [Fact]
    public void QuerySuiteIsSkippedWithAReasonEvenWhenItAlsoCarriesAStylesheet()
    {
        // test/do-nothing_query.xspec really does carry BOTH: query= names the module under
        // test and stylesheet= is a decoy for the harness. Checking @stylesheet first would
        // run an XQuery suite through the XSLT engine and file the wreckage as an engine bug.
        var reason = XSpecRunner.ClassifySkip(
            """
            <x:description query="x-urn:test:do-nothing" stylesheet="do-nothing.xsl"
                           xmlns:x="http://www.jenitennison.com/xslt/xspec"/>
            """);

        Assert.NotNull(reason);
        Assert.Contains("XQuery", reason, StringComparison.Ordinal);
    }

    [Fact]
    public void SchematronWinsOverStylesheet()
    {
        var reason = XSpecRunner.ClassifySkip(
            """
            <x:description schematron="a.sch" stylesheet="a.xsl"
                           xmlns:x="http://www.jenitennison.com/xslt/xspec"/>
            """);

        Assert.NotNull(reason);
        Assert.Contains("Schematron", reason, StringComparison.Ordinal);
    }

    [Fact]
    public void StylesheetSuiteIsNotSkipped()
    {
        Assert.Null(XSpecRunner.ClassifySkip(
            """<x:description stylesheet="a.xsl" xmlns:x="http://www.jenitennison.com/xslt/xspec"/>"""));
    }

    [Fact]
    public void MalformedSuiteIsNotSkipped()
    {
        // Not well-formed is a real failure the compile stage must report with the engine's
        // own diagnostic — turning it into a skip would hide it from the census.
        Assert.Null(XSpecRunner.ClassifySkip("<x:description"));
    }
}
