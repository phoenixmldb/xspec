using System.Text;

namespace PhoenixmlDb.XSpec.Cli;

/// <summary>
/// Renders a Markdown census of a directory sweep: how far each suite got, and — for suites
/// that didn't reach <see cref="XSpecStage.Complete"/> — a pick-list grouped by error code so
/// the fix loop can prioritise the engine bug shared by the most suites.
/// </summary>
/// <remarks>
/// Deliberately free of console and exit-code concerns; <c>Program.cs</c> owns those. A census
/// that quietly drops suites (skips folded into a "not shown" bucket, or a "total = suites we
/// happened to list") reports a number nobody can trust — every suite in the input list appears
/// somewhere in the output, and every total accounts for skips explicitly rather than by
/// omission.
/// </remarks>
public static class CensusReporter
{
    public static string Render(IReadOnlyList<XSpecResult> results)
    {
        var sb = new StringBuilder();

        sb.AppendLine("# XSpec Census");
        sb.AppendLine();
        AppendSummary(sb, results);
        AppendPickList(sb, results);
        AppendSkips(sb, results);
        AppendDetail(sb, results);

        return sb.ToString();
    }

    private static void AppendSummary(StringBuilder sb, IReadOnlyList<XSpecResult> results)
    {
        sb.AppendLine("## Summary");
        sb.AppendLine();
        sb.AppendLine($"Total suites: {results.Count}");
        sb.AppendLine();
        sb.AppendLine("| Stage reached | Suites |");
        sb.AppendLine("|---|---|");

        foreach (var stage in Enum.GetValues<XSpecStage>())
        {
            var count = results.Count(r => r.Stage == stage);
            sb.AppendLine($"| {stage} | {count} |");
        }

        sb.AppendLine();

        var complete = results.Where(r => r.Stage == XSpecStage.Complete).ToList();
        var totalTests = complete.Sum(r => r.Tests.Count);
        var totalPassed = complete.Sum(r => r.Passed);
        var totalFailed = complete.Sum(r => r.Failed);
        var totalPending = complete.Sum(r => r.Pending);

        sb.AppendLine(
            $"Of the {complete.Count} suites that ran to completion: {totalPassed} tests passed, " +
            $"{totalFailed} failed, {totalPending} pending, out of {totalTests} total. " +
            $"This excludes {results.Count(r => r.Stage == XSpecStage.Skipped)} skipped and " +
            $"{results.Count(r => r.Stage != XSpecStage.Complete && r.Stage != XSpecStage.Skipped)} " +
            "suites that did not reach completion — see below for both.");
        sb.AppendLine();
    }

    private static void AppendPickList(StringBuilder sb, IReadOnlyList<XSpecResult> results)
    {
        sb.AppendLine("## Pick-list (by error code)");
        sb.AppendLine();

        var failing = results.Where(r => r.Stage is XSpecStage.Compile or XSpecStage.Run or XSpecStage.Assess);
        var groups = failing
            .GroupBy(r => r.ErrorCode ?? "(no error code)")
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.Key, StringComparer.Ordinal);

        var any = false;
        foreach (var group in groups)
        {
            any = true;
            sb.AppendLine($"### {group.Key} ({group.Count()} suite{(group.Count() == 1 ? "" : "s")})");
            sb.AppendLine();
            foreach (var result in group.OrderBy(r => r.XSpecPath, StringComparer.Ordinal))
            {
                sb.AppendLine($"- `{result.XSpecPath}` (stage: {result.Stage})");
            }
            sb.AppendLine();
        }

        if (!any)
        {
            sb.AppendLine("No suites failed to complete.");
            sb.AppendLine();
        }
    }

    private static void AppendSkips(StringBuilder sb, IReadOnlyList<XSpecResult> results)
    {
        sb.AppendLine("## Skipped");
        sb.AppendLine();

        var skipped = results
            .Where(r => r.Stage == XSpecStage.Skipped)
            .OrderBy(r => r.XSpecPath, StringComparer.Ordinal)
            .ToList();

        if (skipped.Count == 0)
        {
            sb.AppendLine("No suites were skipped.");
            sb.AppendLine();
            return;
        }

        sb.AppendLine("Every skipped suite, with the reason it was not run. A skip is not a " +
                       "pass and not counted in the totals above.");
        sb.AppendLine();
        foreach (var result in skipped)
        {
            var reason = result.SkipReason ?? "(no reason recorded)";
            sb.AppendLine($"- `{result.XSpecPath}`: {reason}");
        }
        sb.AppendLine();
    }

    private static void AppendDetail(StringBuilder sb, IReadOnlyList<XSpecResult> results)
    {
        sb.AppendLine("## Per-suite detail");
        sb.AppendLine();

        foreach (var result in results.OrderBy(r => r.XSpecPath, StringComparer.Ordinal))
        {
            sb.AppendLine($"### `{result.XSpecPath}`");
            sb.AppendLine();
            sb.AppendLine($"- Stage: {result.Stage}");

            switch (result.Stage)
            {
                case XSpecStage.Skipped:
                    sb.AppendLine($"- Skip reason: {result.SkipReason ?? "(no reason recorded)"}");
                    break;

                case XSpecStage.Complete:
                    sb.AppendLine($"- Passed: {result.Passed}, Failed: {result.Failed}, Pending: {result.Pending}");
                    foreach (var test in result.Tests.Where(t => t.Outcome == XSpecOutcome.Fail))
                    {
                        sb.AppendLine($"  - FAIL: {test.Label}");
                    }
                    break;

                default:
                    if (result.ErrorCode != null)
                        sb.AppendLine($"- Error code: {result.ErrorCode}");
                    if (result.ErrorMessage != null)
                        sb.AppendLine($"- Error: {result.ErrorMessage}");
                    break;
            }

            sb.AppendLine();
        }
    }
}
