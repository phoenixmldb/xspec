# Tracking upstream XSpec

This is a fork of [xspec/xspec](https://github.com/xspec/xspec). It exists to add a PhoenixmlDb
processor driver — `phxspec`, a .NET runner that executes an XSpec suite on the PhoenixmlDb XSLT
engine with no JVM and no Saxon — and to record census measurements of that engine against the
XSpec corpus.

## Where we are

| | |
|---|---|
| forked from | **v4.0.3** |
| upstream latest | **v4.1.1** (2026-09, announced by Amanda Galtman) |
| upstream commits we do not have | **59** |
| files upstream changed | 480 |
| files we changed | 48 |
| **overlapping files** | **7** |

The overlap is small and mostly mechanical — vendored `lib/schxslt2/*`, `package-lock.json`, a CI
env file, an archived README. Our own work sits in `dotnet/`, `bin/phxspec.sh` and `census/`,
which upstream does not touch.

Set the remote up before comparing; only `origin` (our fork) is configured by default:

```bash
git remote add upstream https://github.com/xspec/xspec.git
git fetch upstream --tags
git log --oneline v4.0.3..v4.1.1
```

## What 4.1.1 brings that matters to us

- **Code coverage compatible with Saxon 13.0 as well as 12.7–12.10** (upstream #2377). Coverage is
  the part of XSpec most likely to interact with a non-Saxon processor.
- **XProc 3 execution** via MorganaXProc-III EE or XML Calabash 3, and XSpec-for-Schematron with an
  XSLT-based `queryBinding` driven from XProc. Not something `phxspec` implements; worth knowing
  because it widens what a "passing suite" means.

## The census baseline moves on upgrade

The census is measured against **284 top-level `test/*.xspec` suites** (a directory sweep finds
783 and is not comparable). Upstream added and changed suites between 4.0.3 and 4.1.1, so the
denominator changes: figures either side of the upgrade are **not** comparable.

Re-baseline deliberately — upgrade, then record a fresh census sweep as the new reference, rather
than folding the upgrade into a run intended to measure an engine change. Otherwise an engine
regression and a corpus change are indistinguishable in the numbers, which is the same mistake
that let overstated conformance figures stand for months.

## Contributing back

The intent is to offer the driver upstream, so XSpec can run on PhoenixmlDb alongside Saxon.

**Offer:** `dotnet/PhoenixmlDb.XSpec.Cli` and `bin/phxspec.sh` — a processor integration.

**Keep local:** `census/` — internal measurement of our engine, of no use to upstream, and it
would only add noise to a PR.

Best offered once the suite passes cleanly enough that the contribution does not arrive with a
list of caveats. Current standing is in the census records; the honest decomposition is 284 total,
122 not drivable by this runner (XQuery or Schematron suites), so 162 runnable.
