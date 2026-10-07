# XSpec Census

## Summary

Total suites: 284

| Stage reached | Suites |
|---|---|
| Compile | 4 |
| Run | 19 |
| Assess | 0 |
| Complete | 139 |
| Skipped | 122 |

Of the 139 suites that ran to completion: 1112 tests passed, 256 failed, 3 pending, out of 1371 total. This excludes 122 skipped and 23 suites that did not reach completion — see below for both.

## Pick-list (by error code)

### XPST0008 (4 suites)

- `/repos/phoenixml/xspec/test/external_scenario-param.xspec` (stage: Run)
- `/repos/phoenixml/xspec/test/external_unfocused-param_not-inherited-by-focus.xspec` (stage: Run)
- `/repos/phoenixml/xspec/test/external_unfocused-shared-param_not-inherited-by-focus.xspec` (stage: Run)
- `/repos/phoenixml/xspec/test/unfocused-context.xspec` (stage: Run)

### XPTY0004 (4 suites)

- `/repos/phoenixml/xspec/test/external_avt-ws_stylesheet.xspec` (stage: Run)
- `/repos/phoenixml/xspec/test/external_coverage-contents-table.xspec` (stage: Run)
- `/repos/phoenixml/xspec/test/external_global-context_stylesheet.xspec` (stage: Run)
- `/repos/phoenixml/xspec/test/xspec-uri_stylesheet.xspec` (stage: Run)

### FODC0002 (3 suites)

- `/repos/phoenixml/xspec/test/generate-xproc-imports.xspec` (stage: Run)
- `/repos/phoenixml/xspec/test/schut-to-xslt.xspec` (stage: Run)
- `/repos/phoenixml/xspec/test/uri-utils.xspec` (stage: Run)

### XTDE0540 (3 suites)

- `/repos/phoenixml/xspec/test/generate-step3-wrapper_custom.xspec` (stage: Run)
- `/repos/phoenixml/xspec/test/generate-step3-wrapper_default.xspec` (stage: Run)
- `/repos/phoenixml/xspec/test/tutorial_helper_ws-only-text_stylesheet.xspec` (stage: Run)

### FONS0004 (2 suites)

- `/repos/phoenixml/xspec/test/threads_description_stylesheet.xspec` (stage: Compile)
- `/repos/phoenixml/xspec/test/threads_scenario_stylesheet.xspec` (stage: Compile)

### XTTE0505 (2 suites)

- `/repos/phoenixml/xspec/test/external_xmlns.xspec` (stage: Compile)
- `/repos/phoenixml/xspec/test/xmlns_stylesheet.xspec` (stage: Compile)

### FORG0002 (1 suite)

- `/repos/phoenixml/xspec/test/external_schut-to-xspec-for-xqs.xspec` (stage: Run)

### XPDY0050 (1 suite)

- `/repos/phoenixml/xspec/test/external_catch_stylesheet.xspec` (stage: Run)

### XPST0017 (1 suite)

- `/repos/phoenixml/xspec/test/report-sequence_stylesheet_schema-aware.xspec` (stage: Run)

### XTMM9000 (1 suite)

- `/repos/phoenixml/xspec/test/version-utils.xspec` (stage: Run)

### XTSE3000 (1 suite)

- `/repos/phoenixml/xspec/test/helper_xslt-package.xspec` (stage: Run)

## Skipped

Every skipped suite, with the reason it was not run. A skip is not a pass and not counted in the totals above.

- `/repos/phoenixml/xspec/test/as.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/atomic-value-eq.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/avt-ws.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/avt-ws_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/avt.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/avt_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/catch.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/catch_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/common-utils.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/compiler-saxon-config_absolute.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/compiler-saxon-config_relative.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/deep-equal.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/external_global-context_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/external_scenario-param-phase_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/external_scenario-param_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/external_x-context_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/focus-ignored-by-like.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/function-in-variable.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/global-override-query.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/helper.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/helper_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/issue-1020.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/issue-1564.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/issue-1618.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/issue-308.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/issue-396.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/issue-412.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/issue-438.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/issue-440.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/issue-441.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/issue-453.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/issue-453_local.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/issue-547.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/issue-59_query.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/issue-59_use-case-2.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/issue-777.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/line-number_disabled.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/line-number_enabled.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/multiple-filtered-items.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/multiple-filtered-items_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/nested-function-call.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/no-prefix.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/no-prefix_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/no-scenario.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/node-selection.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/param-position.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/pending-ignored-by-like.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/pending-scenario-features-inherited-by-focus.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/pending-shared-variable-inherited-by-focus.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/pending-variable-inherited-by-focus.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/prefix-conflict.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/prefix-conflict_local_xquery.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/prefix_parent-vs-import_xquery.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/report-sequence-array-map.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/report-sequence.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/report-sequence_query_schema-aware.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/report-sequence_xsd-1-0.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/result-type-matches.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-01.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-012.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-014.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-015.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-016.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-017.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-018.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-019.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-020.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-021.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-022.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-024.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-025.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-026.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-027.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-default-from.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-global-xspec-uri.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-param-001.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-parent.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-severity-01.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-severity-02.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-text.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/schematron-tvt-in-schema.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/threads_description_ignored_no-scenario.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/threads_description_ignored_not-supported.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/threads_description_ignored_one-scenario.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/threads_description_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/threads_scenario_ignored.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/threads_scenario_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/transform.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/tutorial_helper_ws-only-text_query.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/tutorial_namespaces_query.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/tutorial_under-the-hood_compilation-simple-suite.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/tutorial_under-the-hood_compilation-sut_function.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/tutorial_under-the-hood_compilation-variable.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/tvt-ws.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/tvt-ws_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/tvt.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/tvt_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/undeclare-ns.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/unfocused-function-call.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/unfocused-param.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/unfocused-shared-variable_inherited-by-focus.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/unfocused-shared-variable_not-inherited-by-focus.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/unfocused-variable_inherited-by-focus.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/unfocused-variable_not-inherited-by-focus.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/use-uqname.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/variable-like.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/variable-like_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/variable.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/variable_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/wrap.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/ws-only-text.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/x-context_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/xml-base.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/xmlns-imported_xquery.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/xmlns_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/xmlns_xquery.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/xquery-version_3.1.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/xquery-version_4.0.xspec`: XQuery suite (x:description/@query): this runner drives the XSLT engine only.
- `/repos/phoenixml/xspec/test/xslt4-schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/xspec-sch.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/xspec-uri.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.
- `/repos/phoenixml/xspec/test/xspec-uri_schematron.xspec`: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

## Per-suite detail

### `/repos/phoenixml/xspec/test/as.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/as_stylesheet.xspec`

- Stage: Complete
- Passed: 9, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/atomic-value-eq.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/avt-ws.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/avt-ws_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/avt-ws_stylesheet.xspec`

- Stage: Complete
- Passed: 6, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/avt.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/avt_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/avt_stylesheet.xspec`

- Stage: Complete
- Passed: 16, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/catch.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/catch_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/catch_stylesheet.xspec`

- Stage: Complete
- Passed: 18, Failed: 3, Pending: 3
  - FAIL: Enable @catch / named-scenario / without context / Error in SUT / err:line-number and its type
  - FAIL: Enable @catch / named-scenario / with context / Error in SUT / err:line-number and its type
  - FAIL: Enable @catch / matching-scenario / Error in SUT / err:line-number and its type

### `/repos/phoenixml/xspec/test/common-utils.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/compile-xproc-tests.xspec`

- Stage: Complete
- Passed: 19, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/compile-xslt-tests.xspec`

- Stage: Complete
- Passed: 5, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/compiler-eqname-utils.xspec`

- Stage: Complete
- Passed: 18, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/compiler-misc-utils.xspec`

- Stage: Complete
- Passed: 5, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/compiler-pending-utils.xspec`

- Stage: Complete
- Passed: 19, Failed: 6, Pending: 0
  - FAIL: Tests for 'stacked-explicit-pending' accumulator / Pending scenarios that use @pending and nest / Prior to start of Pending #2 scenario, accumulator still has only first pending reason
  - FAIL: Tests for 'stacked-explicit-pending' accumulator / Pending scenarios that use @pending and nest / At start of Pending #2 scenario, accumulator has second followed by first pending reason
  - FAIL: Tests for 'stacked-explicit-pending' accumulator / Pending scenarios that use @pending and nest / Inside Pending #2 scenario, accumulator still has second followed by first pending reason
  - FAIL: Tests for 'stacked-explicit-pending' accumulator / Pending scenarios that use @pending and nest / At end of Pending #2 scenario, accumulator has first pending reason
  - FAIL: Tests for 'stacked-explicit-pending' accumulator / Pending scenario that uses x:pending[@label] / At end of scenario inside x:pending[@label], accumulator still has pending reason
  - FAIL: Tests for 'stacked-explicit-pending' accumulator / Pending scenario that uses x:pending[x:label] / At end of scenario inside x:pending[x:label], accumulator still has pending reason

### `/repos/phoenixml/xspec/test/compiler-saxon-config_absolute.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/compiler-saxon-config_relative.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/compiler-sequencetype-with-uqnames.xspec`

- Stage: Complete
- Passed: 11, Failed: 1, Pending: 0
  - FAIL: Edge cases / Element has no @as attribute / returns an empty sequence

### `/repos/phoenixml/xspec/test/context-mode-ignored.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/context-param.xspec`

- Stage: Complete
- Passed: 6, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/declare-variable.xspec`

- Stage: Complete
- Passed: 2, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/deep-equal.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/default-mode-parent-runas-imported.xspec`

- Stage: Complete
- Passed: 3, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_as.xspec`

- Stage: Complete
- Passed: 5, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_as_stylesheet.xspec`

- Stage: Complete
- Passed: 10, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_avt-ws_stylesheet.xspec`

- Stage: Run
- Error code: XPTY0004
- Error: [file:///repos/phoenixml/xspec/test/external_avt-ws_stylesheet.xspec:4:61976] A sequence of 2 items is not allowed as argument 1 ($input) of tokenize(), which expects xs:string?

### `/repos/phoenixml/xspec/test/external_avt_stylesheet.xspec`

- Stage: Complete
- Passed: 14, Failed: 6, Pending: 0
  - FAIL: In context template-param, only user-content attribute is AVT. So... / In //x:context/x:param/node(), / attribute is AVT.
  - FAIL: In context template-param, only user-content attribute is AVT. So... / In //x:context/x:param/node(), / text node is intact.
  - FAIL: In context, only user-content attribute is AVT. So... / In //x:context/node(), / attribute is AVT.
  - FAIL: In context, only user-content attribute is AVT. So... / In //x:context/node(), / text node is intact.
  - FAIL: In template-call template-param, only user-content attribute is AVT. So... / In //x:call[@template]/x:param/node(), / attribute is AVT.
  - FAIL: In template-call template-param, only user-content attribute is AVT. So... / In //x:call[@template]/x:param/node(), / text node is intact.

### `/repos/phoenixml/xspec/test/external_catch_stylesheet.xspec`

- Stage: Run
- Error code: XPDY0050
- Error: Required cardinality of value treated as xs:string+ is one or more, but the sequence is empty

### `/repos/phoenixml/xspec/test/external_context-param.xspec`

- Stage: Complete
- Passed: 4, Failed: 2, Pending: 0
  - FAIL: When x:context has x:param and another child node, / setting up the context excludes x:param from the context nodes. So... / When templates are applied, / Only the non x:param nodes remain in the context nodes.
  - FAIL: When x:context has @href document containing x:param, / setting up the context does not affect @href document. So... / When a template is called, / The document is kept intact.

### `/repos/phoenixml/xspec/test/external_coverage-contents-table.xspec`

- Stage: Run
- Error code: XPTY0004
- Error: [file:///repos/phoenixml/xspec/src/reporter/coverage-report.xsl:67:24] An empty sequence is not allowed as argument 2 ($base) of resolve-uri(), which expects xs:string

### `/repos/phoenixml/xspec/test/external_default-mode-included-runas.xspec`

- Stage: Complete
- Passed: 2, Failed: 1, Pending: 0
  - FAIL: x:context[not(@mode)] / Uses xsl:template[not(@mode)]. transform() uses XSLT @default-mode as initial mode.

### `/repos/phoenixml/xspec/test/external_default-mode-parent.xspec`

- Stage: Complete
- Passed: 3, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_global-context_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/external_global-context_stylesheet.xspec`

- Stage: Run
- Error code: XPTY0004
- Error: [file:///repos/phoenixml/xspec/test/external_global-context_stylesheet.xspec:4:87625] An empty sequence is not allowed as argument 1 ($input) of filename-and-extension(), which expects xs:string

### `/repos/phoenixml/xspec/test/external_global-override.xspec`

- Stage: Complete
- Passed: 18, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_helper.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_issue-1020_stylesheet.xspec`

- Stage: Complete
- Passed: 33, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_issue-1564.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_issue-1564_stylesheet.xspec`

- Stage: Complete
- Passed: 3, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_multiple-context-items.xspec`

- Stage: Complete
- Passed: 2, Failed: 4, Pending: 0
  - FAIL: When x:context consists of multiple items / both node and atomic value / Calling a named template / should call the template once for each item in x:context
  - FAIL: When x:context consists of multiple items / both node and atomic value / Applying templates / should apply templates to all the items in x:context
  - FAIL: When x:context consists of multiple items / nodes / Calling a named template / should call the template once for each item in x:context
  - FAIL: When x:context consists of multiple items / nodes / Applying templates / should apply templates to all the items in x:context

### `/repos/phoenixml/xspec/test/external_multiple-context-items_function.xspec`

- Stage: Complete
- Passed: 1, Failed: 2, Pending: 0
  - FAIL: When x:context consists of multiple items / both node and atomic value / Calling a function should call the function once for each item in x:context as the global context item
  - FAIL: When x:context consists of multiple items / nodes / Calling a function should call the function once for each item in x:context as the global context item

### `/repos/phoenixml/xspec/test/external_nested-context.xspec`

- Stage: Complete
- Passed: 3, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_nested-function-call.xspec`

- Stage: Complete
- Passed: 6, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_nested-template-call.xspec`

- Stage: Complete
- Passed: 6, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_no-prefix_stylesheet.xspec`

- Stage: Complete
- Passed: 2, Failed: 2, Pending: 0
  - FAIL: Using URIQualifiedName in / context (@as | @select) / should be possible
  - FAIL: Using URIQualifiedName in / template-call @template and template-call template-param (@as | @name | @select) / should be possible

### `/repos/phoenixml/xspec/test/external_node-selection_stylesheet.xspec`

- Stage: Complete
- Passed: 10, Failed: 1, Pending: 0
  - FAIL: In context, @href precedes child node. / So... / In //x:context[node()][not(@href)], / child node is used.

### `/repos/phoenixml/xspec/test/external_non-node-context.xspec`

- Stage: Complete
- Passed: 2, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_param-position.xspec`

- Stage: Complete
- Passed: 4, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_pending-scenario-param-inherited-by-focus.xspec`

- Stage: Complete
- Passed: 2, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_pending-scenario-shared-param-inherited-by-focus.xspec`

- Stage: Complete
- Passed: 2, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_prefix-conflict_stylesheet.xspec`

- Stage: Complete
- Passed: 2, Failed: 4, Pending: 0
  - FAIL: Using x: prefix in / context child node / should work
  - FAIL: Using x: prefix in / context @select / should work
  - FAIL: Using x: prefix in / template-call @template, template-param @name, @select, @as, and child node / should work
  - FAIL: Using x: prefix in global-param @name, @select, @as, and child node / should work

### `/repos/phoenixml/xspec/test/external_scenario-param-phase_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/external_scenario-param-static-use-when.xspec`

- Stage: Complete
- Passed: 2, Failed: 4, Pending: 0
  - FAIL: Destination templates have @use-when depending on static parameter values / Description-level static param $A and / dependent scenario-level static param $B / String about negative $A and 1 for $B
  - FAIL: Destination templates have @use-when depending on static parameter values / Scenario-level static param $A and / non-overridden static param $B / 10 for $A and 0 for $B
  - FAIL: Destination templates have @use-when depending on static parameter values / Scenario-level static param $A and / independent scenario-level static param $B / 10 for $A and string about negative $B
  - FAIL: Destination templates have @use-when depending on static parameter values / Scenario-level static param $A and / dependent scenario-level static param $B / 10 for $A and 11 for $B

### `/repos/phoenixml/xspec/test/external_scenario-param.xspec`

- Stage: Run
- Error code: XPST0008
- Error: XPST0008: Variable $nonsense1 not defined

### `/repos/phoenixml/xspec/test/external_scenario-param_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/external_schut-to-xspec-for-xqs.xspec`

- Stage: Run
- Error code: FORG0002
- Error: The base URI '' is not a valid absolute URI

### `/repos/phoenixml/xspec/test/external_template-context.xspec`

- Stage: Complete
- Passed: 0, Failed: 2, Pending: 0
  - FAIL: Template context / apply-templates invocation / x:context/@select
  - FAIL: Template context / call-template invocation / x:context/@select

### `/repos/phoenixml/xspec/test/external_transform.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_tunnel-param.xspec`

- Stage: Complete
- Passed: 12, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_tutorial_global-context-item_original.xspec`

- Stage: Complete
- Passed: 1, Failed: 1, Pending: 0
  - FAIL: when no global context item is supplied / error description

### `/repos/phoenixml/xspec/test/external_tutorial_under-the-hood_compilation-params-scope.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_tutorial_under-the-hood_compilation-sut_template.xspec`

- Stage: Complete
- Passed: 3, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_tvt-ws_stylesheet.xspec`

- Stage: Complete
- Passed: 10, Failed: 7, Pending: 0
  - FAIL: scenario-level global-param / user-content / @expand-text=yes on x:param / Result of evaluating TVT for descendant text node does not preserve insignificant whitespace
  - FAIL: context template-param / user-content / @*:expand-text=yes within user-content / Result of evaluating TVT does not preserve insignificant whitespace
  - FAIL: context template-param / user-content / @expand-text=yes on x:param / Result of evaluating TVT for descendant text node does not preserve insignificant whitespace
  - FAIL: context / user-content / @expand-text=yes on x:context / Result of evaluating TVT for descendant text node does not preserve insignificant whitespace
  - FAIL: template-call template-param / user-content / @*:expand-text=yes within user-content / Result of evaluating TVT does not preserve insignificant whitespace
  - FAIL: template-call template-param / user-content / @expand-text=yes on x:param / Result of evaluating TVT for descendant text node does not preserve insignificant whitespace
  - FAIL: global-param / user-content / @expand-text=yes on x:param / Result of evaluating TVT for descendant text node does not preserve insignificant whitespace

### `/repos/phoenixml/xspec/test/external_tvt_stylesheet.xspec`

- Stage: Complete
- Passed: 18, Failed: 27, Pending: 0
  - FAIL: scenario-level global-param / user-content / @*:expand-text=yes within user-content / @x:expand-text=yes enables TVT
  - FAIL: scenario-level global-param / user-content / @*:expand-text=yes within user-content / @expand-text=yes does not enable TVT
  - FAIL: scenario-level global-param / user-content / @*:expand-text=yes within user-content / @expand-text is kept
  - FAIL: scenario-level global-param / user-content / @expand-text=yes on x:param / @expand-text=yes on x:* enables TVT for descendant text node
  - FAIL: context template-param / user-content / @*:expand-text=yes within user-content / @x:expand-text=yes enables TVT
  - FAIL: context template-param / user-content / @*:expand-text=yes within user-content / @expand-text=yes does not enable TVT
  - FAIL: context template-param / user-content / @*:expand-text=yes within user-content / @expand-text is kept
  - FAIL: context template-param / user-content / @expand-text=yes on x:param / @expand-text=yes on x:* enables TVT for descendant text node
  - FAIL: context template-param / @href / TVT is never enabled
  - FAIL: context template-param / @href / @x:expand-text is kept
  - FAIL: context template-param / @href / @expand-text is kept
  - FAIL: context / user-content / @*:expand-text=yes within user-content / @x:expand-text=yes enables TVT
  - FAIL: context / user-content / @*:expand-text=yes within user-content / @expand-text=yes does not enable TVT
  - FAIL: context / user-content / @*:expand-text=yes within user-content / @expand-text is kept
  - FAIL: context / user-content / @expand-text=yes on x:context / @expand-text=yes on x:* enables TVT for descendant text node
  - FAIL: template-call template-param / user-content / @*:expand-text=yes within user-content / @x:expand-text=yes enables TVT
  - FAIL: template-call template-param / user-content / @*:expand-text=yes within user-content / @expand-text=yes does not enable TVT
  - FAIL: template-call template-param / user-content / @*:expand-text=yes within user-content / @expand-text is kept
  - FAIL: template-call template-param / user-content / @expand-text=yes on x:param / @expand-text=yes on x:* enables TVT for descendant text node
  - FAIL: template-call template-param / @href / TVT is never enabled
  - FAIL: template-call template-param / @href / @x:expand-text is kept
  - FAIL: template-call template-param / @href / @expand-text is kept
  - FAIL: global-param / user-content / @*:expand-text=yes within user-content / @x:expand-text=yes enables TVT
  - FAIL: global-param / user-content / @*:expand-text=yes within user-content / @x:expand-text is discarded
  - FAIL: global-param / user-content / @*:expand-text=yes within user-content / @expand-text=yes does not enable TVT
  - FAIL: global-param / user-content / @*:expand-text=yes within user-content / @expand-text is kept
  - FAIL: global-param / user-content / @expand-text=yes on x:param / @expand-text=yes on x:* enables TVT for descendant text node

### `/repos/phoenixml/xspec/test/external_undeclare-ns_stylesheet.xspec`

- Stage: Complete
- Passed: 3, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_unfocused-param_inherited-by-focus.xspec`

- Stage: Complete
- Passed: 2, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_unfocused-param_not-inherited-by-focus.xspec`

- Stage: Run
- Error code: XPST0008
- Error: XPST0008: Variable $unfocused-scenario-param not defined

### `/repos/phoenixml/xspec/test/external_unfocused-shared-param_inherited-by-focus.xspec`

- Stage: Complete
- Passed: 2, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_unfocused-shared-param_not-inherited-by-focus.xspec`

- Stage: Run
- Error code: XPST0008
- Error: XPST0008: Variable $unfocused-scenario-param not defined

### `/repos/phoenixml/xspec/test/external_use-uqname_stylesheet.xspec`

- Stage: Complete
- Passed: 5, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_ws-only-text_stylesheet.xspec`

- Stage: Complete
- Passed: 12, Failed: 28, Pending: 0
  - FAIL: In scenario-level global-param, whitespace-only text nodes in user-content are removed by default. / But... / node-selection @href is always intact. So, in
					//x:scenario/x:param/@href[not(ancestor::element()/@xml:space)]/doc(.)[not(descendant::element()/@xml:space)], / whitespace-only text nodes are kept.
  - FAIL: In scenario-level global-param, whitespace-only text nodes in user-content are removed by default. / But... / Text nodes created by x:text are intact. So, in
					//x:scenario/x:param/x:text[not(ancestor-or-self::element()/@xml:space)], / whitespace-only text nodes are kept.
  - FAIL: In context template-param, whitespace-only text nodes in user-content are removed by default. / But... / @xml:space overrides the default. So, in
					//x:context/x:param/element()[ancestor-or-self::element()[@xml:space][1]/@xml:space
					= "preserve"], whitespace-only text nodes are kept. / (verified via $x:result)
  - FAIL: In context template-param, whitespace-only text nodes in user-content are removed by default. / But... / @xml:space overrides the default. So, in
					//x:context/x:param/element()[ancestor-or-self::element()[@xml:space][1]/@xml:space
					= "preserve"], whitespace-only text nodes are kept. / (verified via wrapper document)
  - FAIL: In context template-param, whitespace-only text nodes in user-content are removed by default. / But... / node-selection @href is always intact. So, in
					//x:context/x:param/@href[not(ancestor::element()/@xml:space)]/doc(.)[not(descendant::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via $x:result)
  - FAIL: In context template-param, whitespace-only text nodes in user-content are removed by default. / But... / node-selection @href is always intact. So, in
					//x:context/x:param/@href[not(ancestor::element()/@xml:space)]/doc(.)[not(descendant::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via wrapper document)
  - FAIL: In context template-param, whitespace-only text nodes in user-content are removed by default. / But... / Elements specified by @preserve-space are intact. So, in
					//x:context/x:param/element()[not(ancestor-or-self::element()/@xml:space)][node-name(.)
					= (for $qname in tokenize(/x:description/@preserve-space, '\s+') return
					resolve-QName($qname, /x:description))], whitespace-only text nodes are
					kept. / (verified via $x:result)
  - FAIL: In context template-param, whitespace-only text nodes in user-content are removed by default. / But... / Elements specified by @preserve-space are intact. So, in
					//x:context/x:param/element()[not(ancestor-or-self::element()/@xml:space)][node-name(.)
					= (for $qname in tokenize(/x:description/@preserve-space, '\s+') return
					resolve-QName($qname, /x:description))], whitespace-only text nodes are
					kept. / (verified via wrapper document)
  - FAIL: In context template-param, whitespace-only text nodes in user-content are removed by default. / But... / Text nodes created by x:text are intact. So, in
					//x:context/x:param/x:text[not(ancestor-or-self::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via $x:result)
  - FAIL: In context template-param, whitespace-only text nodes in user-content are removed by default. / But... / Text nodes created by x:text are intact. So, in
					//x:context/x:param/x:text[not(ancestor-or-self::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via wrapper document)
  - FAIL: In context, whitespace-only text nodes in user-content are removed by default. / But... / @xml:space overrides the default. So, in
					//x:context/element()[namespace-uri() ne
					'http://www.jenitennison.com/xslt/xspec'][ancestor-or-self::element()[@xml:space][1]/@xml:space
					= "preserve"], whitespace-only text nodes are kept. / (verified via $x:result)
  - FAIL: In context, whitespace-only text nodes in user-content are removed by default. / But... / @xml:space overrides the default. So, in
					//x:context/element()[namespace-uri() ne
					'http://www.jenitennison.com/xslt/xspec'][ancestor-or-self::element()[@xml:space][1]/@xml:space
					= "preserve"], whitespace-only text nodes are kept. / (verified via wrapper document)
  - FAIL: In context, whitespace-only text nodes in user-content are removed by default. / But... / node-selection @href is always intact. So, in
					//x:context/@href[not(ancestor::element()/@xml:space)]/doc(.)[not(descendant::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via $x:result)
  - FAIL: In context, whitespace-only text nodes in user-content are removed by default. / But... / node-selection @href is always intact. So, in
					//x:context/@href[not(ancestor::element()/@xml:space)]/doc(.)[not(descendant::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via wrapper document)
  - FAIL: In context, whitespace-only text nodes in user-content are removed by default. / But... / Elements specified by @preserve-space are intact. So, in
					//x:context/element()[not(ancestor-or-self::element()/@xml:space)][node-name(.)
					= (for $qname in tokenize(/x:description/@preserve-space, '\s+') return
					resolve-QName($qname, /x:description))], whitespace-only text nodes are
					kept. / (verified via $x:result)
  - FAIL: In context, whitespace-only text nodes in user-content are removed by default. / But... / Elements specified by @preserve-space are intact. So, in
					//x:context/element()[not(ancestor-or-self::element()/@xml:space)][node-name(.)
					= (for $qname in tokenize(/x:description/@preserve-space, '\s+') return
					resolve-QName($qname, /x:description))], whitespace-only text nodes are
					kept. / (verified via wrapper document)
  - FAIL: In context, whitespace-only text nodes in user-content are removed by default. / But... / Text nodes created by x:text are intact. So, in
					//x:context/x:text[not(ancestor-or-self::element()/@xml:space)], whitespace-only
					text nodes are kept. / (verified via $x:result)
  - FAIL: In context, whitespace-only text nodes in user-content are removed by default. / But... / Text nodes created by x:text are intact. So, in
					//x:context/x:text[not(ancestor-or-self::element()/@xml:space)], whitespace-only
					text nodes are kept. / (verified via wrapper document)
  - FAIL: In template-call template-param, whitespace-only text nodes in user-content are removed by default. / But... / @xml:space overrides the default. So, in
					//x:call[@template]/x:param/element()[ancestor-or-self::element()[@xml:space][1]/@xml:space
					= "preserve"], whitespace-only text nodes are kept. / (verified via $x:result)
  - FAIL: In template-call template-param, whitespace-only text nodes in user-content are removed by default. / But... / @xml:space overrides the default. So, in
					//x:call[@template]/x:param/element()[ancestor-or-self::element()[@xml:space][1]/@xml:space
					= "preserve"], whitespace-only text nodes are kept. / (verified via wrapper document)
  - FAIL: In template-call template-param, whitespace-only text nodes in user-content are removed by default. / But... / node-selection @href is always intact. So, in
					//x:call[@template]/x:param/@href[not(ancestor::element()/@xml:space)]/doc(.)[not(descendant::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via $x:result)
  - FAIL: In template-call template-param, whitespace-only text nodes in user-content are removed by default. / But... / node-selection @href is always intact. So, in
					//x:call[@template]/x:param/@href[not(ancestor::element()/@xml:space)]/doc(.)[not(descendant::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via wrapper document)
  - FAIL: In template-call template-param, whitespace-only text nodes in user-content are removed by default. / But... / Elements specified by @preserve-space are intact. So, in
					//x:call[@template]/x:param/element()[not(ancestor-or-self::element()/@xml:space)][node-name(.)
					= (for $qname in tokenize(/x:description/@preserve-space, '\s+') return
					resolve-QName($qname, /x:description))], whitespace-only text nodes are
					kept. / (verified via $x:result)
  - FAIL: In template-call template-param, whitespace-only text nodes in user-content are removed by default. / But... / Elements specified by @preserve-space are intact. So, in
					//x:call[@template]/x:param/element()[not(ancestor-or-self::element()/@xml:space)][node-name(.)
					= (for $qname in tokenize(/x:description/@preserve-space, '\s+') return
					resolve-QName($qname, /x:description))], whitespace-only text nodes are
					kept. / (verified via wrapper document)
  - FAIL: In template-call template-param, whitespace-only text nodes in user-content are removed by default. / But... / Text nodes created by x:text are intact. So, in
					//x:call[@template]/x:param/x:text[not(ancestor-or-self::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via $x:result)
  - FAIL: In template-call template-param, whitespace-only text nodes in user-content are removed by default. / But... / Text nodes created by x:text are intact. So, in
					//x:call[@template]/x:param/x:text[not(ancestor-or-self::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via wrapper document)
  - FAIL: In global-param, whitespace-only text nodes in user-content are removed by default. / But... / node-selection @href is always intact. So, in
					/x:description/x:param/@href[not(ancestor::element()/@xml:space)]/doc(.)[not(descendant::element()/@xml:space)], / whitespace-only text nodes are kept.
  - FAIL: In global-param, whitespace-only text nodes in user-content are removed by default. / But... / Text nodes created by x:text are intact. So, in
					/x:description/x:param/x:text[not(ancestor-or-self::element()/@xml:space)], / whitespace-only text nodes are kept.

### `/repos/phoenixml/xspec/test/external_x-context.xspec`

- Stage: Complete
- Passed: 86, Failed: 44, Pending: 0
  - FAIL: Node / Multiple / $x:context should be available in TVT within x:variable
  - FAIL: Node / Multiple / $x:context should be available in AVT within x:variable
  - FAIL: Node / Multiple / $x:context should be available in TVT within user content
  - FAIL: Node / Multiple / $x:context should be available in AVT within user content
  - FAIL: Node / Multiple / With template call inheriting the context / $x:context should be available in TVT within x:variable
  - FAIL: Node / Multiple / With template call inheriting the context / $x:context should be available in AVT within x:variable
  - FAIL: Node / Multiple / With template call inheriting the context / $x:context should be available in TVT within user content
  - FAIL: Node / Multiple / With template call inheriting the context / $x:context should be available in AVT within user content
  - FAIL: Mixture of nodes and atomic values / $x:context should be available in TVT within x:variable
  - FAIL: Mixture of nodes and atomic values / $x:context should be available in AVT within x:variable
  - FAIL: Mixture of nodes and atomic values / $x:context should be available in TVT within user content
  - FAIL: Mixture of nodes and atomic values / $x:context should be available in AVT within user content
  - FAIL: Mixture of nodes and atomic values / With template call inheriting the context / $x:context should be available in TVT within x:variable
  - FAIL: Mixture of nodes and atomic values / With template call inheriting the context / $x:context should be available in AVT within x:variable
  - FAIL: Mixture of nodes and atomic values / With template call inheriting the context / $x:context should be available in TVT within user content
  - FAIL: Mixture of nodes and atomic values / With template call inheriting the context / $x:context should be available in AVT within user content
  - FAIL: Inheritance / Parent has mode / and child has content / $x:context should be available in TVT within x:variable
  - FAIL: Inheritance / Parent has mode / and child has content / $x:context should be available in AVT within x:variable
  - FAIL: Inheritance / Parent has mode / and child has content / $x:context should be available in TVT within user content
  - FAIL: Inheritance / Parent has mode / and child has content / $x:context should be available in AVT within user content
  - FAIL: Inheritance / Parent has mode / and child has content / With template call inheriting the context / $x:context should be available in TVT within x:variable
  - FAIL: Inheritance / Parent has mode / and child has content / With template call inheriting the context / $x:context should be available in AVT within x:variable
  - FAIL: Inheritance / Parent has mode / and child has content / With template call inheriting the context / $x:context should be available in TVT within user content
  - FAIL: Inheritance / Parent has mode / and child has content / With template call inheriting the context / $x:context should be available in AVT within user content
  - FAIL: Inheritance / Parent has content / and child has mode / $x:context should be available in TVT within x:variable
  - FAIL: Inheritance / Parent has content / and child has mode / $x:context should be available in AVT within x:variable
  - FAIL: Inheritance / Parent has content / and child has mode / $x:context should be available in TVT within user content
  - FAIL: Inheritance / Parent has content / and child has mode / $x:context should be available in AVT within user content
  - FAIL: Inheritance / Parent has content / and child has mode / With template call inheriting the context / $x:context should be available in TVT within x:variable
  - FAIL: Inheritance / Parent has content / and child has mode / With template call inheriting the context / $x:context should be available in AVT within x:variable
  - FAIL: Inheritance / Parent has content / and child has mode / With template call inheriting the context / $x:context should be available in TVT within user content
  - FAIL: Inheritance / Parent has content / and child has mode / With template call inheriting the context / $x:context should be available in AVT within user content
  - FAIL: Inheritance / Parent has content / and child overrides the content / $x:context should be available in TVT within x:variable
  - FAIL: Inheritance / Parent has content / and child overrides the content / $x:context should be available in AVT within x:variable
  - FAIL: Inheritance / Parent has content / and child overrides the content / $x:context should be available in TVT within user content
  - FAIL: Inheritance / Parent has content / and child overrides the content / $x:context should be available in AVT within user content
  - FAIL: Inheritance / Parent has content / and child overrides the content / With template call inheriting the context / $x:context should be available in TVT within x:variable
  - FAIL: Inheritance / Parent has content / and child overrides the content / With template call inheriting the context / $x:context should be available in AVT within x:variable
  - FAIL: Inheritance / Parent has content / and child overrides the content / With template call inheriting the context / $x:context should be available in TVT within user content
  - FAIL: Inheritance / Parent has content / and child overrides the content / With template call inheriting the context / $x:context should be available in AVT within user content
  - FAIL: Template parameter / Parameter using $x:context in same scenario / Same items passed through parameter to result
  - FAIL: Template parameter / Parameter using $x:context in same scenario / Identical nodes passed through parameter to result
  - FAIL: Template parameter / Parent defines context / and child scenario defines parameter using $x:context / Same items passed through parameter to result
  - FAIL: Template parameter / Parent defines context / and child scenario defines parameter using $x:context / Identical nodes passed through parameter to result

### `/repos/phoenixml/xspec/test/external_x-context_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/external_xml-base_stylesheet.xspec`

- Stage: Complete
- Passed: 5, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_xmlns.xspec`

- Stage: Compile
- Error code: XTTE0505
- Error: XTTE0505: Template match="like" return value item of type String does not match declared type Element; value="<x:expect xmlns:_pxbase_="http://phoenixmldb/internal/base-uri" _pxbase_:base="f…"

### `/repos/phoenixml/xspec/test/external_xsl-result-document_has-href.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_xsl-result-document_no-href.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_xslt-package_arith.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_xslt-package_arith_private.xspec`

- Stage: Complete
- Passed: 2, Failed: 1, Pending: 0
  - FAIL: Calling an always-private function in the package / due to private visibility

### `/repos/phoenixml/xspec/test/external_xslt-package_arith_use-1.xspec`

- Stage: Complete
- Passed: 0, Failed: 1, Pending: 0
  - FAIL: Calling a named template in the main stylesheet which uses a package / should return the expected text

### `/repos/phoenixml/xspec/test/external_xslt-package_arith_use-2.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_xslt-package_filter.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_xslt-package_filter_use.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/external_xslt-package_filter_use_static-param.xspec`

- Stage: Complete
- Passed: 0, Failed: 2, Pending: 0
  - FAIL: With a custom filter specified by a static param / The custom filter should take effect
  - FAIL: With a different custom filter specified by another static param / The different custom filter should take effect

### `/repos/phoenixml/xspec/test/external_xslt4.xspec`

- Stage: Complete
- Passed: 2, Failed: 1, Pending: 0
  - FAIL: XSLT 4.0 xsl:switch instruction / Compiled stylesheet has version=4.0

### `/repos/phoenixml/xspec/test/focus-ignored-by-like.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/format-utils.xspec`

- Stage: Complete
- Passed: 10, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/function-in-variable.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/generate-node-selector.xspec`

- Stage: Complete
- Passed: 4, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/generate-pipeline.xspec`

- Stage: Complete
- Passed: 7, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/generate-step3-wrapper_custom.xspec`

- Stage: Run
- Error code: XTDE0540
- Error: XTDE0540: Multiple template rules match text node in mode 'x:gather-specs' with on-multiple-match='fail' — match="description/node()" (priority 0.5, precedence 0) and match="text()" (priority 0.5, precedence 0) have the same priority

### `/repos/phoenixml/xspec/test/generate-step3-wrapper_default.xspec`

- Stage: Run
- Error code: XTDE0540
- Error: XTDE0540: Multiple template rules match text node in mode 'x:gather-specs' with on-multiple-match='fail' — match="description/node()" (priority 0.5, precedence 0) and match="text()" (priority 0.5, precedence 0) have the same priority

### `/repos/phoenixml/xspec/test/generate-test-case-step-catch.xspec`

- Stage: Complete
- Passed: 2, Failed: 1, Pending: 0
  - FAIL: Tests for test-case-step-based-on-x-call template / Sample x:call for a step in a scenario with catch='yes' / This step invokes the test target step within p:try.

### `/repos/phoenixml/xspec/test/generate-test-case-step.xspec`

- Stage: Complete
- Passed: 15, Failed: 3, Pending: 0
  - FAIL: Tests for test-case-step-based-on-x-call template / Sample x:call for a step / The step uses p:count and p:choose to create maps of documents at out1 and
                    out2, accounting for the case of zero documents on a given port,
  - FAIL: Tests for test-case-step-based-on-x-call template / Sample x:call for a step / Entire step element matches the expected one.
  - FAIL: Details about mode=in-p-document / Whitespace within p:pipeinfo element / is preserved (XSpec can't tell if it's significant)

### `/repos/phoenixml/xspec/test/generate-xproc-imports.xspec`

- Stage: Run
- Error code: FODC0002
- Error: No document could be retrieved for URI 'catalog-01:/helper.xpl'

### `/repos/phoenixml/xspec/test/get-step-declaration.xspec`

- Stage: Complete
- Passed: 16, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/global-override-query.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/global-override.xspec`

- Stage: Complete
- Passed: 13, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/helper.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/helper_override.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/helper_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/helper_xslt-package.xspec`

- Stage: Run
- Error code: XTSE3000
- Error: XTSE3000: Package 'http://example.org/complex-arithmetic.xsl' not found

### `/repos/phoenixml/xspec/test/issue-1020.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/issue-1020_stylesheet.xspec`

- Stage: Complete
- Passed: 28, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-1029.xspec`

- Stage: Complete
- Passed: 12, Failed: 6, Pending: 0
  - FAIL: catch=yes with xsl:message[@terminate=yes] in xsl:function / [@as=xs:integer] / should catch its message body
  - FAIL: catch=yes with xsl:message[@terminate=yes] in xsl:function / [empty(@as)] / should catch its message body
  - FAIL: catch=yes with xsl:message[@terminate=yes] in calling xsl:template / [@as=xs:integer] / should catch its message body
  - FAIL: catch=yes with xsl:message[@terminate=yes] in calling xsl:template / [empty(@as)] / should catch its message body
  - FAIL: catch=yes with xsl:message[@terminate=yes] in matching xsl:template / [@as=xs:integer] / should catch its message body
  - FAIL: catch=yes with xsl:message[@terminate=yes] in matching xsl:template / [empty(@as)] / should catch its message body

### `/repos/phoenixml/xspec/test/issue-1135.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-1564.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/issue-1564_stylesheet.xspec`

- Stage: Complete
- Passed: 3, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-1618.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/issue-215.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-23_1.xspec`

- Stage: Complete
- Passed: 2, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-26.xspec`

- Stage: Complete
- Passed: 2, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-30.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-308.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/issue-33.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-396.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/issue-412.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/issue-438.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/issue-440.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/issue-441.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/issue-453.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/issue-453_local.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/issue-46.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-47.xspec`

- Stage: Complete
- Passed: 3, Failed: 5, Pending: 0
  - FAIL: Set context in *:foo / Inspect via $x:result / Attribute value consists of three tokens
  - FAIL: Set context in *:foo / Inspect via $x:result / One of the tokens is 'Alpha'
  - FAIL: Set context in *:foo / Inspect via a wrapper document node / Attribute value consists of three tokens
  - FAIL: Set context in *:foo / Inspect via a wrapper document node / One of the tokens is 'Alpha'
  - FAIL: wrap:wrap-nodes / Type annotations are kept

### `/repos/phoenixml/xspec/test/issue-538.xspec`

- Stage: Complete
- Passed: 5, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-547.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/issue-59_query.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/issue-59_stylesheet.xspec`

- Stage: Complete
- Passed: 23, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-59_use-case-1.xspec`

- Stage: Complete
- Passed: 2, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-59_use-case-2.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/issue-638.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-700.xspec`

- Stage: Complete
- Passed: 1, Failed: 1, Pending: 0
  - FAIL: Aborts with abbreviation with no expansion / err:value should contain xsl:message body

### `/repos/phoenixml/xspec/test/issue-746.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-777.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/issue-777_stylesheet.xspec`

- Stage: Complete
- Passed: 2, Failed: 2, Pending: 0
  - FAIL: 
			When
			- x:param in XSpec defines $my:test
			- xsl:variable in SUT defines $my:test-doc and $my:test-doc-uri
		
  - FAIL: 
			When
			- x:param in XSpec defines $my:test
			- xsl:variable in SUT defines $my:test-doc and $my:test-doc-uri
		

### `/repos/phoenixml/xspec/test/issue-826.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-987_child.xspec`

- Stage: Complete
- Passed: 2, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/issue-987_parent.xspec`

- Stage: Complete
- Passed: 2, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/line-number_disabled.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/line-number_enabled.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/multiple-context-items.xspec`

- Stage: Complete
- Passed: 6, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/multiple-filtered-items.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/multiple-filtered-items_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/namespace-vars.xspec`

- Stage: Complete
- Passed: 4, Failed: 1, Pending: 0
  - FAIL: Scenario for testing variable xsl-namespace / xs:anyURI of 'xsl' namespace URI

### `/repos/phoenixml/xspec/test/nested-context.xspec`

- Stage: Complete
- Passed: 3, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/nested-function-call.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/nested-template-call.xspec`

- Stage: Complete
- Passed: 6, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/no-prefix.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/no-prefix_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/no-prefix_stylesheet.xspec`

- Stage: Complete
- Passed: 3, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/no-scenario.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/node-selection.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/node-selection_stylesheet.xspec`

- Stage: Complete
- Passed: 9, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/non-node-context.xspec`

- Stage: Complete
- Passed: 2, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/param-position-implicit-explicit.xspec`

- Stage: Complete
- Passed: 0, Failed: 2, Pending: 0
  - FAIL: x:call[@function] whose parameters omit and then specify @position / should raise a compiler error
  - FAIL: x:call[@function] whose parameters specify and then omit @position / should raise a compiler error

### `/repos/phoenixml/xspec/test/param-position-implicit-explicit_stylesheet.xspec`

- Stage: Complete
- Passed: 0, Failed: 2, Pending: 0
  - FAIL: x:call[@function] whose parameters omit and then specify @position / should raise a compiler error
  - FAIL: x:call[@function] whose parameters specify and then omit @position / should raise a compiler error

### `/repos/phoenixml/xspec/test/param-position.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/pending-ignored-by-like.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/pending-scenario-features-inherited-by-focus.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/pending-shared-variable-inherited-by-focus.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/pending-variable-inherited-by-focus.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/prefix-conflict.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/prefix-conflict_local_stylesheet.xspec`

- Stage: Complete
- Passed: 4, Failed: 2, Pending: 0
  - FAIL: Using x: prefix in global-param @name, @select, @as, and child node / should work
  - FAIL: Using x: prefix in global variable @name, @select, @as, and child node / should work

### `/repos/phoenixml/xspec/test/prefix-conflict_local_xquery.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/prefix-conflict_stylesheet.xspec`

- Stage: Complete
- Passed: 4, Failed: 1, Pending: 0
  - FAIL: Using x: prefix in global-param @name, @select, @as, and child node / should work

### `/repos/phoenixml/xspec/test/prefix_parent-vs-import_stylesheet.xspec`

- Stage: Complete
- Passed: 8, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/prefix_parent-vs-import_xquery.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/report-sequence-array-map.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/report-sequence.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/report-sequence_query_schema-aware.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/report-sequence_stylesheet.xspec`

- Stage: Complete
- Passed: 4, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/report-sequence_stylesheet_hof.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/report-sequence_stylesheet_schema-aware.xspec`

- Stage: Run
- Error code: XPST0017
- Error: Function pictype not found

### `/repos/phoenixml/xspec/test/report-sequence_xsd-1-0.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/result-type-matches.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-01.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-012.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-014.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-015.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-016.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-017.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-018.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-019.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-020.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-021.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-022.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-024.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-025.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-026.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-027.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-default-from.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-global-xspec-uri.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-param-001.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-parent.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-severity-01.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-severity-02.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-text.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schematron-tvt-in-schema.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/schut-to-xslt.xspec`

- Stage: Run
- Error code: FODC0002
- Error: No document could be retrieved for URI 'catalog-01:/example.xml'

### `/repos/phoenixml/xspec/test/schut-to-xspec-compat.xspec`

- Stage: Complete
- Passed: 0, Failed: 1, Pending: 0
  - FAIL: assertions / With skeleton and SchXslt, expect/@test uses first preceding sibling for
                svrl:fired-rule and svrl:active-pattern. The @ruleId and @patternId attributes are
                not present.

### `/repos/phoenixml/xspec/test/schut-to-xspec.xspec`

- Stage: Complete
- Passed: 12, Failed: 5, Pending: 0
  - FAIL: templates / identity / copied, with significant text nodes wrapped in x:text
  - FAIL: scenario / pending / pending scenarios
  - FAIL: scenario / shared / shared scenarios
  - FAIL: context / inline with select / wrapper document node via wrap:wrap-nodes
  - FAIL: assertions / expect elements with correct label and test

### `/repos/phoenixml/xspec/test/select-node.xspec`

- Stage: Complete
- Passed: 4, Failed: 10, Pending: 0
  - FAIL: No namespaces / Select exact / Selected
  - FAIL: No namespaces / Select without [1] / Selected
  - FAIL: No namespaces / Select without leading / / Selected
  - FAIL: With namespaces / Select by prefixes / Selected
  - FAIL: With namespaces / Select by typeical SVRL XPath 1.0 / Selected
  - FAIL: With namespaces / Select by typical SVRL XPath 2.0 / Selected
  - FAIL: Select attribute / Not in namespace / Selected
  - FAIL: Select attribute / In namespace / Select by prefixes / Selected
  - FAIL: Select attribute / In namespace / Select by typical SVRL XPath 2.0 / Selected
  - FAIL: URIQualifiedName / SchXslt v1.4.6 / https://github.com/xspec/xspec/wiki/Testing-Schematron-with-Text-Nodes#using-another-implementation-of-schematron / Selected

### `/repos/phoenixml/xspec/test/selection-from-doc-xproc.xspec`

- Stage: Complete
- Passed: 13, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/template-context.xspec`

- Stage: Complete
- Passed: 2, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/test-helper-documents.xspec`

- Stage: Complete
- Passed: 25, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/test-utils.xspec`

- Stage: Complete
- Passed: 26, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/threads_description_ignored_no-scenario.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/threads_description_ignored_not-supported.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/threads_description_ignored_one-scenario.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/threads_description_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/threads_description_stylesheet.xspec`

- Stage: Compile
- Error code: FONS0004
- Error: Prefix 'sleeper' is not declared in the in-scope namespaces

### `/repos/phoenixml/xspec/test/threads_scenario_ignored.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/threads_scenario_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/threads_scenario_stylesheet.xspec`

- Stage: Compile
- Error code: FONS0004
- Error: Prefix 'sleeper' is not declared in the in-scope namespaces

### `/repos/phoenixml/xspec/test/transform-options.xspec`

- Stage: Complete
- Passed: 2, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/transform.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/trim.xspec`

- Stage: Complete
- Passed: 3, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/tunnel-param.xspec`

- Stage: Complete
- Passed: 12, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/tutorial_global-context-item_testable.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/tutorial_helper_ws-only-text_query.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/tutorial_helper_ws-only-text_stylesheet.xspec`

- Stage: Run
- Error code: XTDE0540
- Error: XTDE0540: Multiple template rules match document node in mode 'local:report-node' with on-multiple-match='fail' — match="/" (priority -0.5, precedence 0) and match="/" (priority -0.5, precedence 0) have the same priority

### `/repos/phoenixml/xspec/test/tutorial_namespaces_query.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/tutorial_namespaces_stylesheet.xspec`

- Stage: Complete
- Passed: 6, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/tutorial_under-the-hood_compilation-simple-suite.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/tutorial_under-the-hood_compilation-sut_function.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/tutorial_under-the-hood_compilation-sut_template.xspec`

- Stage: Complete
- Passed: 3, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/tutorial_under-the-hood_compilation-variable.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/tvt-ws.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/tvt-ws_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/tvt-ws_stylesheet.xspec`

- Stage: Complete
- Passed: 14, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/tvt.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/tvt_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/tvt_stylesheet.xspec`

- Stage: Complete
- Passed: 36, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/undeclare-ns.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/undeclare-ns_stylesheet.xspec`

- Stage: Complete
- Passed: 12, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/unfocused-context.xspec`

- Stage: Run
- Error code: XPST0008
- Error: XPST0008: Variable $context not defined

### `/repos/phoenixml/xspec/test/unfocused-function-call.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/unfocused-param.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/unfocused-shared-variable_inherited-by-focus.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/unfocused-shared-variable_not-inherited-by-focus.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/unfocused-template-call.xspec`

- Stage: Complete
- Passed: 1, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/unfocused-variable_inherited-by-focus.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/unfocused-variable_not-inherited-by-focus.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/uqname-utils.xspec`

- Stage: Complete
- Passed: 26, Failed: 1, Pending: 0
  - FAIL: Scenario for testing function node-UQName / Namespace / Not default namespace / URIQualifiedName without namespace URI

### `/repos/phoenixml/xspec/test/uri-utils.xspec`

- Stage: Run
- Error code: FODC0002
- Error: No document could be retrieved for URI 'catalog-01:/example.xml'

### `/repos/phoenixml/xspec/test/use-uqname.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/use-uqname_stylesheet.xspec`

- Stage: Complete
- Passed: 4, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/user-content-utils.xspec`

- Stage: Complete
- Passed: 65, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/variable-like.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/variable-like_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/variable-like_stylesheet.xspec`

- Stage: Complete
- Passed: 9, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/variable.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/variable_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/variable_stylesheet.xspec`

- Stage: Complete
- Passed: 13, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/version-utils.xspec`

- Stage: Run
- Error code: XTMM9000
- Error: XTMM9000: Transformation terminated: ERROR in x:expect ('Scenario for testing variable saxon-version Assume we test this on Saxon versions from 11.7 to 13.x Greater than or equal to 11.7'): Non-boolean @test must be accompanied by @as, @href, @select, or child node.

### `/repos/phoenixml/xspec/test/wrap.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/wrap_stylesheet.xspec`

- Stage: Complete
- Passed: 3, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/ws-only-text.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/ws-only-text_stylesheet.xspec`

- Stage: Complete
- Passed: 21, Failed: 14, Pending: 0
  - FAIL: In context template-param, whitespace-only text nodes in user-content are removed by default. / But... / node-selection @href is always intact. So, in
					//x:context/x:param/@href[not(ancestor::element()/@xml:space)]/doc(.)[not(descendant::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via $x:result)
  - FAIL: In context template-param, whitespace-only text nodes in user-content are removed by default. / But... / node-selection @href is always intact. So, in
					//x:context/x:param/@href[not(ancestor::element()/@xml:space)]/doc(.)[not(descendant::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via wrapper document)
  - FAIL: In context template-param, whitespace-only text nodes in user-content are removed by default. / But... / Text nodes created by x:text are intact. So, in
					//x:context/x:param/x:text[not(ancestor-or-self::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via $x:result)
  - FAIL: In context template-param, whitespace-only text nodes in user-content are removed by default. / But... / Text nodes created by x:text are intact. So, in
					//x:context/x:param/x:text[not(ancestor-or-self::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via wrapper document)
  - FAIL: In context, whitespace-only text nodes in user-content are removed by default. / But... / node-selection @href is always intact. So, in
					//x:context/@href[not(ancestor::element()/@xml:space)]/doc(.)[not(descendant::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via $x:result)
  - FAIL: In context, whitespace-only text nodes in user-content are removed by default. / But... / node-selection @href is always intact. So, in
					//x:context/@href[not(ancestor::element()/@xml:space)]/doc(.)[not(descendant::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via wrapper document)
  - FAIL: In context, whitespace-only text nodes in user-content are removed by default. / But... / Text nodes created by x:text are intact. So, in
					//x:context/x:text[not(ancestor-or-self::element()/@xml:space)], whitespace-only
					text nodes are kept. / (verified via $x:result)
  - FAIL: In context, whitespace-only text nodes in user-content are removed by default. / But... / Text nodes created by x:text are intact. So, in
					//x:context/x:text[not(ancestor-or-self::element()/@xml:space)], whitespace-only
					text nodes are kept. / (verified via wrapper document)
  - FAIL: In template-call template-param, whitespace-only text nodes in user-content are removed by default. / But... / node-selection @href is always intact. So, in
					//x:call[@template]/x:param/@href[not(ancestor::element()/@xml:space)]/doc(.)[not(descendant::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via $x:result)
  - FAIL: In template-call template-param, whitespace-only text nodes in user-content are removed by default. / But... / node-selection @href is always intact. So, in
					//x:call[@template]/x:param/@href[not(ancestor::element()/@xml:space)]/doc(.)[not(descendant::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via wrapper document)
  - FAIL: In template-call template-param, whitespace-only text nodes in user-content are removed by default. / But... / Text nodes created by x:text are intact. So, in
					//x:call[@template]/x:param/x:text[not(ancestor-or-self::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via $x:result)
  - FAIL: In template-call template-param, whitespace-only text nodes in user-content are removed by default. / But... / Text nodes created by x:text are intact. So, in
					//x:call[@template]/x:param/x:text[not(ancestor-or-self::element()/@xml:space)],
					whitespace-only text nodes are kept. / (verified via wrapper document)
  - FAIL: In global-param, whitespace-only text nodes in user-content are removed by default. / But... / node-selection @href is always intact. So, in
					/x:description/x:param/@href[not(ancestor::element()/@xml:space)]/doc(.)[not(descendant::element()/@xml:space)], / whitespace-only text nodes are kept.
  - FAIL: In global-param, whitespace-only text nodes in user-content are removed by default. / But... / Text nodes created by x:text are intact. So, in
					/x:description/x:param/x:text[not(ancestor-or-self::element()/@xml:space)], / whitespace-only text nodes are kept.

### `/repos/phoenixml/xspec/test/x-context.xspec`

- Stage: Complete
- Passed: 90, Failed: 40, Pending: 0
  - FAIL: Node / Multiple / $x:context should be available in TVT within x:variable
  - FAIL: Node / Multiple / $x:context should be available in AVT within x:variable
  - FAIL: Node / Multiple / $x:context should be available in TVT within user content
  - FAIL: Node / Multiple / $x:context should be available in AVT within user content
  - FAIL: Node / Multiple / With template call inheriting the context / $x:context should be available in TVT within x:variable
  - FAIL: Node / Multiple / With template call inheriting the context / $x:context should be available in AVT within x:variable
  - FAIL: Node / Multiple / With template call inheriting the context / $x:context should be available in TVT within user content
  - FAIL: Node / Multiple / With template call inheriting the context / $x:context should be available in AVT within user content
  - FAIL: Mixture of nodes and atomic values / $x:context should be available in TVT within x:variable
  - FAIL: Mixture of nodes and atomic values / $x:context should be available in AVT within x:variable
  - FAIL: Mixture of nodes and atomic values / $x:context should be available in TVT within user content
  - FAIL: Mixture of nodes and atomic values / $x:context should be available in AVT within user content
  - FAIL: Mixture of nodes and atomic values / With template call inheriting the context / $x:context should be available in TVT within x:variable
  - FAIL: Mixture of nodes and atomic values / With template call inheriting the context / $x:context should be available in AVT within x:variable
  - FAIL: Mixture of nodes and atomic values / With template call inheriting the context / $x:context should be available in TVT within user content
  - FAIL: Mixture of nodes and atomic values / With template call inheriting the context / $x:context should be available in AVT within user content
  - FAIL: Inheritance / Parent has mode / and child has content / $x:context should be available in TVT within x:variable
  - FAIL: Inheritance / Parent has mode / and child has content / $x:context should be available in AVT within x:variable
  - FAIL: Inheritance / Parent has mode / and child has content / $x:context should be available in TVT within user content
  - FAIL: Inheritance / Parent has mode / and child has content / $x:context should be available in AVT within user content
  - FAIL: Inheritance / Parent has mode / and child has content / With template call inheriting the context / $x:context should be available in TVT within x:variable
  - FAIL: Inheritance / Parent has mode / and child has content / With template call inheriting the context / $x:context should be available in AVT within x:variable
  - FAIL: Inheritance / Parent has mode / and child has content / With template call inheriting the context / $x:context should be available in TVT within user content
  - FAIL: Inheritance / Parent has mode / and child has content / With template call inheriting the context / $x:context should be available in AVT within user content
  - FAIL: Inheritance / Parent has content / and child has mode / $x:context should be available in TVT within x:variable
  - FAIL: Inheritance / Parent has content / and child has mode / $x:context should be available in AVT within x:variable
  - FAIL: Inheritance / Parent has content / and child has mode / $x:context should be available in TVT within user content
  - FAIL: Inheritance / Parent has content / and child has mode / $x:context should be available in AVT within user content
  - FAIL: Inheritance / Parent has content / and child has mode / With template call inheriting the context / $x:context should be available in TVT within x:variable
  - FAIL: Inheritance / Parent has content / and child has mode / With template call inheriting the context / $x:context should be available in AVT within x:variable
  - FAIL: Inheritance / Parent has content / and child has mode / With template call inheriting the context / $x:context should be available in TVT within user content
  - FAIL: Inheritance / Parent has content / and child has mode / With template call inheriting the context / $x:context should be available in AVT within user content
  - FAIL: Inheritance / Parent has content / and child overrides the content / $x:context should be available in TVT within x:variable
  - FAIL: Inheritance / Parent has content / and child overrides the content / $x:context should be available in AVT within x:variable
  - FAIL: Inheritance / Parent has content / and child overrides the content / $x:context should be available in TVT within user content
  - FAIL: Inheritance / Parent has content / and child overrides the content / $x:context should be available in AVT within user content
  - FAIL: Inheritance / Parent has content / and child overrides the content / With template call inheriting the context / $x:context should be available in TVT within x:variable
  - FAIL: Inheritance / Parent has content / and child overrides the content / With template call inheriting the context / $x:context should be available in AVT within x:variable
  - FAIL: Inheritance / Parent has content / and child overrides the content / With template call inheriting the context / $x:context should be available in TVT within user content
  - FAIL: Inheritance / Parent has content / and child overrides the content / With template call inheriting the context / $x:context should be available in AVT within user content

### `/repos/phoenixml/xspec/test/x-context_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/xml-base.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/xml-base_stylesheet.xspec`

- Stage: Complete
- Passed: 4, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/xmlns-imported_stylesheet.xspec`

- Stage: Complete
- Passed: 8, Failed: 0, Pending: 0

### `/repos/phoenixml/xspec/test/xmlns-imported_xquery.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/xmlns_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/xmlns_stylesheet.xspec`

- Stage: Compile
- Error code: XTTE0505
- Error: XTTE0505: Template match="like" return value item of type String does not match declared type Element; value="<x:expect xmlns:_pxbase_="http://phoenixmldb/internal/base-uri" _pxbase_:base="f…"

### `/repos/phoenixml/xspec/test/xmlns_xquery.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/xquery-version_3.1.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/xquery-version_4.0.xspec`

- Stage: Skipped
- Skip reason: XQuery suite (x:description/@query): this runner drives the XSLT engine only.

### `/repos/phoenixml/xspec/test/xsl-result-document.xspec`

- Stage: Complete
- Passed: 2, Failed: 4, Pending: 0
  - FAIL: Calling a template containing xsl:result-document / [@href] / description
  - FAIL: Calling a template containing xsl:result-document / [@href] / line-number
  - FAIL: Calling a template containing xsl:result-document / [empty(@href)] / description
  - FAIL: Calling a template containing xsl:result-document / [empty(@href)] / line-number

### `/repos/phoenixml/xspec/test/xslt1.xspec`

- Stage: Complete
- Passed: 6, Failed: 1, Pending: 0
  - FAIL: With 2 text nodes / xslt-version=1.0 in this XSpec file should make this scenario Success when this
				XSpec file is executed independently. On the other hand, the result should be
				Failure when this XSpec file is imported to another XSpec file which has
				xslt-version=2.0 or higher. / Expecting the compiled stylesheet to have version=1.0

### `/repos/phoenixml/xspec/test/xslt3.xspec`

- Stage: Complete
- Passed: 1, Failed: 1, Pending: 0
  - FAIL: When testing the let expression in XPath 3.0 / the compiled stylesheet has version=3.0

### `/repos/phoenixml/xspec/test/xslt4-schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/xslt4.xspec`

- Stage: Complete
- Passed: 2, Failed: 1, Pending: 0
  - FAIL: XSLT 4.0 xsl:switch instruction / Compiled stylesheet has version=4.0

### `/repos/phoenixml/xspec/test/xspec-name.xspec`

- Stage: Complete
- Passed: 8, Failed: 2, Pending: 0
  - FAIL: Scenario for testing function xspec-name / Element name is not in XSpec namespace / Element name uses the default namespace / No XSpec prefixes / Error (description)
  - FAIL: Scenario for testing function xspec-name / Element name is not in XSpec namespace / Element name uses a prefix / No XSpec prefixes / Error (description)

### `/repos/phoenixml/xspec/test/xspec-sch.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/xspec-uri.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/xspec-uri_schematron.xspec`

- Stage: Skipped
- Skip reason: Schematron suite (x:description/@schematron): needs XSpec's vendored schxslt2 + XQS pipeline, which this runner does not carry.

### `/repos/phoenixml/xspec/test/xspec-uri_stylesheet.xspec`

- Stage: Run
- Error code: XPTY0004
- Error: Function anonymous(): argument 1 of type String does not match required type xs:anyURI

### `/repos/phoenixml/xspec/test/yes-no-utils.xspec`

- Stage: Complete
- Passed: 14, Failed: 0, Pending: 0


