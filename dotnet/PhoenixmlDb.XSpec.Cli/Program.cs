using PhoenixmlDb.XSpec.Cli;

if (args.Length == 0 || args is ["-h" or "--help"])
{
    PrintUsage();
    return args.Length == 0 ? 1 : 0;
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

        Run one or more XSpec test suites against PhoenixmlDb.Xslt. No JVM, no Saxon.

        Exit codes:
          0   every suite ran to completion with no failures
          1   at least one suite ran to completion but had failing tests
          2   a suite failed to compile, failed to run, or its report could not be read
        """);
}
