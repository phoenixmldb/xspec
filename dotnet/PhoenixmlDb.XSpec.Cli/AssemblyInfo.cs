using System.Runtime.CompilerServices;

// EmbeddedXSpecSource is internal — it's an implementation detail of how the runner
// loads XSpec's stylesheets, not part of the tool's public surface. The test project
// still needs to verify it directly (that the pack-time glob actually captured the
// compiler and VERSION file), so it gets visibility rather than the type going public.
[assembly: InternalsVisibleTo("PhoenixmlDb.XSpec.Cli.Tests")]
