# XSpec census history

Each file is a full `phxspec --census test/*.xspec` sweep of the 284 suites at the root of
`test/` — 162 XSLT, plus 122 Schematron/XQuery correctly reported as skipped. They are
numbered in the order the engine changed underneath them, so any two can be diffed to see
exactly which suites moved and where they stopped.

Generate a new one with:

```bash
dotnet build dotnet/PhoenixmlDb.XSpec.Cli
PHXSPEC_SUITE_TIMEOUT_SECONDS=120 \
  dotnet run --project dotnet/PhoenixmlDb.XSpec.Cli --no-build -- --census test/*.xspec > out.md
```

The runner pins `PhoenixmlDb.Xslt` as a package. To measure an unreleased engine, swap that
`PackageReference` for a `ProjectReference` to a local checkout — but never commit it, since
the path is machine-specific.

## Progression (2026-08-14 → 16)

Counts are **where suites stop**, not what is fixed: a bucket can grow because upstream
blockers were cleared and more suites now reach it. Stage counts are the real measure.

| # | Engine state | Compile | **Run** | Largest buckets |
|---|---|---|---|---|
| 01 | XSLT 1.6.3 (published) | 162 | 0 | XTTE0780 87, XTDE0930 38, XPTY0004 22 |
| 02 | + typed function returns text nodes | 162 | 0 | XTDE0420 76, XTDE0930 38, XPTY0004 22 |
| 03 | + typed attribute template kept in shallow copy | 162 | 0 | XPTY0004 56, XTDE0930 56, XTDE1260 27 |
| 04 | + `fn:QName` accepts `xs:string` subtypes | 162 | 0 | XTDE0930 103, XTDE1260 27 |
| 05 | + `namespace-uri-for-prefix` resolves in-scope | 161 | **1** | startIndex 55, XTTE0780 45, FONS0004 26 |
| 06 | + function output base, seam consolidation | 161 | 1 | XTTE0780 83, FONS0004 43, XTDE1260 27 |
| 07 | + node atomization for atomic return type | 99 | **63** | XTSE0010 62, FONS0004 60, XTDE1260 27 |

Everything through 07 shipped as **PhoenixmlDb.Xslt 1.6.4** and **PhoenixmlDb.XQuery 1.6.2**.

Buckets eliminated outright across the sweep: `XTTE0780` (the text-node shape), `XTDE0420`,
`XPTY0004`, `XTDE0930`, and the `startIndex` ArgumentOutOfRangeException.

## Remaining backlog, largest first

**`XTSE0010` — 62 suites.** One message: *"The 'version' attribute is required on
xsl:stylesheet/xsl:transform"*, raised at **Run** stage, i.e. the stylesheet XSpec's compiler
*generated* will not compile. The attributes are constructed correctly — a probe at
`src/compiler/xslt/main.xsl` confirms `version=[3.0]` is computed — but they are absent from
the captured body, so they are lost during element construction rather than in the capture.

Do not treat this as a single dropped attribute. The generated stylesheet shows several
distinct value-loss symptoms:

```xml
<xsl:call-template name="Q{http://www.jenitennison.com/xslt/xspec}" />   <!-- local name gone -->
<xsl:element      name="Q{http://www.jenitennison.com/xslt/xspec}" ...>  <!-- same -->
<xsl:attribute    name="xspec" namespace="" />                           <!-- value gone -->
```

`XTSE0010` is simply the first one the compiler rejects. Characterize the whole cluster
before changing code; fixing only the missing `version` will surface the next symptom
immediately.

**`FONS0004` — 60 suites.** Not yet investigated.

**`XTDE1260` — 27 suites.** Not yet investigated.

**`FORX0002` — 10 suites.** POSIX character-class syntax (`[:alpha:]`) unsupported in the
regex engine. A known limitation rather than a defect.

**`XTDE0430` — 2 suites**, **`XPST0003` — 1 suite** (an empty expression, at Run stage).

## Method note

Before chasing a bucket, check whether it is one cause or many:

```bash
grep "Error: <CODE>" census/07-*.md | sed 's/.*<CODE>: //' | sort | uniq -c | sort -rn
```

Every bucket resolved above turned out to be a single cause, which made each fix worth far
more than its size suggested. That two-minute check repeatedly saved chasing dozens of suites
individually — and `XTSE0010` is the first one where the check's answer ("one message") still
hides several distinct causes behind it.
