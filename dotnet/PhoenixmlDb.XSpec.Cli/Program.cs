using PhoenixmlDb.XSpec.Cli;

if (args.Length == 0 || args is ["-h" or "--help"])
{
    PrintUsage();
    return args.Length == 0 ? 1 : 0;
}

if (args is [("--census"), .. var censusPaths] && censusPaths.Length > 0)
{
    return await RunCensusAsync(censusPaths).ConfigureAwait(false);
}

var exitCode = 0;
foreach (var xspecPath in args)
{
    XSpecResult result;
    try
    {
        result = await XSpecRunner.RunAsync(xspecPath, CancellationToken.None).ConfigureAwait(false);
    }
    catch (Exception ex)
    {
        await Console.Error.WriteLineAsync($"{xspecPath}: unhandled error: {ex.Message}").ConfigureAwait(false);
        exitCode = 2;
        continue;
    }

    switch (result.Stage)
    {
        case XSpecStage.Complete:
            Console.WriteLine(
                $"{xspecPath}: {result.Passed} passed, {result.Failed} failed, {result.Pending} pending");
            if (result.Failed > 0)
                exitCode = 1;
            foreach (var test in result.Tests.Where(t => t.Outcome == XSpecOutcome.Fail))
            {
                Console.WriteLine($"  FAIL  {test.Label}");
                // A failing test that reports only its own name is worse than useless: it tells
                // you something broke and nothing about what. Show the two values that differ.
                WriteValue("expected", test.Expected);
                WriteValue("actual", test.Actual);
            }
            break;

        case XSpecStage.Skipped:
            Console.WriteLine($"{xspecPath}: skipped ({result.SkipReason})");
            break;

        default:
            await Console.Error.WriteLineAsync(
                $"{xspecPath}: error at stage {result.Stage}" +
                (result.ErrorCode != null ? $" [{result.ErrorCode}]" : "") +
                $": {result.ErrorMessage}").ConfigureAwait(false);
            exitCode = 2;
            break;
    }
}

return exitCode;

static void PrintUsage()
{
    Console.Error.WriteLine("""
        Usage: phxspec <suite.xspec> [suite2.xspec ...]
               phxspec --census <path> [path ...]

        Run one or more XSpec test suites against PhoenixmlDb.Xslt. No JVM, no Saxon.

        --census <path>...  Sweep suites through the same runner the single-suite path
                          uses, and print a Markdown census (summary, pick-list grouped
                          by error code, skips, per-suite detail) to stdout. Each path is
                          either a directory (swept recursively for *.xspec) or a single
                          .xspec file, so a sweep can be scoped to a chosen subset without
                          moving suites out of the tree they resolve their imports against.

                          PHXSPEC_SUITE_TIMEOUT_SECONDS caps each suite (default 300); one
                          that overruns is reported as PHXSPEC-TIMEOUT and the sweep goes on.

        Exit codes (single-suite form):
          0   every suite ran to completion with no failures
          1   at least one suite ran to completion but had failing tests
          2   a suite failed to compile, failed to run, or its report could not be read

        Exit codes (--census form):
          0   the sweep ran and the census was printed
          2   a given path does not exist, or no *.xspec suites were found
        """);
}

static async Task<int> RunCensusAsync(string[] paths)
{
    var suites = new List<string>();
    foreach (var path in paths)
    {
        var absolute = Path.GetFullPath(path);
        if (Directory.Exists(absolute))
        {
            suites.AddRange(Directory.EnumerateFiles(absolute, "*.xspec", SearchOption.AllDirectories));
        }
        else if (File.Exists(absolute))
        {
            // Explicit files let a sweep be scoped to a chosen subset (e.g. only the XSLT
            // suites at the root of xspec/test/) without moving suites out of the tree they
            // resolve their @stylesheet and x:import against.
            suites.Add(absolute);
        }
        else
        {
            await Console.Error.WriteLineAsync($"--census: path not found: {absolute}").ConfigureAwait(false);
            return 2;
        }
    }

    suites = suites.Distinct(StringComparer.Ordinal).OrderBy(p => p, StringComparer.Ordinal).ToList();

    if (suites.Count == 0)
    {
        await Console.Error.WriteLineAsync(
            $"--census: no *.xspec suites found under {string.Join(", ", paths)}").ConfigureAwait(false);
        return 2;
    }

    var timeout = CensusSuiteTimeout();

    var results = new List<XSpecResult>(suites.Count);
    foreach (var suite in suites)
    {
        XSpecResult result;
        using var cts = new CancellationTokenSource(timeout);
        try
        {
            result = await XSpecRunner.RunAsync(suite, cts.Token).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (cts.IsCancellationRequested)
        {
            // A suite that never returns must not take the sweep with it — and it must not be
            // filed under some other error code either. It gets its own, so the census cannot
            // report a hang as though it were a compile failure.
            result = new XSpecResult(suite, XSpecStage.Run, "PHXSPEC-TIMEOUT",
                $"suite did not finish within {timeout.TotalSeconds:0} s", []);
        }
        catch (Exception ex)
        {
            // An unhandled exception from the runner is itself a data point for the
            // census, not a reason to abort the sweep — every suite must still appear
            // in the output.
            result = new XSpecResult(suite, XSpecStage.Run, null, $"unhandled error: {ex.Message}", []);
        }

        results.Add(result);
    }

    Console.WriteLine(CensusReporter.Render(results));
    return 0;
}

static TimeSpan CensusSuiteTimeout()
{
    var raw = Environment.GetEnvironmentVariable("PHXSPEC_SUITE_TIMEOUT_SECONDS");
    return int.TryParse(raw, System.Globalization.NumberStyles.Integer,
        System.Globalization.CultureInfo.InvariantCulture, out var seconds) && seconds > 0
        ? TimeSpan.FromSeconds(seconds)
        : TimeSpan.FromSeconds(300);
}

/// <summary>
/// Prints one side of a failed assertion, indented under the FAIL line. Multi-line values are
/// aligned so the two sides can be compared by eye, and long ones are clipped rather than
/// flooding the terminal when a scenario returns a whole document.
/// </summary>
static void WriteValue(string caption, string? value)
{
    if (string.IsNullOrWhiteSpace(value))
        return;

    const int maxLines = 12;
    var lines = value.Replace("\r\n", "\n", StringComparison.Ordinal).Split('\n');
    var shown = lines.Length > maxLines ? lines[..maxLines] : lines;

    Console.WriteLine($"          {caption}:");
    foreach (var line in shown)
        Console.WriteLine($"            {line}");
    if (lines.Length > maxLines)
        Console.WriteLine($"            ... {lines.Length - maxLines} more line(s)");
}
