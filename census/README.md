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

## Progression (2026-08-14 → 30)

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
| 10 | + one global content-binding path (was two) | 6 | 96 | **60** | saxon-config 47, XPDY0002 5, XPST0008 5 |
| 11 | published 1.6.10 (Martin's format-* and cross-store fixes) | 6 | 96 | **60** | saxon-config 47, XPDY0002 6, XPST0008 5 |
| 12 | + typed-body weave no longer double-counts text | 6 | 94 | **62** | saxon-config 47, XPDY0002 6, XPST0008 5 |
| 14 | + globals declared `as="empty-sequence()"` | 6 | 76 | **80** | XPST0008 14, XPDY0050 6, XTDE3052 5 |
| 15 | + `fn:transform` finds namespaced templates, supplies context | 6 | 70 | **86** | XPST0008 15, XPDY0050 6, XPTY0004 5 |
| 16 | + namespaces resolved inside wrapper patterns; accumulator sequences | 6 | 59 | **97** | XPTY0004 5, XTDE3052 5, FOTY0013 4 |

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

### 10 — XPTY0020 closed out (2026-08-26)

**XPTY0020 21 -> 0. Complete 52 -> 60.**

The engine had two implementations of "bind a global from a content sequence constructor".
The eager, dependency-ordered pass honoured `as`; the lazy on-demand pass stored the
serialized content as a raw xs:string and ignored `as`. Which pass ran depended on whether
the dependency analysis spotted the reference — and it does not recognise EQName
(`$Q{uri}local`) references, which XSpec generates throughout. So a variable's TYPE depended
on how another expression spelled its name.

The eager path already carried a fix for this exact error, from Martin Honnen's DocBook
report; its comment names XPTY0020. It had been applied to one of the two paths. Fixed in
phoenixmldb-xslt `4f5384c` by extracting the shared method.

`saxon-config` grew 39 -> 47 because suites now REACH it — the README's own caveat, visible
in one step. It remains out of scope: those suites pass a Saxon configuration file.

Remaining, largest first: saxon-config 47 (out of scope), XPDY0002 5, XPST0008 5, XTDE3052 5,
XPDY0050 4, XTDE0555 4. Against the ~123 realistically reachable suites (284 - 122 skipped -
47 saxon-config + overlap), 60 Complete is roughly half.

### 11 — no movement, and why that is the expected result (2026-08-27)

Measured against the PUBLISHED PhoenixmlDb.Xslt 1.6.10, not a ProjectReference. Identical to
census 10: Compile 6, Run 96, **Complete 60**, and **0 suites changed stage**.

That is not a disappointing result, it is the wrong instrument. Of the five fixes released
since census 10, only one touches what this census measures:

| fix | where it bites |
|---|---|
| nested kind-test namespaces | cleared XTDE0555 — already counted in census 10 |
| cross-store node ancestors | `fn:transform` called from XQUERY (sxq), not these XSLT suites |
| `format-*` casts untypedAtomic | XSpec's REPORTER stage, `format-xspec-report.xsl` |
| CLI reports instead of crash-dumping | error presentation, not transform behaviour |
| W3C codes carry ErrorCode/Location | diagnostics only |

This census runs `test/*.xspec` through compile -> run -> complete and stops at the XML
report. Martin Honnen is past those stages and into HTML report generation, which is the step
AFTER what is measured here. A flat census was the correct expectation.

One genuine shift despite 0 stage changes: XPDY0002 5 -> 6 and XTTE0505 3 -> 5. Suites are
failing at a different point than before, which is worth a look rather than an assumption.

Against the ~115 realistically reachable suites (284 - 122 skipped - 47 saxon-config), 60
Complete is a little over half. The next levers are the 5-6 suite clusters — XPDY0002,
XPST0008, XTDE3052 — each small enough that the one-cause-or-many check costs two minutes.

### 12 — the flat census was hiding movement (2026-08-28)

**Complete 60 -> 62, XTTE0505 5 -> 3.** Measured with a ProjectReference; the fix is not yet
released.

Census 11 looked completely flat: 0 suites changed stage. The only signal was inside the
buckets — XPDY0002 5 -> 6 and XTTE0505 3 -> 5 — which is easy to file as noise. It was not,
and the two had different causes:

- **XPDY0002 grew for a reporting reason.** `issue-59_stylesheet.xspec` was always failing
  with XPDY0002; it just had no error CODE, because that error was thrown as a bare
  InvalidOperationException. Giving W3C codes an ErrorCode moved it out of the uncoded pile.
  61 -> 56 failing suites now report an error without a code.
- **XTTE0505 grew because suites got FURTHER.** The nested-kind-test namespace fix let four
  templates match for the first time. Two then hit XTDE0540 (they match too many rules — you
  cannot be ambiguous without matching at all) and two hit XTTE0505.

Chasing that second group found a real defect: `WriteTextItem` writes text to BOTH the
sequence accumulator and `_output` inside a function body, and the weave that recombines them
assumed they were disjoint — so it emitted the item and then the same text again. A template
declared `as="text()"` returned two items with identical content. Fixed in phoenixmldb-xslt
`b6d623e`; the weave now records how much output each item consumed.

The lesson for reading this census: **stage counts are coarse.** A flat Complete can conceal
several suites advancing past one blocker onto the next. Diff the per-suite error codes, not
just the stages.

### 16 — namespaces were never resolved inside a wrapper pattern (2026-08-30)

Complete 86 -> **97**, and `XPST0008` fell from 15 suites to 3. One cause.

`ResolveNamespacesInPattern` walked PathPattern, UnionPattern, ExceptPattern and
IntersectPattern and stopped. Five pattern subclasses wrap another pattern and were never
visited: `ParenthesizedPositionalPattern.Inner`, and the `Continuation` of KeyPattern,
IdPattern, VariableReferencePattern and DocFunctionPattern. The wrapped pattern kept its
prefixes unresolved, so its name test compared against an unresolved NamespaceId and matched
nothing whatsoever.

The shape of the failure is why it lasted this long:

```
match="(x:a | x:b)[true()]"        matched NOTHING
match="x:a[true()] | x:b[true()]"  worked   -- no wrapper; UnionPattern IS visited
match="(a | b)[true()]"            worked   -- no prefix to resolve
```

Drop either the parentheses or the prefix and the bug disappears, and the obvious test for
parenthesized patterns uses no prefix. It is the same defect as the KindTest-nested NameTest
fix in census 12, one nesting level further out.

XSpec has exactly five such patterns and all five were dead:

| Pattern | What was silently off |
|---|---|
| `(x:scenario/x:param \| x:scenario/x:variable \| x:context)[...]` | the `stacked-vardecls` accumulator |
| `(x:scenario \| x:expect)[@pending] \| x:pending` | pending detection |
| `(x:scenario \| x:expect)[@pending]` | pending detection |
| `(x:param \| x:variable)[x:reason-for-pending(.) => empty()]` | pending variable declarations |
| `(@id \| @context)[parent::x:expect-rule]` | expect-rule attribute handling |

**How it presented.** The accumulator never fired, so no variable was ever pushed, so every
compiled `x:expect` template was generated without params for the variables in scope. The
suite then died at run time with `XPST0008: Variable $myv:after_call not bound` — naming a
variable the user really had declared, several stages away from the pattern that failed. The
route in was noticing which variables survived compilation: those before `x:context` did,
those after `x:call` did not. Position, not namespace, is what pointed at the accumulator.

Two accumulator bugs surfaced on the way and are fixed as well, though neither moved this
census on its own: `CoerceAccumulatorValue` returned `List<object?>` for a sequence type, which
the engine reads as an XDM *array* (`ItemType.Array => item is List<object?>`), so `count()`
answered 1 however many items had accumulated; and `CoerceAtomicValue` atomized
unconditionally, so an `as="element()*"` accumulator lost its nodes to xs:untypedAtomic.

Assertions executed went 596 -> 700 and passing 257 -> 275. Failures rose too, which is the
usual consequence of suites getting further, not a regression — no suite that completed before
stopped completing.

**The distribution is now flat**: the largest bucket is 5 suites and no error code dominates.
The era of one cause clearing a dozen suites looks finished; what remains reads as many small
causes, and should be picked off per-suite rather than per-bucket.
