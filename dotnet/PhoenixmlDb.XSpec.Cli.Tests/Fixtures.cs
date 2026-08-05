using System.Runtime.CompilerServices;

namespace PhoenixmlDb.XSpec.Cli.Tests;

/// <summary>
/// Resolves the Fixtures/ directory next to this source file by absolute path (via
/// <see cref="CallerFilePathAttribute"/>) rather than relative to the test runner's working
/// directory or the build output directory — both of which vary by how `dotnet test` is
/// invoked and would otherwise make the fixture .xspec files unfindable at run time.
/// </summary>
internal static class Fixtures
{
    public static string Dir { get; } = Path.Combine(Path.GetDirectoryName(SourceFilePath())!, "Fixtures");

    private static string SourceFilePath([CallerFilePath] string path = "") => path;
}
