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

    [Fact]
    public async Task RunsATrivialPassingSuite()
    {
        var result = await XSpecRunner.RunAsync(
            Path.Combine(Fixtures.Dir, "trivial-pass.xspec"), CancellationToken.None);

        Assert.Equal(XSpecStage.Complete, result.Stage);
        Assert.Null(result.ErrorCode);
        Assert.Collection(result.Tests,
            t => Assert.Equal(XSpecOutcome.Pass, t.Outcome));
    }

    [Fact]
    public async Task ReportsAFailingAssertionAsFailNotError()
    {
        // A failing assertion is a completed run, not a broken one. Conflating
        // the two would make the census unable to distinguish an engine bug
        // from a test that simply disagrees.
        var result = await XSpecRunner.RunAsync(
            Path.Combine(Fixtures.Dir, "trivial-fail.xspec"), CancellationToken.None);

        Assert.Equal(XSpecStage.Complete, result.Stage);
        Assert.Null(result.ErrorCode);
        Assert.Collection(result.Tests,
            t => Assert.Equal(XSpecOutcome.Fail, t.Outcome));
    }
}
