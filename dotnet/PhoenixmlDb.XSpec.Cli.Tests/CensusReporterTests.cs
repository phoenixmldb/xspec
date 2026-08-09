using PhoenixmlDb.XSpec.Cli;
using Xunit;

namespace PhoenixmlDb.XSpec.Cli.Tests;

public class CensusReporterTests
{
    [Fact]
    public void GroupsByErrorCodeNotByFile()
    {
        // The pick-list is ranked by how many suites share a cause, because
        // that is what tells us which engine bug to fix first.
        var results = new[]
        {
            new XSpecResult("a.xspec", XSpecStage.Run, "XTTE0505", "…", []),
            new XSpecResult("b.xspec", XSpecStage.Run, "XTTE0505", "…", []),
            new XSpecResult("c.xspec", XSpecStage.Compile, "XPTY0004", "…", []),
        };

        var md = CensusReporter.Render(results);

        var xtte = md.IndexOf("XTTE0505", StringComparison.Ordinal);
        var xpty = md.IndexOf("XPTY0004", StringComparison.Ordinal);
        Assert.True(xtte >= 0 && xpty >= 0, "both codes must appear");
        Assert.True(xtte < xpty, "the more frequent code must rank first");
    }

    [Fact]
    public void ListsEverySkipWithAReason()
    {
        // A census that silently drops suites reports a number nobody can trust.
        var results = new[]
        {
            new XSpecResult("threads_scenario.xspec", XSpecStage.Skipped, null, null, [],
                SkipReason: "Requires Saxon threading configuration"),
        };

        var md = CensusReporter.Render(results);

        Assert.Contains("threads_scenario.xspec", md);
        Assert.Contains("Requires Saxon threading configuration", md);
    }

    [Fact]
    public void EveryResultAppearsSomewhereInOutput()
    {
        // No suite may be dropped, regardless of which stage it reached.
        var results = new[]
        {
            new XSpecResult("compile-fail.xspec", XSpecStage.Compile, "XPTY0004", "bad", []),
            new XSpecResult("run-fail.xspec", XSpecStage.Run, "XTTE0505", "bad", []),
            new XSpecResult("assess-fail.xspec", XSpecStage.Assess, null, "bad report", []),
            new XSpecResult("complete.xspec", XSpecStage.Complete, null, null,
                [new XSpecTestOutcome("t1", XSpecOutcome.Pass)]),
            new XSpecResult("skipped.xspec", XSpecStage.Skipped, null, null, [], SkipReason: "reason"),
        };

        var md = CensusReporter.Render(results);

        foreach (var result in results)
        {
            Assert.Contains(result.XSpecPath, md);
        }
    }

    [Fact]
    public void SummaryTotalDoesNotSilentlyExcludeSkipsOrIncompleteSuites()
    {
        // The design point this task exists to enforce: a summary line that reads
        // as "everything not listed passed" is a false green. The count of suites
        // that ran to completion must never equal the total when skips or
        // incomplete suites are present, and the skip/incomplete counts must be
        // stated explicitly rather than implied by omission.
        var results = new[]
        {
            new XSpecResult("complete.xspec", XSpecStage.Complete, null, null,
                [new XSpecTestOutcome("t1", XSpecOutcome.Pass)]),
            new XSpecResult("skipped.xspec", XSpecStage.Skipped, null, null, [], SkipReason: "reason"),
            new XSpecResult("compile-fail.xspec", XSpecStage.Compile, "XPTY0004", "bad", []),
        };

        var md = CensusReporter.Render(results);

        Assert.Contains("Total suites: 3", md);
        Assert.Contains("1 skipped", md);
    }

    [Fact]
    public void UncodedFailuresAreBucketedByMessageNotLumpedTogether()
    {
        // Not every engine failure carries a code. Filing them all under one heading would
        // make one shared engine bug indistinguishable from many unrelated ones — which is
        // the single thing the pick-list exists to tell apart.
        var results = new[]
        {
            new XSpecResult("a.xspec", XSpecStage.Compile, null, "startIndex cannot be larger than length of string.", []),
            new XSpecResult("b.xspec", XSpecStage.Compile, null, "startIndex cannot be larger than length of string.", []),
            new XSpecResult("c.xspec", XSpecStage.Compile, null, "Object reference not set to an instance of an object.", []),
        };

        var md = CensusReporter.Render(results);

        var shared = md.IndexOf("### startIndex cannot be larger", StringComparison.Ordinal);
        var other = md.IndexOf("### Object reference not set", StringComparison.Ordinal);
        Assert.True(shared >= 0 && other >= 0, "distinct uncoded causes must get distinct headings");
        Assert.True(shared < other, "the more frequent cause must rank first");
        Assert.Contains("(2 suites)", md, StringComparison.Ordinal);
    }
}
