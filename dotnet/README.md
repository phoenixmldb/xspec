# phxspec

A .NET runner for [XSpec](https://github.com/xspec/xspec) test suites, built on
[PhoenixmlDb.Xslt](https://www.nuget.org/packages/PhoenixmlDb.Xslt). No JVM, no Saxon —
`phxspec` compiles and runs `.xspec` suites with a managed XSLT 3.0/4.0 engine.

## License

MIT, matching the rest of this repository. See `PackageLicenseExpression` in
`PhoenixmlDb.XSpec.Cli.csproj`.

## What this is

XSpec's own pipeline (see `bin/xspec.sh`) compiles a `.xspec` suite into a generated XSLT
stylesheet via `src/compiler/compile-xslt-tests.xsl`, then runs that generated stylesheet
by invoking its `{http://www.jenitennison.com/xslt/xspec}main` initial template with no
source document. The generated stylesheet's `x:report` output records the outcome of every
compiled assertion.

`phxspec` reimplements that two-stage pipeline against PhoenixmlDb.Xslt instead of Saxon:

- **`EmbeddedXSpecSource`** embeds XSpec's `src/` tree (stylesheets + the `VERSION` file)
  into the tool at pack time via MSBuild globbing, so the installed tool needs neither a
  checkout of this repository nor a JVM. PhoenixmlDb.Xslt's stylesheet-module resolution
  only consults a preloaded-content cache for `http(s)` imports — XSpec's own compiler
  includes its dependency modules by relative filesystem path — so `EmbeddedXSpecSource`
  materialises the embedded tree to a temp directory once per process and lets ordinary
  file resolution take it from there.
- **`XSpecRunner.RunAsync`** drives the three-stage pipeline (compile, run, assess) and
  reports how far it got in an `XSpecResult`, including per-test pass/fail/pending outcomes
  parsed from the generated `x:report`.
- **`Program.cs`** is a thin CLI: `phxspec <suite.xspec> [suite2.xspec ...]`.

## The base-URI hazard

XSpec's compiler resolves `x:import` relative to the `.xspec` file being compiled. The
*generated* stylesheet then does its own `xsl:import` of the stylesheet-under-test — a
literal, unresolved copy of `x:description/@stylesheet` (see
`src/compiler/xslt/main.xsl`) — which must resolve relative to that same original
`.xspec` location, not relative to wherever the generated stylesheet text happens to be
materialised. `XSpecRunner` never writes the generated stylesheet to a temp file: it loads
the generated XML text directly with its base URI set to the original `.xspec`'s own
absolute path, so the relative import resolves against the suite's real directory.

## Building

```bash
cd dotnet
dotnet build
```

## Testing

```bash
cd dotnet
dotnet test PhoenixmlDb.XSpec.Cli.Tests
```

## Running

```bash
dotnet run --project dotnet/PhoenixmlDb.XSpec.Cli -- path/to/suite.xspec
```

or, once packed and installed as a global tool:

```bash
phxspec path/to/suite.xspec
```

`bin/phxspec.sh` at the repository root is a thin wrapper around the installed tool.

## Status

This is a skeleton: one suite compiling and running end-to-end, not a conformance claim
against XSpec's own test suite. Upstream contribution back to
[xspec/xspec](https://github.com/xspec/xspec) is intended once the runner covers more of
XSpec's own suite.
