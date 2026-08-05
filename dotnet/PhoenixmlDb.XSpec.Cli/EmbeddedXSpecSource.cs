using System.Reflection;

namespace PhoenixmlDb.XSpec.Cli;

/// <summary>
/// Reads XSpec's stylesheets from resources embedded at pack time, and can materialise
/// the whole embedded tree onto disk as real files.
/// </summary>
/// <remarks>
/// <para>
/// Isolated behind one class so that pointing the runner at a filesystem checkout during
/// development is a single-class change rather than a change scattered through the pipeline.
/// </para>
/// <para>
/// <b>Why materialisation exists:</b> PhoenixmlDb.Xslt's stylesheet-module resolution
/// (<c>xsl:import</c> / <c>xsl:include</c>) only consults a caller-supplied
/// <c>PreloadedResources</c> cache for <c>http(s)</c> URIs — for anything else it resolves
/// straight to a local file path and throws <c>XTSE0165</c> if that path does not exist on
/// disk. XSpec's own compiler (<c>compile-xslt-tests.xsl</c>) includes its dependency
/// modules by relative filesystem path (e.g. <c>../common/common-utils.xsl</c>), so there is
/// no purely in-memory way to load it. <see cref="MaterializedRoot"/> extracts every
/// embedded resource once per process into a temp directory laid out exactly like XSpec's
/// real <c>src/</c> tree, so those relative includes resolve as ordinary files — the
/// installed tool still needs no checkout, because the tree it materialises came from
/// resources embedded at pack time, not from anything the user had to fetch.
/// </para>
/// </remarks>
internal static class EmbeddedXSpecSource
{
    private static readonly Assembly Self = typeof(EmbeddedXSpecSource).Assembly;

    private static readonly Lazy<string> LazyMaterializedRoot =
        new(MaterializeToTempDirectory, LazyThreadSafetyMode.ExecutionAndPublication);

    /// <param name="relativePath">Path below XSpec's src/, e.g. "compiler/compile-xslt-tests.xsl".</param>
    public static string ReadStylesheet(string relativePath)
    {
        // "VERSION" (no directory) is the conventional name callers ask for and the name
        // version-utils.xsl's own `unparsed-text('VERSION')` uses relative to its own base
        // URI once materialised — but the file's one real location in the src/ tree is
        // src/common/VERSION, and it is embedded under that logical name only (embedding it
        // under two logical names pointing at the same physical file trips MSBuild's
        // duplicate-EmbeddedResource-item check). Redirect here instead.
        var effectivePath = relativePath == "VERSION" ? "common/VERSION" : relativePath;
        var name = "xspec/" + effectivePath.Replace('\\', '/');
        using var stream = Self.GetManifestResourceStream(name)
            ?? throw new FileNotFoundException(
                $"Embedded XSpec resource '{name}' is missing. The pack-time glob in " +
                $"PhoenixmlDb.XSpec.Cli.csproj did not pick it up.", name);
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    /// <summary>
    /// Absolute path to a directory holding a filesystem copy of every embedded XSpec
    /// resource, laid out exactly like the real <c>src/</c> tree (e.g.
    /// <c>&lt;root&gt;/compiler/compile-xslt-tests.xsl</c>,
    /// <c>&lt;root&gt;/common/version-utils.xsl</c>). Extraction happens at most once per
    /// process; the same directory is reused for every <see cref="XSpecRunner.RunAsync"/>
    /// call. The directory is best-effort cleaned up on process exit.
    /// </summary>
    public static string MaterializedRoot => LazyMaterializedRoot.Value;

    private static string MaterializeToTempDirectory()
    {
        var root = Path.Combine(Path.GetTempPath(), "phxspec-src-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);

        foreach (var name in Self.GetManifestResourceNames())
        {
            if (!name.StartsWith("xspec/", StringComparison.Ordinal))
                continue;

            var relative = name["xspec/".Length..].Replace('/', Path.DirectorySeparatorChar);
            var destPath = Path.Combine(root, relative);
            var destDir = Path.GetDirectoryName(destPath);
            if (!string.IsNullOrEmpty(destDir))
                Directory.CreateDirectory(destDir);

            using var resourceStream = Self.GetManifestResourceStream(name)!;
            using var fileStream = File.Create(destPath);
            resourceStream.CopyTo(fileStream);
        }

        AppDomain.CurrentDomain.ProcessExit += (_, _) => TryDelete(root);
        return root;
    }

    private static void TryDelete(string root)
    {
        try
        {
            if (Directory.Exists(root))
                Directory.Delete(root, recursive: true);
        }
        catch (IOException)
        {
            // Best-effort cleanup only — a locked file or a process racing us to delete
            // the temp tree is not worth failing the run over.
        }
        catch (UnauthorizedAccessException)
        {
            // Same rationale as above.
        }
    }
}
