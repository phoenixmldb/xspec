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

## Progression (2026-08-14 → 25)

Counts are **where suites stop**, not what is fixed: a bucket can grow because upstream
blockers were cleared and more suites now reach it. Stage counts are the real measure, and
**Complete** is the only one that means a suite ran end to end.

| # | Engine state | Compile | Run | **Complete** | Largest buckets |
|---|---|---|---|---|---|
| 01 | XSLT 1.6.3 (published) | 162 | 0 | 0 | XTTE0780 87, XTDE0930 38, XPTY0004 22 |
| 02 | + typed function returns text nodes | 162 | 0 | 0 | XTDE0420 76, XTDE0930 38, XPTY0004 22 |
| 03 | + typed attribute template kept in shallow copy | 162 | 0 | 0 | XPTY0004 56, XTDE0930 56, XTDE1260 27 |
| 04 | + `fn:QName` accepts `xs:string` subtypes | 162 | 0 | 0 | XTDE0930 103, XTDE1260 27 |
| 05 | + `namespace-uri-for-prefix` resolves in-scope | 161 | 1 | 0 | startIndex 55, XTTE0780 45, FONS0004 26 |
| 06 | + function output base, seam consolidation | 161 | 1 | 0 | XTTE0780 83, FONS0004 43, XTDE1260 27 |
| 07 | + node atomization for atomic return type | 99 | 63 | 0 | XTSE0010 62, FONS0004 60, XTDE1260 27 |
| 08 | + attribute-stack restore, result-document empty seq | 99 | 39 | **24** | FONS0004 60, XTDE1260 27, saxon-version 12 |
| 09 | + typed-template attribute copy, accumulator untypedAtomic | 6 | 104 | **52** | saxon-config 39, XPTY0020 21, XPDY0002 5 |

Everything through 07 shipped as **PhoenixmlDb.Xslt 1.6.4** and **PhoenixmlDb.XQuery 1.6.2**.
08 is unreleased.

**08 is the first sweep with a non-zero Complete.** Of the 24 suites that run end to end,
56 tests pass and 54 fail out of 110 — those are *assertion* results from suites that
actually execute, not compiler errors, and they are the next thing worth reading. Failing
suites overall went 162 → 138, with no suite newly failing.

Buckets eliminated outright across the sweep: `XTTE0780` (the text-node shape), `XTDE0420`,
`XPTY0004`, `XTDE0930`, the `startIndex` ArgumentOutOfRangeException, and `XTSE0010`.

## Remaining backlog, largest first

**Assertion failures in the 24 completing suites — 54 of 110 tests.** New in 08 and the
first backlog item that is about XSpec *results* rather than about getting XSpec to run.
Read these before any bucket below: they are the only signal the sweep has ever produced
about whether the engine computes the right answers, as opposed to compiling.

**`FONS0004` — 60 suites.** Not yet investigated.

**`XTDE1260` — 27 suites.** Not yet investigated.

**saxon-version terminate — 12 suites.** `Transformation terminated: ERROR:
$x:saxon-version …`. Suites that require a Saxon-specific version probe; likely a
harness/skip question rather than an engine defect.

**`FORX0002` — 11 suites.** POSIX character-class syntax (`[:alpha:]`) unsupported in the
regex engine. A known limitation rather than a defect.

**`XTSE0280` — 5 suites**, **`XTDE0555` — 4 suites**, **`XTDE3052` — 3 suites**,
**`XTTE0505` — 3 suites**, then singles. All newly reachable in 08.

The remaining `XTTE0505` is NOT a remnant of the one fixed in 08: *"Template 'identity'
return value does not match declared type Node: expected exactly one item, got 0"* — one
item too **few**, where the fixed defect produced one too many.

### Resolved in 08

**`XTSE0010` — was 62 suites, now 0.** One defect, not the cluster this file previously
warned it might be. `_collectedAttributesStack` was saved to a `List` and restored with
`Clear(); foreach Push`, but `Stack<T>` enumerates top-first, so the restore REVERSED it.
At nesting depth ≥ 2 an element sealed against its parent's buffer, losing every attribute
made by the `xsl:attribute` instruction and shifting all later elements by one. Literal and
AVT attributes never enter that stack, which is why only code generators were affected. The
missing `@version`, the `Q{uri}` UQNames with an empty local part and the valueless
`xsl:attribute` elements were all the same bug, and all cleared together.

**`XTTE0505` — was 27 suites, now 3.** `xsl:result-document` must return the empty sequence
(XSLT 3.0 §26.1). One targeting the principal output wrote into the same buffer an
`as=`-typed body slices for its return value, so its content was counted as the template's
result — XSpec's generated `x:main` is exactly that shape. Fixing it is what took Complete
from 0 to 24.

## Method note

Before chasing a bucket, check whether it is one cause or many:

```bash
grep "Error: <CODE>" census/08-*.md | sed 's/.*<CODE>: //' | sort | uniq -c | sort -rn
```

Every bucket resolved so far has turned out to be a **single cause**, including the two
cleared in 08 — `XTSE0010`'s 62 suites and `XTTE0505`'s 27 each carried one identical
message. Two minutes, repeatedly decisive.

The counterpart, when a bucket does resolve: diff the pick-lists of two sweeps as sets, in
both directions. "No suite newly failing" is the regression check, and "failing count fell"
is the progress check — neither is visible in the stage table alone, because a suite that
merely swaps one blocker for another moves no counter.

Every bucket resolved above turned out to be a single cause, which made each fix worth far
more than its size suggested. That two-minute check repeatedly saved chasing dozens of suites
individually — and `XTSE0010` is the first one where the check's answer ("one message") still
hides several distinct causes behind it.

### 09 — the typed-template attribute copy (2026-08-25)

The largest single move so far: **Complete 24 → 52**, and Compile blockers 99 → 6.

One engine fix did most of it. `xsl:copy` of an attribute joined a typed template's result
sequence only when the engine was not already collecting attributes — but XSpec's
`local:identity` in `report-sequence.xsl` is called while the CALLER's `xsl:copy` is still
collecting its own. The attribute was appended to the caller's element and the template
returned nothing, so every suite that built a report died on
`XTTE0505 … expected exactly one item, got 0`. Reported by Martin Honnen; fixed in
phoenixmldb-xslt `945c686`.

**No W3C conformance case covers that shape** — the XSLT census did not move at all when it
was fixed, while this one moved 28 suites. Fourth time this month a real-world corpus found
what 31,470 conformance cases could not.

Remaining, largest first:

| bucket | suites | assessment |
|---|---|---|
| `saxon-config` | 39 | **out of scope** — suites passing a Saxon configuration file |
| `XPTY0020` | 21 | largest genuine engine bucket; context item is not a node |
| `XPDY0002` | 5 | context item absent |
| `XTDE3052` | 5 | `Package '…' not found` — test fixtures, likely harness |
| `XTDE0555` | 4 | no match in a mode with `on-no-match="fail"` |

Measured against the engine at phoenixmldb-xslt `945c686` via a temporary ProjectReference,
not against published 1.6.7 — those fixes are unreleased.
