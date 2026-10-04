# High DPI Work — Status Summary (2026-09-24)

Handover document for the fork's work on paolosalvatori/ServiceBusExplorer#440.
Read this together with `.github/copilot-instructions.md` (project/fork overview, monitor test matrix).

## Decision (LOCKED): PerMonitorV2

- Chosen over `system` awareness after 10 test rounds on the shared monitor matrix (4K@150%, 4K@100%, FullHD@100%).
- `system` awareness renders at the *system* DPI (primary monitor's scale at logon) and Windows bitmap-scales the window on every other monitor → that softness is the blur behind revert #807, reproduced with log evidence (`DeviceDpi=144` reported on a 96-DPI FullHD monitor).
- PMv2 renders natively per monitor and is migration-forward (.NET 6+ invests in PMv2; note modern .NET still defaults to `SystemAware`, semantically the same as net472 `system`).
- Cost: PMv2 on net472 needs custom DPI-change handling — the framework auto-rescale does not cover this app's custom-painted controls (Grouper, HeaderPanel, strips).
- Declared in `src/ServiceBusExplorer/app.manifest` (PerMonitorV2 block active) + `App.config` (`DpiAwareness=PerMonitorV2`).
- **Required pairing**: `AutoScaleMode.Dpi` with `AutoScaleDimensions = 96F, 96F` (flipped globally, commit `49af677`) + `EnableWindowsFormsHighDpiAutoResizing=true`. All three keys must live in `<System.Windows.Forms.ApplicationConfigurationSection>` in App.config — WinForms **silently ignores them in `appSettings`** (the same ineffective placement PR #797 had). `AutoScaleMode.Font` is non-linear across DPI changes — do not use.

## Layer plan (9 stacked layers → sequential upstream PRs, one at a time)

| Layer | Content | Old-branch commits (high-dpi-commits) |
|---|---|---|
| 440-1-foundation | PMv2 manifest/config, DpiAwareForm, MainForm/ConnectForm/dialogs, HeaderPanel, Grouper arc, TreeView ItemHeight | 1–8, 37–38, d18235a (adapted) |
| 440-2-handle-controls | Handle* controls + TimeSpanControl + list view headers | 9–18 |
| 440-3-helpers | ListViewHelper, AuthorizationRulesDataGridViewHelper, TreeView check, TextForm | 19–24 |
| 440-4-tab-control | TabControlHelper + tab header fixes (6bfe318 touches only OptionForm.Designer.cs) | 26–29 |
| 440-5-grouper-splitter | Grouper CustomPaint + SplitterDistance + MessageForm | 30–33 |
| 440-6-list-treeview | CheckBoxList spacing + remaining TreeView ItemHeight | 34–35 |
| 440-7-test-topic | TestTopicControl TableLayoutPanels + chart + listview | 39–46 |
| 440-8-test-queue | TestQueueControl ports + TableLayoutPanels | 47, 50–52 |
| 440-9-listener | ListenerControl + ContainerForm listener windows | 48–49 |

Do NOT blind cherry-pick: the 2024 base is far behind current `main` (Dashboard tab, TreeView filter box, and the entire Event Grid feature are new since 2024 and have zero High DPI coverage — test them on every layer). Merge commits 25/33/36 are dropped.

## 440-1-foundation — current branch (12 commits on top of fork-tooling)

| Commit | Content |
|---|---|
| `ec0f3bd` | PMv2 foundation: app.manifest, ApplicationConfigurationSection, runtime SKU 4.7.2, AutoScaleMode.Dpi on MainForm/ContainerForm |
| `49c7a91` | **TEMP** DPI diagnostics in MainForm.cs (drop before upstream PR) |
| `2d2da00` | HeaderPanel DPI-aware + MainForm 17 call sites + TreeView ItemHeight sites |
| `6e791ea` | ConnectForm connection-string box sizing |
| `dbf0e20` | ChangeStatus/Clipboard/Delete/ParameterForm dialogs |
| `4ce117d` | NewVersionForm TableLayoutPanel + static HttpClient |
| `6a23ced` | Grouper header arc |
| `49af677` | Global AutoScaleMode.Font→Dpi flip (44 designer files) |
| `e61154a` | DpiAwareForm base + 28 forms reparented |
| `cb3f900` | GetDpiForWindow probe fix + OnDpiScaleChanged hook + metric recompute (HeaderPanel/Grouper/dialogs/MainForm/DashboardControl) + TEMP metric logging |
| `9b36cb1` | Explicit mainMenuStrip (20 logical) + statusStrip (24 logical) ImageScalingSize normalization |
| `d288c30` | TreeView rows = Max(font line height, scaled designer 20px); SelectEntityForm honors treeViewFontSize + recomputes on DPI change (adapts old d18235a) |

## DpiAwareForm mechanism (`src/ServiceBusExplorer/Forms/DpiAwareForm.cs`)

- `OnHandleCreated`: one-time guard → `windowDpi = GetDpiForWindow(Handle)`; if ≠ systemDpi → `Scale(windowDpi/systemDpi)` (startup correction); then always `OnDpiScaleChanged()` + `PerformLayout()` + `Invalidate(true)`.
- `OnDpiChanged`: base + `OnDpiScaleChanged()` + `PerformLayout()` + `Invalidate(true)`.
- `OnDpiScaleChanged()`: virtual hook for DPI-dependent metrics, runs at startup (post-correction) and on every monitor move. MainForm override: TreeView ItemHeight, mainMenuStrip/statusStrip ImageScalingSize, components loop for context menus, `dashboardControl.UpdateDpiMetrics()`.
- Child-handle timing: at the form's `OnHandleCreated`, child handles don't exist yet → child controls needing DPI metrics (DashboardControl) override their own `OnHandleCreated`.
- Helpers (internal static): `GetCurrentDpi(Control)` (falls back to systemDpi when handle-less), `ScaleToCurrentDpi`, `ScaleBitmapToCurrentDpi`; protected `ScaleTreeViewItemHeight(TreeView)`.

## Root causes already found (do not rediscover)

1. **net472 startup DPI leak**: `Control.DeviceDpi`/`LogicalToDeviceUnits` report **system DPI** (fixed at logon) at handle creation even when the window is created on a different-DPI monitor; the framework initial autoscale also uses system DPI, and no `DpiChanged` fires. `GetDpiForWindow(Handle)` is the OS truth.
2. **components.Components gotcha**: only controls constructed with the `IContainer` overload (e.g. `new ContextMenuStrip(this.components)`) are reachable via `components.Components`; `mainMenuStrip`/`statusStrip` are `new XxxStrip()` (MainForm.Designer.cs:57) and were missed by the ImageScalingSize loop → normalize them explicitly (`9b36cb1`).
3. **TreeView ItemHeight**: WinForms form autoscale NEVER scales `ItemHeight` (custom property). GA 6.3.1 (chocolatey) has **no DPI declaration at all** → DPI-unaware → designer `ItemHeight=20` fixed forever (MainForm.Designer.cs:716, SelectEntityForm.Designer.cs:177). Font-only heights (old `d18235a`) cram the 16px node icons (Round 10 tiny-tree regression: 13px rows). Current formula in `ScaleTreeViewItemHeight`: `Max(ceil(Font.GetHeight(currentDpi)), ScaleToCurrentDpi(20))` → 20px@100%, 30px@150% — identical physical inches (30/144 = 20/96), which is what PMv2 is for. `Font.GetHeight(dpi)` is exact; `Font.Height` uses the DPI captured when the Font was created.
4. **Font settings confounder**: the test machine's `UserSettings.config` had `logFontSize=12`/`treeViewFontSize=12` (written months before testing) → dev looked "bigger than GA". Keys removed; defaults are 8.25 (MainSettings.cs:100-101), applied via TwoFilesConfiguration.GetDecimalValue fallback when keys are absent.
5. **comctl32 TreeView quirk under PMv2**: `TVM_GETITEMHEIGHT` readbacks are scaled/mangled (logs showed 13/9/6 for the same set value) — cosmetic in logs, don't trust the readback.
6. **Not ours**: Dashboard grid's 9pt Segoe fonts + "Sync with treeview" toolbar overlap come from upstream #866 (Apr 2026), not from 440-1 changes.
7. **Stale-system-DPI scenarios**: changing a monitor's scale without sign-out leaves systemDpi at the logon value; the startup correction (GetDpiForWindow probe) handles the launch case.

## Test rounds 1–10 (evidence in D:\Jorge\OneDrive\Pictures\Screenshots\)

- R1: system passes everywhere; PMv2 breaks on DPI change (no handling).
- R2: App.config fix (ApplicationConfigurationSection) → PMv2 real at runtime, DpiChanged fires; auto-resize mis-scales custom paint; Win+Shift+Arrow = total distortion.
- R3: manual coalesced form-level rescale probe FAILED (fights custom-painted controls; blank client area via keyboard move).
- R4: system mode confirmed = bitmap-scale softness on non-primary-scale monitors (Erik's #807 blur, log-proven).
- R5: PMv2 + AutoScaleMode.Dpi hypothesis CONFIRMED — startup @150% crisp; residuals scoped to custom-painted controls + cross-monitor moves. **Mode locked: PMv2 + Dpi + custom DPI-change code.**
- R6–R9: rebuilt 440-1 iterations; GetDpiForWindow startup correction works (`correction=fired` on mismatch launches); menu 33px root-caused (components gotcha) and fixed; settings confounder identified and removed.
- R10: settings removal verified (8.25pt everywhere, sxs matches GA for menus/toolbar/grid/log); tiny-treeview regression from the font-only ItemHeight formula found and fixed (`d288c30`, current branch tip).

## Round 11 visual results and follow-up implementation (2026-09-27)

The latest side-by-side screenshots confirm that the main window at 150% is the only reported good result. At 100%, the dev build appears larger than GA in tabs, the Refresh button, TreeView text, and grid spacing. Launching on a 100% monitor while the primary is at 150% still looks oversized, and moving 150%→100% with the keyboard shortcut can leave the window badly laid out. Mouse moves also show oversized fonts/spacing in some areas. The Connect dialog looks generally good at 150%, but its URI editor and namespace dropdown are clipped.

The first follow-up build improved the Dashboard toolbar layout, but the user reported little visible difference. The 2026-09-27 diagnostics provide specific causes:

- 100% startup runs report TreeView and tab fonts at 12pt, while 150% startup runs report 8pt. Compare the saved TreeView font setting with GA before judging that font difference; the diagnostic line now records both actual and configured font sizes.
- After 150%→100%, a single `DpiChanged` callback is logged (`144→96`), so the move is detected. However, the callback ends with `AutoScaleDimensions` still at 144, the TreeView/tab fonts reduced to 5.33pt, and splitter distances still at 1.5× their 96-DPI logical values. The remaining failure is stale/re-scaled layout state after the event, not a missing DPI notification.
- In the 100%-startup correction scenario, `ConnectForm`'s child controls did not retain their designer-relative bounds after the whole form was scaled.

**Current working-tree iteration (build and tests pass; visual gate pending):**

- Synchronize DPI `AutoScaleDimensions` after startup correction and DPI changes.
- Reapply the configured TreeView/log fonts and an 8.25pt logical main-tab font after framework scaling; preserve split-container distances using the observed old/new window DPI, including startup-correction cases where `DeviceDpiOld` may not describe the monitor the window was actually on.
- Keep Dashboard toolbar fonts and button/combo dimensions at their logical sizes per DPI, in addition to its table-based layout and grid metric updates.
- Capture ConnectForm child bounds/fonts and client size at construction, normalize them to 96-DPI logical units, then restore at the active DPI and recalculate the URI editor. This avoids multiplying an already system-DPI-scaled snapshot a second time.
- Continue writing timestamped diagnostics to the app log and `%LOCALAPPDATA%\ServiceBusExplorer\DpiDiagnostics\DpiDiagnostics-<timestamp>.log`. Logs include form/monitor DPI, window/control bounds, autoscale dimensions, fonts, splitters, Dashboard metrics, and DPI/size/location transition ordering.

## Round 13 screenshot and log review (2026-09-27)

The latest 100% side-by-side screenshots still show larger TreeView text in the dev build. The matching 100%-startup diagnostics identify the configured TreeView font as 12pt; compare at the same Options value (8.25pt for a default comparison) before changing the app's user-configurable font behavior.

The shortcut move is now visibly improved: the diagnostics show one `144→96` transition and finish with 96-DPI splitter distances (`566` and `372` logical pixels), 8pt TreeView text, and an 8.25pt tab font. The Connect dialog is the remaining regression from this iteration. At 150%, its `ClientSize` grew from `1176×716` to `1764×1074`; the logical-layout snapshot was captured after the designer had already scaled it to 144 DPI and was then scaled again. The snapshot is now normalized to 96 DPI when captured. **That correction is included in the current commit but still needs a visual retest.**

## Round 14 visual results and follow-up implementation (2026-10-04)

The Connect dialog's outer size at 150% is correct: its logged client size is `1176×716`, the expected 1.5× scale of the designer's `784×477`. The remaining Connect defect is the URI editor bounds: at 144 DPI it reports approximately `X=-824, Width=996` instead of its expected parent-relative `X=24, Width=504`. At 96 DPI, after the layout restore, it reports `X=16, Width=336`. The namespace selector's logged 144-DPI bounds are approximately `X=24, Width=502`, so its clipping is not explained by its outer control bounds alone; its popup width is now included in diagnostics.

For the main-form comparison, logs from 12:00–12:13 report a configured TreeView font of 5.5pt, while 12:17 and 12:20 100%-startup runs report 8.25pt. Treat the 5.5pt runs as a different user-settings configuration, not as a default-font comparison. A move run at 12:08 also retains unusually large splitter ratios (`1413/2041` vertically and `502/1916` horizontally); scaling those distances by the DPI factor yields `942` and `335` on the shorter 100% screen. The resulting diagnostics show child bounds larger than the receiving client area. A later move run with the default split positions finished with child bounds fitting the form, so the overflow depends on window/splitter state and requires a layout pass after the DPI message has applied final bounds.

**Changes on the current working tree (build and tests pass; visual validation pending):**

- Remove right anchoring from the fixed-dialog URI and namespace selectors. Recalculate their positions and widths from their containing group dimensions at the active DPI; scale the namespace combo height and set its popup width to match its control width. Log each control's parent bounds and popup width.
- Capture the main and tree splitter ratios before a DPI change, then defer re-layout with `BeginInvoke` so it runs after the DPI message updates the window bounds. Reapply each ratio to the receiving split-container client area, clamp to panel minimum sizes, lay out the child tree, and log final sizes. Coalesce back-to-back DPI notifications to the latest deferred pass.

**Next visual gate (Round 15):** use the default 8.25pt TreeView setting in both apps; compare 100% and 150% startup; open Connect at 150% and at 100% with primary 150%; move 150%→100% by mouse and Windows+Shift+Arrow with both default and previously adjusted split positions, then return 100%→150%. Confirm the Connect window remains the normal 150% size, URI bounds are within the Connection Settings group, and the namespace selector/popup are not clipped. Confirm main child bounds and splitters fit the final 100% window after both move methods. Save screenshots with the taskbar clock and retain the matching DPI log; no visual fix is considered verified until this gate passes.

## Round 15 screenshots/logs and DPI reconciliation (2026-10-04)

The new code fixes the Connect form's measured geometry: the 144-DPI run reports the expected `1176×716` client size, URI bounds around `(24,72,504,26)`, and namespace selector/dropdown width `504`. The 96-DPI startup correction reports the URI field at `(16,48,336,26)` and selector width `336`. The remaining button-label size observation is not yet diagnosed; diagnostics now record OK/Cancel, URI-label, and Connection Settings group font sizes for comparison.

The main form's deferred splitter layout produces a window close to the direct-100% bounds, but the user still sees larger fonts/elements after a 150%→100% move. Logs show the specific mismatch: on a run started at 150%, `GetDpiForWindow` reports 144 while WinForms `DeviceDpi` remains 96. On the subsequent move, the framework can report `DpiChanged 96→96` even though the actual window DPI changed 144→96. The prior change fixed container geometry but therefore had no scale factor to reverse the startup correction for all child controls.

**New working-tree change (not yet visually verified):** `DpiAwareForm` now compares the actual DPI ratio from `GetDpiForWindow` with the ratio reported by `DpiChangedEventArgs`. When they differ, it applies only the missing scale factor to child controls (not the outer window), then recomputes custom metrics; MainForm's deferred split-ratio layout runs afterward. Connect diagnostics now include the button and label font sizes to determine whether OK/Cancel need a separate font adjustment.

**Next visual gate (Round 16):** use 8.25pt TreeView settings in both apps; compare direct 100% and 150% startup; launch on 100% with primary 150%; move 150%→100% by mouse and Windows+Shift+Arrow, then back to 150%. Check Connect at 150%, direct 100%, and 100% after startup correction. Specifically verify the 100% fonts match direct-100 startup, window/control bounds remain inside the client area, and the Connect URI/selector remain correctly placed. Include the new button/label font metrics and retain the DPI log paired with each screenshot.

## What remains before PR1 (upstream)

1. **Round 16 visual gate** above is pending user retest; the actual-DPI child-scaling fallback and Connect bounds/font comparison are not yet visually verified.
2. **Known residual**: the "New Version" link can overlap the "Microsoft Azure" header text in development builds. Recheck the 100% tabs and Refresh size after the new toolbar/font/layout changes; decide whether remaining tab differences belong in the later TabControl layer.
3. **Before opening the upstream PR**: remove or explicitly retain the temporary diagnostic P/Invokes and DPI diagnostic file logging after the test cycle; review the new Dashboard/Connect changes; rebase to drop the fork-tooling layer (this file + copilot-instructions.md are fork-only), push, and open the PR to paolosalvatori/ServiceBusExplorer referencing issue #440. Ask maintainers about merge strategy on #440 when the first PR is ready, not before.

## Build / test / conventions

- Build: `dotnet build src\ServiceBusExplorer.sln -c Release` (pre-existing MSB3884 ruleset warning is benign).
- Test: `$env:FILE_VERSION='1.0.0.1'; dotnet test src\ServiceBusExplorer.sln -c Release` — 106/106 passing (FILE_VERSION needed locally for the CI version test).
- Run: `src\ServiceBusExplorer\bin\Release\net472\ServiceBusExplorer.exe`.
- Commits: English, **no Co-authored-by Copilot trailer**, reference paolosalvatori/ServiceBusExplorer#440 in the body.
- TreatWarningsAsErrors=true; no new `#region`; minimal comments; CRLF; 4-space indent.
- Monitor matrix: ThinkVision E28u-20 4K@150%/100% (primary), ThinkPad P73 FullHD@100%, ThinkPad P16 4K@250% (untested); Erik: Dell 3440×1440@100% primary, Surface@125%/150%. The 100%-scale entries are mandatory per layer (the #807 revert was a 100%-scale regression).
