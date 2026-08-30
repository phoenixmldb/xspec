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
    /// Both fixtures now run end to end. This test previously asserted the opposite, pinning the
    /// two compile blockers of the day (<c>XTDE0930</c> from a namespace walk that did not visit
    /// ancestors, and a <c>startIndex</c> fault in the user-function return path) and saying in
    /// its own remarks that going red was the signal to strengthen it. It went red, so here is
    /// the stronger version.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The assertion this fixture makes is <c>exists($x:result//doc)</c>, which is unprefixed and
    /// therefore looks for <c>doc</c> in NO namespace. It should pass: the source writes
    /// <c>&lt;doc&gt;hello&lt;/doc&gt;</c> inside <c>x:context</c> with no default namespace in
    /// scope, and the stylesheet is a shallow-copy identity transform.
    /// </para>
    /// <para>
    /// It does not pass. The value the runner reports is
    /// <c>&lt;doc xmlns="http://www.jenitennison.com/xslt/xspec"&gt;hello&lt;/doc&gt;</c>, so the
    /// result lands in the XSpec namespace and the predicate cannot match. The engine is not at
    /// fault for the serialization: constructing or copying a no-namespace element into a
    /// default-namespaced parent emits <c>xmlns=""</c> correctly in both cases, verified
    /// directly. The namespace is acquired somewhere in the compiled namespace-copying path.
    /// </para>
    /// <para>
    /// Asserted as it currently behaves, deliberately, so this goes RED the moment the namespace
    /// is fixed. That is the signal to restore the assertion above it: 1 passed, 0 failed. The
    /// same trick the previous version of this test played on us, which is how the bug above was
    /// found at all.
    /// </para>
    /// </remarks>
    [Fact]
    public async Task TrivialPassRunsEndToEnd_ButItsAssertionFailsOnANamespace()
    {
        var result = await XSpecRunner.RunAsync(
            Path.Combine(Fixtures.Dir, "trivial-pass.xspec"), CancellationToken.None);

        Assert.Equal(XSpecStage.Complete, result.Stage);

        var failure = Assert.Single(result.Tests, t => t.Outcome == XSpecOutcome.Fail);
        Assert.Contains("http://www.jenitennison.com/xslt/xspec", failure.Actual!, StringComparison.Ordinal);
    }

    /// <summary>
    /// The point the earlier version lost: a failing assertion is a <em>completed</em> run, not a
    /// broken one. The census has to be able to tell an engine defect from a test that simply
    /// disagrees with the code, and those two look identical if a disagreement is reported as a
    /// stage failure.
    /// </summary>
    [Fact]
    public async Task TrivialFailRunsEndToEndAndReportsAFailedAssertion()
    {
        var result = await XSpecRunner.RunAsync(
            Path.Combine(Fixtures.Dir, "trivial-fail.xspec"), CancellationToken.None);

        Assert.Equal(XSpecStage.Complete, result.Stage);
        Assert.Equal(0, result.Passed);
        Assert.Equal(1, result.Failed);
        Assert.Null(result.ErrorMessage);
    }

    /// <summary>
    /// A failing assertion must carry what was expected and what actually happened. Reporting
    /// only the test's name tells you something broke and nothing about what, which is a worse
    /// experience than the xUnit output a .NET developer is arriving from, and it is the screen
    /// the whole bug-reporting on-ramp rests on.
    /// </summary>
    [Fact]
    public async Task AFailedAssertionCarriesExpectedAndActual()
    {
        var result = await XSpecRunner.RunAsync(
            Path.Combine(Fixtures.Dir, "value-mismatch.xspec"), CancellationToken.None);

        Assert.Equal(XSpecStage.Complete, result.Stage);
        var failure = Assert.Single(result.Tests, t => t.Outcome == XSpecOutcome.Fail);

        Assert.NotNull(failure.Expected);
        Assert.NotNull(failure.Actual);
        Assert.Contains("goodbye", failure.Expected, StringComparison.Ordinal);
        Assert.Contains("hello", failure.Actual, StringComparison.Ordinal);

        // Both sides reach the report by different construction paths and pick up whatever
        // prefix bindings were in scope, so the same namespace can render as x:doc on one side
        // and doc on the other. Printing them like that hides the difference the reader wants.
        Assert.Equal(
            failure.Expected.Contains("xmlns", StringComparison.Ordinal),
            failure.Actual.Contains("xmlns", StringComparison.Ordinal));
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
