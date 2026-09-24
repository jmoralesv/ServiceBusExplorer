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
| `079ccaa` | TreeView rows = Max(font line height, scaled designer 20px); SelectEntityForm honors treeViewFontSize + recomputes on DPI change (adapts old d18235a) |

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
- R10: settings removal verified (8.25pt everywhere, sxs matches GA for menus/toolbar/grid/log); tiny-treeview regression from the font-only ItemHeight formula found and fixed (`079ccaa`).

## What remains before PR1 (upstream)

1. **Round 11 visual gate** (short): (a) launch 4K@100% sxs GA → roomy tree, log `treeView.ItemHeight=20`; (b) launch 4K@150% → `ItemHeight=30`; (c) move 150%↔100% both ways → tree stays correct; (d) launch FullHD w/ primary@150% (correction path) → tree correct + `menuStrip.ImageScalingSize=20`; (e) dead-letter Move/transfer dialog (SelectEntityForm) tree at 150%; (f) optional: Options → treeViewFontSize=12 → rows grow in MainForm AND SelectEntityForm.
2. **Known residuals (not blocking)**: Dashboard/Explorer tabs slightly chunky (vanilla TabControl — layer 440-4 TabControlHelper territory); interval combo clipped ("in") only on the correction-fired path (DashboardControl toolbar fixed-px layout, DashboardControl.cs:97-134); "New Version" link overlaps "Microsoft Azure" header text (dev builds only); window keeps 150% size after move to 100% (content correct, acceptable).
3. **Before opening the upstream PR**: drop TEMP code (commit `49c7a91` + the TEMP log lines in `DpiAwareForm.OnHandleCreated` and `MainForm.OnDpiScaleChanged`), rebase to drop the fork-tooling layer (this file + copilot-instructions.md are fork-only), push, open PR to paolosalvatori/ServiceBusExplorer referencing issue #440. Ask maintainers about merge strategy on #440 when the first PR is ready, not before.

## Build / test / conventions

- Build: `dotnet build src\ServiceBusExplorer.sln -c Release` (pre-existing MSB3884 ruleset warning is benign).
- Test: `$env:FILE_VERSION='1.0.0.1'; dotnet test src\ServiceBusExplorer.sln -c Release` — 106/106 passing (FILE_VERSION needed locally for the CI version test).
- Run: `src\ServiceBusExplorer\bin\Release\net472\ServiceBusExplorer.exe`.
- Commits: English, **no Co-authored-by Copilot trailer**, reference paolosalvatori/ServiceBusExplorer#440 in the body.
- TreatWarningsAsErrors=true; no new `#region`; minimal comments; CRLF; 4-space indent.
- Monitor matrix: ThinkVision E28u-20 4K@150%/100% (primary), ThinkPad P73 FullHD@100%, ThinkPad P16 4K@250% (untested); Erik: Dell 3440×1440@100% primary, Surface@125%/150%. The 100%-scale entries are mandatory per layer (the #807 revert was a 100%-scale regression).
