namespace PhoenixmlDb.XSpec.Cli;

/// <summary>How far the pipeline got. Where a run stops is the census's primary signal.</summary>
public enum XSpecStage
{
    /// <summary>Failed compiling the .xspec into a runnable stylesheet.</summary>
    Compile,

    /// <summary>Compiled, but the generated stylesheet threw.</summary>
    Run,

    /// <summary>Ran, but its x:report could not be parsed.</summary>
    Assess,

    /// <summary>Ran to completion. Individual tests may still have failed.</summary>
    Complete,

    /// <summary>
    /// Deliberately not run, with a reason in <see cref="XSpecResult.SkipReason"/>.
    /// A skip is not a failure and is not an error code — it is its own outcome,
    /// and the census must be able to list it as such rather than hide it in a bucket.
    /// </summary>
    Skipped
}

/// <summary>The outcome of a single compiled <c>x:test</c>.</summary>
public enum XSpecOutcome
{
    Pass,
    Fail,
    Pending
}

/// <summary>One compiled assertion from the suite's <c>x:report</c>.</summary>
public record XSpecTestOutcome(string Label, XSpecOutcome Outcome);

/// <summary>
/// The outcome of running a single <c>.xspec</c> suite through <see cref="XSpecRunner"/>.
/// </summary>
public record XSpecResult(
    string XSpecPath,
    XSpecStage Stage,
    string? ErrorCode,
    string? ErrorMessage,
    IReadOnlyList<XSpecTestOutcome> Tests,
    string? SkipReason = null)
{
    public int Passed => Tests.Count(t => t.Outcome == XSpecOutcome.Pass);
    public int Failed => Tests.Count(t => t.Outcome == XSpecOutcome.Fail);
    public int Pending => Tests.Count(t => t.Outcome == XSpecOutcome.Pending);
}
