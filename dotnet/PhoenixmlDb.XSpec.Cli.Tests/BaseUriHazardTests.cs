using PhoenixmlDb.XSpec.Cli;
using Xunit;

namespace PhoenixmlDb.XSpec.Cli.Tests;

/// <summary>
/// Directly exercises the two base-URI resolution points XSpecRunner exists to get right,
/// independently of the (unrelated, out-of-scope) engine defect that currently stops
/// <c>trivial-pass.xspec</c>/<c>trivial-fail.xspec</c> at Stage 1 before Stage 2 ever runs.
/// See task-3-report.md, "Root cause of the two failures", for that defect's own repro.
/// </summary>
public class BaseUriHazardTests
{
    /// <summary>
    /// Proves stage 2's <c>xsl:import</c> resolves against the original <c>.xspec</c>'s own
    /// directory, not against <see cref="EmbeddedXSpecSource.MaterializedRoot"/> — the
    /// hazard this project exists to solve (see <c>XSpecRunner.RunGeneratedStylesheetAsync</c>).
    /// </summary>
    /// <remarks>
    /// This does not depend on stage 1 (the compiler) succeeding at all: it hands
    /// <see cref="XSpecRunner.RunGeneratedStylesheetAsync"/> a hand-written stub generated
    /// stylesheet directly, exactly the shape stage 1 would have produced (an
    /// <c>xsl:import</c> of a relative href, and an <c>x:main</c> named template), so it stays
    /// meaningful even while the real compiler is blocked by the unrelated XTDE0930 defect.
    /// <para/>
    /// A same-named decoy module is planted under <see cref="EmbeddedXSpecSource.MaterializedRoot"/>
    /// with different content. If resolution ever used the wrong root, the decoy's marker text
    /// would come back instead of the real fixture's — a test that merely checked "did this
    /// throw" would pass under either resolution and prove nothing, per the review that asked
    /// for this test.
    /// </remarks>
    [Fact]
    public async Task Stage2Import_ResolvesAgainstOriginalXspecDirectory_NotMaterializedRoot()
    {
        const string stubGeneratedStylesheet = """
            <?xml version="1.0" encoding="UTF-8"?>
            <xsl:stylesheet version="3.0"
                            xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                            xmlns:x="http://www.jenitennison.com/xslt/xspec">
              <xsl:import href="hazard-marker.xsl"/>
              <xsl:template name="x:main">
                <xsl:call-template name="marker"/>
              </xsl:template>
            </xsl:stylesheet>
            """;

        // The real fixture, at Fixtures/hazard/hazard-marker.xsl, returns "correct-root".
        // The .xspec's own URI need not itself exist on disk — resolution only needs its
        // *directory* to be right, mirroring how a real .xspec's directory holds the
        // stylesheet-under-test XSpecRunner imports it from.
        var xspecUri = new Uri(Path.Combine(Fixtures.Dir, "hazard", "does-not-exist.xspec"));

        // Plant a same-named decoy under the materialized compiler root. Forcing
        // materialization first (via the property getter) guarantees this write isn't lost to
        // a later extraction happening after we've written it.
        var materializedRoot = EmbeddedXSpecSource.MaterializedRoot;
        var decoyPath = Path.Combine(materializedRoot, "hazard-marker.xsl");
        await File.WriteAllTextAsync(decoyPath, """
            <?xml version="1.0" encoding="UTF-8"?>
            <xsl:stylesheet version="3.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
              <xsl:template name="marker">
                <result>decoy-wrong-root</result>
              </xsl:template>
            </xsl:stylesheet>
            """);

        var report = await XSpecRunner.RunGeneratedStylesheetAsync(
            stubGeneratedStylesheet, xspecUri, CancellationToken.None);

        Assert.Contains("correct-root", report, StringComparison.Ordinal);
        Assert.DoesNotContain("decoy-wrong-root", report, StringComparison.Ordinal);
    }

    /// <summary>
    /// Proves stage 1's <c>x:import</c> is actually resolved via <c>SetSourceDocumentUri</c>,
    /// not merely reasoned about from reading the compiler's source.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The real compiler still cannot be driven to <see cref="XSpecStage.Complete"/>: every
    /// input, with or without an <c>x:import</c>, hits the same engine defect before
    /// compilation finishes. So this test cannot assert "the suite compiled" — instead it
    /// asserts the fixture fails with the exact <b>same</b> error as an import-free baseline,
    /// which only happens if the imported scenario was actually fetched and merged in; an
    /// unresolved import fails differently and earlier.
    /// </para>
    /// <para>
    /// The baseline is measured, not hard-coded. It used to be the literal string
    /// <c>"XTDE0930"</c>, which stopped meaning anything the moment that defect was fixed in
    /// PhoenixmlDb.XQuery: the test went red for a reason that had nothing to do with imports,
    /// and would have gone red again at every subsequent blocker. Comparing against a live
    /// import-free run keeps the assertion about the one thing it is for.
    /// </para>
    /// <para>
    /// Verified by hand before writing this assertion, and not re-asserted here (a negative
    /// control isn't something to leave as a permanent test — it would need its own decoy
    /// fixture to stay meaningful over time): pointing <c>x:import/@href</c> at a nonexistent
    /// file produces <c>FODC0005: Cannot retrieve document at URI '...'</c> at the Compile
    /// stage instead — a distinctly different, import-specific failure. That confirms this
    /// test's assertion (same failure as the baseline) actually discriminates "import resolved"
    /// from "import failed", rather than passing regardless.
    /// </para>
    /// <para>
    /// Once the compiler reaches <see cref="XSpecStage.Complete"/>, this test should be
    /// strengthened to assert that stage with the imported scenario's test actually present in
    /// <see cref="XSpecResult.Tests"/> — that is the real proof this stand-in falls short of.
    /// </para>
    /// </remarks>
    [Fact]
    public async Task Stage1Import_IsFetchedAndMerged_NotBlockedByAnImportResolutionFailure()
    {
        var baseline = await XSpecRunner.RunAsync(
            Path.Combine(Fixtures.Dir, "trivial-pass.xspec"), CancellationToken.None);
        var result = await XSpecRunner.RunAsync(
            Path.Combine(Fixtures.Dir, "import-hazard", "main.xspec"), CancellationToken.None);

        Assert.Equal(baseline.Stage, result.Stage);
        Assert.Equal(baseline.ErrorCode, result.ErrorCode);
        Assert.Equal(baseline.ErrorMessage, result.ErrorMessage);

        // The failure that would mean the import was NOT resolved.
        Assert.DoesNotContain("FODC0005", result.ErrorMessage ?? "", StringComparison.Ordinal);
    }
}
