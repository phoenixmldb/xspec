using PhoenixmlDb.XSpec.Cli;

if (args.Length == 0 || args is ["-h" or "--help"])
{
    PrintUsage();
    return args.Length == 0 ? 1 : 0;
}

if (args is [("--census"), var censusDir, ..])
{
    return await RunCensusAsync(censusDir).ConfigureAwait(false);
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
                Console.WriteLine($"  FAIL  {test.Label}");
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
               phxspec --census <dir>

        Run one or more XSpec test suites against PhoenixmlDb.Xslt. No JVM, no Saxon.

        --census <dir>   Sweep every *.xspec suite under <dir> through the same runner
                          the single-suite path uses, and print a Markdown census
                          (summary, pick-list grouped by error code, skips, per-suite
                          detail) to stdout.

        Exit codes (single-suite form):
          0   every suite ran to completion with no failures
          1   at least one suite ran to completion but had failing tests
          2   a suite failed to compile, failed to run, or its report could not be read

        Exit codes (--census form):
          0   the sweep ran and the census was printed
          2   the given directory does not exist, or contains no *.xspec suites
        """);
}

static async Task<int> RunCensusAsync(string dir)
{
    var absoluteDir = Path.GetFullPath(dir);
    if (!Directory.Exists(absoluteDir))
    {
        await Console.Error.WriteLineAsync($"--census: directory not found: {absoluteDir}").ConfigureAwait(false);
        return 2;
    }

    var suites = Directory.EnumerateFiles(absoluteDir, "*.xspec", SearchOption.AllDirectories)
        .OrderBy(p => p, StringComparer.Ordinal)
        .ToList();

    if (suites.Count == 0)
    {
        await Console.Error.WriteLineAsync($"--census: no *.xspec suites found under {absoluteDir}").ConfigureAwait(false);
        return 2;
    }

    var results = new List<XSpecResult>(suites.Count);
    foreach (var suite in suites)
    {
        XSpecResult result;
        try
        {
            result = await XSpecRunner.RunAsync(suite, CancellationToken.None).ConfigureAwait(false);
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
