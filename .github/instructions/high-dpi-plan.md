# Plan: Resume High DPI Work — paolosalvatori/ServiceBusExplorer#440

## Context

Resuming High DPI support work after ~2 years. Previous attempts: PR #797 (merged, then reverted by #807), PR #800 (closed, stale). Erik Mogensen confirmed his test matrix on the issue: Dell 3440×1440 @100%, Surface 2400×1600 @125% and @150%. Strategy this time: smaller, reviewable PRs.

## Answers to Your Questions

### Q1: Can stacked PRs work if we create branches manually first, then add them to a stack?

**Yes.** The `gh stack` extension explicitly supports adopting existing branches:

- `gh stack init <branch1> <branch2> ...` (in bottom-to-top order) — per the docs: "When explicit branch names are given, **existing branches are adopted automatically** and any missing branches are created."
- `gh stack submit` then creates/looks up PRs and fixes base-branch chaining automatically: "Existing PRs whose base branch doesn't match the expected chain are corrected automatically."
- You can even link existing PRs by number or URL.

So you can keep your manual workflow (`git checkout -b 440-1-...`) and adopt branches into a stack afterward. Caveat: it's smoother to use `gh stack init` / `gh stack add` from the start, since the extension tracks stack order for you.

### Q2: Do stacked PRs work when targeting an upstream repo from a fork?

**No.** The docs state explicitly:

> "Stacked pull requests require all branches to be in the **same repository**. **Cross-fork stacks are not supported.**"

A stack is a server-side linked chain of PRs in one repo; PRs from a fork to upstream can't be members of a stack.

**Implication for us — two options:**

- **Option A (recommended): Stack in your fork.** Create the stack entirely in `jmoralesv/ServiceBusExplorer` (bottom PR targets your `main`, each layer targets the branch below). You get the full stacked-PR experience (stack map, cascading rebase, bottom-up merges) for your own development. Once the stack is proven, open **one PR per layer to upstream sequentially** — open the next one only after the previous merges upstream. This respects the maintainers' review pace and avoids the #797 situation (one big merge that had to be reverted).
- **Option B: No stack.** Manually chain PRs from fork branches directly to upstream (`base: main` on upstream), rebasing each branch after the previous PR merges. Simpler, no new tooling, but you lose the stack UI and automatic rebasing.

Either way, each PR to upstream stays small and independently reviewable — the actual requirement.

### Q3: Can the Copilot instructions live on a separate branch so they don't leak into feature branches or PRs to upstream?

**Yes — but with an important nuance about how Copilot loads instructions.** Copilot reads `.github/copilot-instructions.md` from the **current checkout** (the branch you're working on). If the file only exists on a docs branch, it won't be loaded when you're on a feature branch — unless the feature branch contains it.

**Recommended approach: a fork-only docs layer at the bottom of your stack, never submitted upstream.**

- Commit the instructions files as the **first commit(s)** on the docs branch (e.g., `fork-tooling`), which sits at the bottom of your local stack: `main ← fork-tooling ← 440-1-... ← 440-2-...`
- All feature branches include the docs commit, so Copilot always has the instructions while you work
- When opening a PR **to upstream**, open it from the feature branch but the diff must exclude the docs commit — the cleanest way is: before submitting upstream, **rebase the feature branch to drop the fork-tooling commit** (interactive rebase, drop the docs commit), or squash your feature work onto fresh upstream `main`
- Alternative if that rebase feels risky: keep `fork-tooling` as a local-only branch, and before pushing a PR to upstream, create a temp branch off upstream/main + cherry-pick the feature commits. The `gh stack` cascading rebase also helps here since the docs layer is the trunk-adjacent layer.

Simpler variant worth considering: keep the `.github` instructions **uncommitted-but-present** is not possible (git tracks them); keeping them only locally uncommitted across branch switches is fragile (git carries untracked files across checkouts — actually untracked files DO follow you across branches, so an uncommitted `.github/copilot-instructions.md` would be present in every branch and never appear in any commit). That's fragile (easy to lose, not synced), so the docs-layer approach above is preferred.

## Branch Analysis (from prior session)

| Branch | Unique commits | Base | Content |
|---|---|---|---|
| `first-set-changes` | 10 | Jul 2024 | = PR #797 content: manifest DPI settings, .NET 4.7.2, Connect/MainForm fixes |
| `high-dpi-commits` | 52 | Jan 2024 | Full original work (superset, oldest base) — Test* controls, ListenerControl, TreeView, CheckBoxList, TabControl, ListViewHelper/TabControlHelper |
| `second-set-changes` | 10 | Jul 2024 (includes #797) | TableLayoutPanel work: TimeSpanControl, HandleRule/Topic/Subscription/NotificationHub — some temp/messy code |

Current `main` (net472 WinForms app + netstandard2.0 libs) is 48–69 commits ahead of those bases. No branch can be rebased directly; changes must be re-applied by theme onto fresh branches from current `main`.

## Phase 2 — Feature Stack: Commit Analysis

I analyzed all 52 commits in `high-dpi-commits` (chronological) and grouped them by app area. The work spans far more than my initial 5 draft branches suggested. Mapping:

| Commit range | App area | Proposed layer |
|---|---|---|
| 1–8 (2ee0ae9…ca70861) | Foundation: manifest DPI, .NET 4.7.2, Connect/MainForm, dialog fixes, grouper header height | **440-1-foundation** |
| 9–18 (c7c3535…a5fc810) | Handle* controls: TimeSpanControl TableLayoutPanel, HandleTopic/Subscription/Rule layouts, HandleNotificationHub TableLayoutPanel, list view headers | **440-2-handle-controls** |
| 19–23 (ff34d04…84f96a6) | Helpers: TreeView item height check, ListViewHelper, AuthorizationRulesDataGridViewHelper, cleanup | **440-3-helpers** |
| 24 (1a8a090) | TextForm size fix | **440-3-helpers** (small, same theme) |
| 26–29 (6bfe318…b05213b) | TabControl: font sizes, TabControlHelper.DrawTabControlTabs, ItemSize removal (tab headers cut off) | **440-4-tab-control** |
| 30–33 (391d184…aa803a9) | Grouper CustomPaint + SplitterDistance fixes (Messages/Deadletter/Session tabs), MessageForm | **440-5-grouper-splitter** |
| 34–35 (e336da2, d18235a) | CheckBoxList spacing, TreeView ItemHeight in MainForm/SelectEntityForm | **440-6-list-treeview** |
| 37–38 (4553d20, 52c4f8b) | ContainerForm/Test windows header height, HeaderPanel.LogicalToDeviceUnits centralization | **440-1-foundation** (HeaderPanel belongs with foundation) |
| 39–46 (11045aa…cfc3dea) | TestTopicControl: listview column width, TableLayoutPanels (Sender/Receiver tabs), propertiesDataGridView size, chart size | **440-7-test-topic** |
| 47 (ea55422) | TestQueueControl: port TestTopicControl fixes | **440-8-test-queue** |
| 48–49 (daea1e7, a3a4df3) | ListenerControl + ContainerForm layout (Create Queue/Subscription Listener windows) | **440-9-listener** |
| 50–52 (696666c…055ee95) | TestQueueControl TableLayoutPanels (Message, Configuration groupers) | **440-8-test-queue** |
| 25, 33, 36 (merge commits) | Upstream merges | Dropped (replaced by rebasing onto current main) |

**Revised layer set (9 layers)** — still subject to refinement as each is built:

1. `440-1-foundation` — manifest DPI settings, Connect/MainForm, HeaderPanel, dialog forms (commits 1–8, 37–38)
2. `440-2-handle-controls` — Handle* controls + TimeSpanControl + list view headers (commits 9–18)
3. `440-3-helpers` — ListViewHelper, AuthorizationRulesDataGridViewHelper, TreeView check, TextForm (commits 19–24)
4. `440-4-tab-control` — TabControlHelper + tab header fixes (commits 26–29)
5. `440-5-grouper-splitter` — grouper CustomPaint + SplitterDistance + MessageForm (commits 30–33)
6. `440-6-list-treeview` — CheckBoxList spacing + TreeView ItemHeight (commits 34–35)
7. `440-7-test-topic` — TestTopicControl TableLayoutPanels + chart + listview (commits 39–46)
8. `440-8-test-queue` — TestQueueControl ports + TableLayoutPanels (commits 47, 50–52)
9. `440-9-listener` — ListenerControl + ContainerForm listener windows (commits 48–49)

## Revised Plan

### Phase 0 — Setup (fork-local, no upstream interaction)
1. Verify `gh` is authenticated: `gh auth status` (gh already installed)
2. Install gh-stack extension: `gh extension install github/gh-stack`
3. Enable Issues on the fork (Settings → Features → Issues) for personal task tracking

### Phase 1 — Copilot instructions (fork-only layer, pushed to origin)
4. Create branch `fork-tooling` off `main`
5. Write `.github/copilot-instructions.md` — project overview (WinForms Service Bus admin tool), **fork purpose**: deliver High DPI support for upstream issue #440 in small reviewable PRs; stack: C# / .NET Framework 4.7.2 (ServiceBusExplorer, Common, NotificationHubs, Tests) + netstandard2.0 libs (ServiceBus, EventHubs, Relay, Utilities, EventGridExplorerLibrary); build/test: `dotnet restore` / `dotnet build -c Release` / `dotnet test` on `src\ServiceBusExplorer.sln` (windows-2022 CI); High DPI conventions (PerMonitorV2, `LogicalToDeviceUnits`, TableLayoutPanel); shared test matrix (my ThinkVision E28u-20 4K@150%, ThinkPad P73 FHD@100%, ThinkPad P16 4K@250% + Erik's Dell 3440×1440@100%, Surface 2400×1600@125%/@150%)
6. Write `.github/instructions/csharp.instructions.md` — C# conventions adapted to .NET Framework 4.7.2 / SDK-style csproj (no C# 14-only features), WinForms patterns, no regions, minimal comments
7. Commit both on `fork-tooling`, push to origin — this branch is **never** submitted upstream

### Phase 2 — Feature stack (one branch at a time, with visual test gates)
8. `gh stack init` with trunk = `main`, first branch `440-1-foundation` on top of `fork-tooling`
9. Create 9 fork issues (one per layer), each referencing `paolosalvatori/ServiceBusExplorer#440`, labeled `high-dpi` + `pr-N`
10. **For each layer, in order** — the loop per branch:
    a. `gh stack add 440-N-name`
    b. Study the mapped commits in `high-dpi-commits` for that layer (read the diffs, understand intent — do NOT blind cherry-pick; the old base is 48–69 commits behind current `main`, so files may have moved/changed upstream)
    c. Re-apply the changes onto the current branch, adapting to current `main` code
    d. Build: `dotnet build -c Release`; run tests: `dotnet test -c Release`
    e. **Visual test gate — I stop and hand over to you**: run the app on the monitor matrix (at minimum: ThinkPad P73 FHD@100% + one 4K monitor; Erik's regression was at 100% scale, so that config is mandatory per layer). You confirm the layer's screens render correctly before I proceed.
       - **ALSO test the new-since-2024 user-facing UI** on every layer/commit (it has zero High DPI coverage):
         - **Dashboard tab** (new default tab in MainForm): DataGridView with message counts, auto-refresh, copy-row, sorting
         - **TreeView filter box** (`filterTreeViewTextBox`): filter box above the TreeView + clear button + Ctrl+F
         - **Event Grid** (entire feature): `EventGridConnectForm`, `CreateEventGridTopicForm`, `CreateEventGridSubscriptionForm`, `PublishEventForm`, `ReceiveEventForm`, and `HandleEventGridNamespace/Topic/SubscriptionControl`
         - MainForm's two-tab layout (Dashboard + Explorer)
    f. Commit, push, move to next layer
11. If a layer turns out too big while building it, split it (stacked PRs make this cheap — `gh stack add` inserts a new layer on top)

### Phase 3 — Upstream submission (Option A: sequential, one PR at a time)
12. Before each upstream PR: detach the feature branch from the `fork-tooling` layer (interactive rebase dropping the docs commit, or cherry-pick feature commits onto fresh upstream/main)
13. Push cleaned branch to origin; open PR to `paolosalvatori/ServiceBusExplorer` with `gh pr create --repo paolosalvatori/ServiceBusExplorer`, referencing #440
14. When the **first** PR is ready to target upstream, ask the maintainers on issue #440 about the merge strategy (incremental merges of partial High-DPI work into upstream `main`, given #797's revert) — not before
15. Wait for merge before opening the next upstream PR (avoids the stacked-merge-to-main risk that caused the #797 revert)

## Current Progress (as of 2026-09-07)

**Completed:**
- Phase 0: gh auth verified (2.100.0), `gh stack` extension v0.1.1 installed, Issues enabled on fork
- Phase 1: `fork-tooling` branch created with `.github/copilot-instructions.md` + `.github/instructions/csharp.instructions.md`, pushed to origin. **md files record that DPI mode (PerMonitorV2 vs system) is UNDER TEST and must be updated once testing concludes.**
- Phase 2 setup: 9 fork issues created (#1–#9, labels `high-dpi` + `pr-N`), stack initialized `fork-tooling ← 440-1-foundation`
- **Layer 440-1, increment 1**: `app.manifest` created with **PerMonitorV2 active** (system block commented for flip-testing), wired via `<ApplicationManifest>` in csproj, `EnableWindowsFormsHighDpiAutoResizing=true` + runtime SKU 4.7.2 in App.config. Committed (e532300). Build succeeds, manifest confirmed embedded in exe.

**In progress / next:**
- **Phase 2a — diagnostic increment DONE (f4349dd)**: root cause found — `EnableWindowsFormsHighDpiAutoResizing` was in `<appSettings>` where WinForms ignores it (old PR #797 had the same ineffective placement). Moved to proper `<System.Windows.Forms.ApplicationConfigurationSection>` with `DpiAwareness=PerMonitorV2`; added temporary DPI diagnostic logging (awareness + DeviceDpi at startup, `DPI changed` lines on monitor move) to MainForm.
- **Round 2 testing DONE** — see results below. Key outcome: config fix works (runtime PMv2 confirmed, `DpiChanged` now fires), but the framework's auto-resize mis-scales the custom-painted UI, so it was turned OFF and replaced by a manual coalesced `OnDpiChanged` rescale (probe v2, MainForm only).
- **Round 4 — system confirmation test DONE (2026-09-20)**: system mode works but **bitmap-scales on any monitor whose scale ≠ primary's** — DeviceDpi=144 logged on FullHD@100% (system DPI = primary's scale at logon, by design), window looks "strange"/soft = **Erik's #807 blur, now root-caused with log evidence**. Zero DpiChanged activity, as expected.
- **Mode decision CHANGED by user (2026-09-20): PerMonitorV2.** Rationale: future-proof — modern .NET invests in PMv2 (.NET 6+ PMv2 scaling/MDI/container improvements), easing a future net472→.NET 10 migration. Research correction: .NET 10 does NOT default to PMv2 (`ApplicationHighDpiMode` default is `SystemAware` per MS docs), but PMv2 remains the strategic choice. Requires working DPI-change handling on net472.
- **Probe v3 committed (5cb6918)**: framework-native PMv2 — `AutoScaleMode.Dpi` (96×96) on MainForm + ContainerForm, `EnableWindowsFormsHighDpiAutoResizing=true`, PMv2 manifest (Block A active), manual rescale probe REMOVED, diagnostics KEPT. Hypothesis: rounds 2–3 tested auto-resize with **Font** mode (documented as non-linear across DPI changes); **Dpi** mode is the linear pairing the net472 feature was designed for.
- **Round 5 testing DONE (2026-09-20)** — see results below. Hypothesis CONFIRMED: startup @150% crisp with Dpi mode; residual breakage scoped to custom-painted controls (old commits' territory) + cross-monitor moves (needs DpiChanged handling). **Mode decision LOCKED: PerMonitorV2 + AutoScaleMode.Dpi + custom DPI-change code.**
- **Done after R5**: both md files on `fork-tooling` updated with the PMv2 decision (commitment fulfilled).
- **440-1-foundation REBUILT (2026-09-20)**: 5 probe commits dropped; consolidated into `ec0f3bd` (PMv2 manifest + ApplicationConfigurationSection + runtime SKU 4.7.2 + AutoScaleMode.Dpi on MainForm/ContainerForm) + `49c7a91` TEMP diagnostics (drop before upstream PR). Old commits 2ee0ae9/4c5d02b superseded; ed7bfce (NuGet) skipped as stale.
- **440-1 2024-commits REAPPLIED, PMv2-adapted** (5 commits): `2d2da00` HeaderPanel DPI-aware (converting getter centralizes LogicalToDeviceUnits; paint uses current DPI; icon bitmap disposed+rescaled per paint) + MainForm 17 call sites (incl. NEW eventGridNamespaceControl site) + SetControlSize header-aware + TreeView ItemHeight ×3 + OnDpiChanged Invalidate(true) on MainForm/ContainerForm; `6e791ea` ConnectForm dynamic connection-string box (adapted to usesRawConnectionStringEditor refactor); `dbf0e20` ChangeStatus/Clipboard/Delete/ParameterForm dialogs; `4ce117d` NewVersionAvailableForm TableLayoutPanel + static HttpClient (User-Agent in static ctor); `6a23ced` Grouper header arc. Build clean, 106/106 tests pass (FILE_VERSION env var needed locally for the CI version test).
- **Next**: visual test gate for layer 440-1 (user) → then layer 440-2 (Handle* controls, commits 9–18). Before first upstream PR: drop TEMP commit, squash as needed, rebase to remove fork-tooling.

## DPI Mode Test Results (2026-09-09) — Round 2 (App.config fix, `_config_change` screenshots)

| Scenario | Result |
|---|---|
| 4K @ 150% startup | ⚠️ Renders, diagnostics visible (`perMonitorV2=True, DeviceDpi=144`), but groupers **too short** — Connect button clipped. **Regression vs Round 1** (which had auto-resize OFF and was correct at 150%). |
| 4K @ 100% startup | ✅ Correct, matches GA sxs. `DeviceDpi=96`. |
| Move 4K@100% → FullHD@100% | ✅ Correct. No log activity (no DPI change). |
| Move 4K@150% → FullHD@100% (mouse) | ❌ `DPI changed: 144 -> 96` **fires** (config fix works!) but client area still too big, words half-cut. Framework auto-rescale insufficient. |
| Move 4K@150% → FullHD@100% (**Win+Shift+Arrow**) | ❌❌ **Total distortion** — everything ~1.5× too big, nothing usable. Looks like wrong-direction or cumulative rescale; repeated DpiChanged events / handle churn compound it. |

**Conclusions from Round 2:**
1. The `ApplicationConfigurationSection` fix is correct and necessary — PMv2 is real at runtime and `DpiChanged` fires.
2. `EnableWindowsFormsHighDpiAutoResizing=true` **hurts this app**: it mis-scales custom-painted controls (Grouper/HeaderPanel) at startup @150%, and on monitor moves it rescales partially (mouse) or catastrophically (Win+Shift+Arrow).
3. Round 1 proved startup rendering is correct at both 96 and 144 DPI with the switch **OFF** (Font autoscale + custom paint code).
4. **Probe v2**: switch OFF + manual `MainForm.OnDpiChanged` → deferred, coalesced `Scale(new/old)` + `PerformLayout()` + `Invalidate(true)`. Coalescing (flag + `BeginInvoke`, read live `DeviceDpi`) targets the Win+Shift+Arrow burst case. Old commits can't help directly with DpiChanged (they were written for system awareness, where the event never arrives), but their `LogicalToDeviceUnits` call sites identify which custom sizes may still need per-control fixes after the form-level rescale.

## DPI Mode Test Results (2026-09-20) — Round 4 (system awareness + diagnostics, `_round4` screenshots)

| Scenario | Result |
|---|---|
| Launch on FullHD@100% | ⚠️ Log shows `DeviceDpi=144` — **by design**: system awareness = process renders at the *system* DPI (primary monitor's scale at logon: 4K@150% → 144). On the 100% monitor Windows bitmap-scales the window down → soft/"strange" look. **This is Erik's #807 blur, reproduced with log evidence.** |
| Move 4K@150% → FullHD@100% | ⚠️ Same bitmap-scaled softness. **Zero log activity** (no DpiChanged under system awareness) — as predicted. |
| Launch on 4K@150% | ✅ Good (native rendering, no bitmap scaling). |

**Conclusions from Round 4:** system mode is safe but visually degraded on every non-primary-scale monitor — exactly the maintainer complaint that caused revert #807. User decided: **PerMonitorV2 is the direction**, accepting that DPI-change handling code must be written. Note: net472's PMv2 framework support is far weaker than .NET 6+'s (which fixed container/MDI scaling on monitor moves); some round 2–3 pain may be net472-specific.

## DPI Mode Test Results (2026-09-20) — Round 5 (probe v3: PMv2 + `AutoScaleMode.Dpi` + auto-resize ON, `_round5` screenshots)

| Scenario | Result |
|---|---|
| 4K @ 150% startup | ✅/⚠️ Crisp, renders fine — log confirms `awareness=2, perMonitorV2=True, DeviceDpi=144, AutoScaleMode=Dpi`. Not perfect: custom-painted elements (tab strip, grouper headers) still need the old commits' custom code. Huge improvement vs R2's Font-mode clipping. |
| 4K @ 100% startup | ✅ Good — sxs matches GA. |
| Launch FullHD@100% (primary @150%) | ⚠️ Mostly OK, but some oversized elements (Dashboard/Explorer tabs, Refresh-button row) — system-DPI-derived values leak into control init under PMv2 (system DPI=144). |
| Move 4K@100% → FullHD@100% | ✅ Good (no DPI change). |
| Move 4K@150% → FullHD@100% | ❌ Still breaks — distortions in buttons, tabs, element positions. Framework auto-rescale doesn't reach custom-painted/anchored controls. |
| Win+Shift+Arrow back-and-forth | ❌ Still breaks, but far less than R3 (no blank client area). |

**Conclusions from Round 5 (probe v3 verdict: hypothesis CONFIRMED):**
1. `AutoScaleMode.Dpi` (96×96) is the correct pairing for PMv2 + auto-resize — startup @150% now renders correctly for standard controls (R2/R3 tested Font mode, documented as non-linear across DPI changes). User's assessment confirmed: PMv2+Dpi needs much less new work than PMv2+Font.
2. Residual work is scoped to: (a) custom-painted controls with hardcoded logical sizes (tab strip, Grouper/HeaderPanel headers, Refresh row) — exactly the old 2024 commits' `LogicalToDeviceUnits` map; (b) per-control/form `DpiChanged` handling for cross-monitor moves (net472 framework rescale is insufficient; .NET 6+ fixed this in-box); (c) a global `AutoScaleMode.Font` → `Dpi` flip — 44 designer files remain (23 forms + 21 controls).
3. **DECISION LOCKED: PerMonitorV2 + AutoScaleMode.Dpi + custom DPI-change handling.** system mode rejected (bitmap-scales on non-primary-scale monitors = Erik's #807 blur, proven in R4).
4. Research answer: `SystemAware` (.NET 6+) is functionally the same mode as `system` (net472/4.8) — render at system DPI at startup, Windows bitmap-scales elsewhere. .NET 6+ adds `Application.SetHighDpiMode`/`ApplicationHighDpiMode` and much stronger PMv2 support, which makes PMv2 the migration-forward choice.

## DPI Mode Test Results (2026-09-09) — Round 3 (probe v2: auto-resize OFF + manual coalesced `OnDpiChanged` rescale, `_round3` screenshots)

| Scenario | Result |
|---|---|
| 4K @ 150% startup | ⚠️ Renders fine overall but items **too small** — Dashboard/Explorer tab sizes, filter search box tiny. Custom controls compute sizes once from 96-DPI logical values; no framework auto-resize to compensate. |
| 4K @ 100% startup | ✅ Good. |
| Move 4K@100% → FullHD@100% (mouse) | ✅ Good (no DPI change). |
| Move 4K@150% → FullHD@100% (mouse) | ❌ **Breaks awfully** — main menu overlaps groupers, dashboard checkboxes tiny, filter search box gone. Form-level `Scale()` mis-handles the custom-painted/anchored layout. |
| Win+Shift+Arrow 150%→FullHD and back | ❌❌ **Client area blank white** — only the "New Version" link renders; entire UI gone (both directions). Worst failure of all rounds. |

**Conclusions from Round 3 (probe v2 verdict: FAILED):**
1. Form-level `Scale(new/old)` after the fact does not work for this app — it fights the custom-painted controls (Grouper, HeaderPanel, menu strip, anchored layouts) that compute sizes from hardcoded logical values.
2. PMv2 has now failed the 150%→100% move in **3 consecutive configurations**: no handler (R1), framework auto-resize (R2), manual rescale (R3). Startup@150% also needs per-control fixes regardless.
3. Rescuing PMv2 would require deep per-control DPI-change work across dozens of custom-paint sites — exactly the decision-gate "fix balloons" condition → **fall back to system mode**.
4. **system mode passed ALL Round 1 scenarios with zero code**, and all 52 old commits (2024) were designed/tested under system awareness → directly reusable.
5. PMv2 cross-monitor rescaling documented as known limitation / possible future work.

## DPI Mode Test Results (2026-09-08) — Round 1

Tested on: ThinkVision E28u-20 4K (primary, @150% and @100%) + ThinkPad P73 Full HD @100% (secondary). Screenshots in `D:\Jorge\OneDrive\Pictures\Screenshots\`.

| Scenario | system | PerMonitorV2 |
|---|---|---|
| 4K @ 150% (start monitor) | ✅ crisp, correct | ✅ crisp, correct |
| 4K @ 100% | ✅ correct (matches GA) | ✅ correct (slightly taller TreeView rows/header — cosmetic) |
| Moved 4K@150% → FullHD@100% | ✅ correct | ❌ **BROKEN** — window keeps 150% sizes; controls, text, even title-bar buttons oversized |
| Moved 4K@100% → FullHD@100% | ✅ correct | ✅ correct (no DPI change = no problem) |
| GA app (original) at 4K@150% | ❌ tiny/unusable (the known problem) | — |

**Verdict from evidence:**
- **system** renders correctly in ALL tested configurations.
- **PerMonitorV2** fails in exactly one scenario: **DPI change** (window moved from 150% monitor to 100% monitor). The **client area** keeps the startup monitor's 150% sizing while the **title bar is correct** (same size as in the system-mode and original screenshots — verified by re-examining the captures). That combination is the signature of **true PMv2 with no client-side DPI-change handling**: in PMv2, Windows redraws the non-client area itself at the new DPI and sends `WM_DPICHANGED`, but re-scaling the client area is the app's job — and this app never does it. (An earlier draft of this analysis claimed the title bar was oversized and suspected Per-Monitor V1; re-verification showed the title bar is identical everywhere, so the V1 hypothesis is dropped — with one cheap P/Invoke confirmation kept in the diagnostic step.) WinForms' built-in PMv2 auto-rescale (net472 + `EnableWindowsFormsHighDpiAutoResizing` + `AutoScaleMode.Dpi`) did NOT kick in — investigate `MainForm.AutoScaleMode` in the designer and whether the AppContext switch is honored at runtime.
  - **Good news**: this is the *standard* PMv2 failure mode with a documented fix pattern (handle `DpiChanged` → re-scale/re-layout with the new `DeviceDpi`). The rescue test is well-scoped.
- Note: untested directions — FullHD→4K move, P16 @250%. Erik's dual-setup (Surface @150% primary + Dell @100%) IS the broken scenario, so this failure mode matters for the maintainers too.

## DPI Mode Test Results (2026-09-20) — Round 6 (visual gate for rebuilt 440-1 layer)

| Scenario | Result |
|---|---|
| 4K @ 150% startup | ✅ Good — crisp, correct; log confirms `awareness=2, perMonitorV2=True, DeviceDpi=144, AutoScaleMode=Dpi`. HeaderPanel fixes visibly working (View Subscription header correct). |
| Launch at 100% (4K set to 100%, system DPI still 144 from logon) | ❌ Whole app + Connect dialog rendered ~1.5× (tabs, menu, tree rows) — net472 startup leak: initial autoscale uses stale system DPI, never corrected. |
| ParameterForm @ 150% | ✅ Correct (device-unit layout works). |
| DeleteForm @ 150% | ✅ Correct — message fully visible (LogicalToDeviceUnits padding works). |
| Move 4K@150% → FullHD@100% | ⚠️ Improved: `DPI changed: 144 -> 96` fires, window+TreeView+tabs rescale correctly; but dead space right/bottom (no re-layout to final bounds), HandleSubscriptionControl content empty (440-2/440-5 territory), New Version link overlaps header text. |
| ConnectForm @ 150% | ❌ Namespace ComboBox malformed, txtUri huge/narrow — ConnectForm was still AutoScaleMode.Font (non-linear at 144). |
| Subscription details @ 150% | ❌ Groupers not stretched, empty areas — Handle* control layout (layer 440-2) + splitter (440-5). Not 440-1 scope. |

**Fixes applied after Round 6:**
1. `49af677` — **global `AutoScaleMode.Font`→`Dpi` flip** (44 designer files; 9F,20F files → 144F,144F dims; HandleRuleControl stays None). Fixes ConnectForm/dialog scaling at high DPI.
2. `e61154a` — **`DpiAwareForm` base for all 28 forms**: one-time startup rescale at handle creation when monitor DPI ≠ system DPI (the leak), plus `PerformLayout()` + `Invalidate(true)` on DpiChanged (dead space after moves).
3. Retest pending (user): 100% launch with stale system DPI, 150% launch, Connect window at both, moves 150%↔100%.

## Phase 2a — PerMonitorV2 Rescue Test (before final mode decision)

Goal: find out whether a **small amount of DPI-change handling code** makes PerMonitorV2 viable. If yes, PMv2 is the technically correct choice (no bitmap scaling, each monitor gets crisp native rendering) and most old commits remain reusable (they're largely DPI-mode-agnostic layout/scaling fixes). If the fix balloons, fall back to system mode (matches how the old work was originally tested).

1. **Diagnostic increment (temporary code on `440-1-foundation`)**: confirm the runtime state — cheap P/Invoke check that the process awareness really is PerMonitorV2 (expected, given the correct title bar), log `MainForm.DeviceDpi` at startup and inside `DpiChanged` via `Debug.WriteLine`, check `MainForm.AutoScaleMode` in the designer, and verify the `EnableWindowsFormsHighDpiAutoResizing` AppContext switch is honored from `ServiceBusExplorer.exe.config`. Goal: pinpoint why WinForms' built-in auto-rescale isn't engaging before writing the probe.
2. **DpiChanged handling (probe, minimal)**: handle `DpiChanged` on the top-level forms (`MainForm`, `ContainerForm`):
   - re-run the custom DPI-size logic that currently runs once at ctor/load (HeaderPanel `headerHeight`, Grouper header, TreeView `ItemHeight`, toolbar/image scaling) using the new `DeviceDpi` / `LogicalToDeviceUnits`
   - `PerformLayout()` + `Invalidate(true)` so all custom-painted controls repaint with the new DPI
   - Keep it a probe: no refactoring, no cleanup — just enough to test the scenario.
3. Build, hand to user for **Round 2 testing** — same matrix as Round 1, emphasis on the 150%→100% monitor move (the broken case), plus the new-since-2024 checklist (Dashboard, TreeView filter, Event Grid forms).
4. **Decision gate**:
   - PMv2 + fix renders correctly → **adopt PerMonitorV2**, keep the fix (cleaned up) as part of layer 440-1, proceed with the 9 layers (old commits remain reusable).
   - Fix balloons across dozens of custom-paint sites, or still broken → **adopt system mode**, document the cross-monitor softness as a known limitation, proceed with the 9 layers.
5. Either way: update `.github/copilot-instructions.md` + `csharp.instructions.md` with the chosen mode (outstanding commitment), and report the decision + evidence on upstream issue #440 for Erik/Sean.

**Key learnings:**
- Current `main` (2026) diverged heavily from 2024: now includes Dashboard, TreeView filter — old branch never had these. No blind cherry-picking.
- PR #797 used **system** awareness (not PerMonitorV2) — suspected cause of Erik's 100%-scale blur. The app relies on custom paint code (`LogicalToDeviceUnits`), so partial DPI scaling on top of system awareness likely caused the regression.
- **New user-facing UI since 2024 with zero High DPI coverage** (must be tested on every layer/commit): Dashboard tab + `DashboardControl`, TreeView filter box + `TreeViewFilterHelper`, and the entire Event Grid feature (`EventGridConnectForm`, Create Topic/Subscription forms, `PublishEventForm`, `ReceiveEventForm`, `HandleEventGrid*Control`s). This is now baked into the per-layer visual test gate in Phase 2.

## Resolved Decisions

1. **Upstream submission: Option A** — stack in fork + sequential upstream PRs. ✅
2. **Maintainer question timing**: ask when the first PR is ready to target upstream. ✅
3. **Fork issue labels**: `high-dpi` + `pr-N` scheme approved. ✅
4. **`fork-tooling` branch**: **push to origin** ✅ — backed up on github.com/jmoralesv/ServiceBusExplorer, never gets a PR so upstream never sees it.
5. **Layer granularity**: one branch at a time; each layer gated on your visual testing across the monitor matrix before moving to the next. ✅ (per your feedback)

## DPI Mode Test Results (2026-09-20) — Round 7 (after `49af677` AutoScaleMode flip + `e61154a` DpiAwareForm)

| Scenario | Result |
|---|---|
| 4K @ 150% startup | ✅ Still good/crisp (unchanged). |
| Launch FullHD@100% (primary@150%) | ❌ Menu items, Dashboard/Explorer tabs, Refresh row ~1.5× too big vs GA. No visible improvement over R6. |
| Launch 4K@100% (system DPI stale 144) | ⚠️ Log confirms `awareness=2, perMonitorV2=True, DeviceDpi=96, AutoScaleMode=Dpi`; app still slightly bigger than GA sxs. |
| Move 4K@150% → FullHD@100% | ❌ `DPI changed: 144 -> 96` fires; window shrinks but tree/dashboard occupy only top-left (dead space right/bottom), dashboard columns overflow. |
| ConnectForm after move | ❌ Still broken (combobox malformed, txtUri off). |

**Diagnosis (post-R7 analysis):**
1. Shadowing hypothesis REJECTED — MainForm's TEMP `OnHandleCreated` (MainForm.cs:506) DOES call base; all 28 forms correctly reparented to DpiAwareForm; singleton set in ctor (line 289) so StaticWriteToLog is safe from OnHandleCreated.
2. **Root-cause theory (multi-cause):** (a) net472 initial autoscale uses **system DPI** (static `DpiHelper.DeviceDpi`, primary scale at logon) not the monitor DPI → 1.5× at startup when they differ; DpiAwareForm's correction targets this but had NO logging, so R7 can't prove it fired. (b) The oversized elements that persist (MenuStrip/ToolStrip items, custom tab strip, ctor-time custom sizes) are fed by **system-DPI-derived metrics** (`SystemFonts`, ToolStrip renderer metrics, `LogicalToDeviceUnits` calls made in ctors while handle-less controls report system DPI) — a form-level `Scale()` cannot fix those; they need recompute at handle-created/DpiChanged time with the live DeviceDpi.
3. **Action taken:** TEMP logging added to `DpiAwareForm.OnHandleCreated` (logs form name, systemDpi, DeviceDpi, correction fired/skipped — via `MainForm.StaticWriteToLog`). Next targeted round proves/disproves (2a) in one screenshot.
4. Next fixes after confirmation: recompute ctor-time custom sizes (HeaderPanel headerHeight, TreeView ItemHeight, ConnectForm boxes) on handle-created + DpiChanged; MenuStrip/ToolStrip system-DPI gap on net472 likely needs manual ImageScalingSize/font handling (old commits 26–29 territory); dead space after move = splitter/layout re-run.

**Next targeted round (short):** (a) launch FullHD@100% with primary@150% → read `DpiAwareForm:` log line; (b) move 150%→100% → confirm `DPI changed` + layout. Then fix per diagnosis.

## Round 8 — Instrumented round (DpiAwareForm logging) + ROOT CAUSE FOUND (2026-09-20)

Logs proved: (1) Launch FullHD@100% w/ primary@150%: `systemDpi=144, DeviceDpi=144, correction=skipped` and NO `DPI changed` ever fires — net472's `Control.DeviceDpi` reports **system DPI** at handle creation even when Windows created the window directly on the 96 monitor → the DeviceDpi-based guard could never detect the leak. (2) Move 150%→100%: `DPI changed 144→96` fires and the window now renders **correctly** — the move path is FIXED (framework auto-resize + DpiAwareForm OnDpiChanged).

**Fix:** DpiAwareForm now probes `GetDpiForWindow(Handle)` (OS truth) instead of `DeviceDpi` (framework lie at creation); factor = windowDpi/systemDpi. Covers all cases: created-on-96-with-stale-144-system → 0.667; created-on-144 → skip; moves → DpiChanged path. Expected to also fix the "4K@100% with stale system 144" launch and possibly ConnectForm's broken layout (same leak).

**Next round:** (a) launch FullHD@100% w/ primary@150% → expect `windowDpi=96, correction=fired` + correctly-sized UI; (b) launch 4K@100% → same; (c) re-confirm move still good; (d) ConnectForm at both. Residuals after: MenuStrip/ToolStrip system-metric gap (old commits 26–29), "New Version" link overlap, then 440-1 gate → 440-2.

**CORRECTION (user, R8):** the moved-150%→100% window is NOT fully fixed — still oversized: grouper headers, dashboard DataGridView column headers, main-menu headers, Log header + log font. These are the predicted system-DPI-metric class: net472 caches SystemFonts (px-sized at system DPI) and ToolStrip/MenuStrip renderer metrics at system DPI; form-level rescale + DpiChanged re-layout cannot touch them. Needs per-element recompute (fonts, ToolStrip/ImageScalingSize, custom header heights) on DpiChanged — planned as the next increment, partly mapped to old commits 26–33 / layers 440-4/440-5, but MainWindow-visible items (menu, log font, header fonts, dashboard column headers) belong to 440-1's gate.

## Round 9 build ready — `cb3f900` (probe fix + metric recompute, combined with R8's launch test)

Changes: (1) DpiAwareForm probes `GetDpiForWindow` (OS truth) — startup correction can now actually fire; (2) all logical→device conversions routed through DpiAwareForm helpers (HeaderPanel height/icon/padding, Grouper arc, 5 dialogs); (3) new `OnDpiScaleChanged` hook (startup post-correction + every DpiChanged): MainForm recomputes TreeView ItemHeight via `Font.GetHeight(realDpi)` + ToolStrip ImageScalingSize (20 logical, 24 statusStrip), DashboardControl recomputes grid ColumnHeadersHeight (23 logical) at its own OnHandleCreated + on form DpiScaleChanged. Build clean, 106/106 tests pass.

**Deliberately instrumented, not changed:** menu strip font/height and lstLog font — `DpiScaleChanged:` TEMP log reports dpi, menuStrip.Height, menuStrip.Font pt, lstLog.Font pt, treeView.ItemHeight each time it runs, so Round 9 shows whether they're actually stale.

**Round 9 test list:** (a) launch FullHD@100% w/ primary@150% → expect `windowDpi=96, correction=fired` + correctly-sized UI; (b) launch 4K@100% → match GA; (c) 150% launch (regression check); (d) move 150%→100% → headers/tree/dashboard/menus correct or log tells why; (e) ConnectForm at 150% and after move; (f) ParameterForm/DeleteForm at 150% (helper reroute regression check).

## Round 9 RESULTS (2026-09-20) — correction + recompute WORK; remaining issues root-caused

| Scenario | Result |
|---|---|
| Launch FullHD@100% w/ primary@150% | ✅/⚠️ `windowDpi=96, correction=fired` — UI ~correct (was ❌ in R7). Residual: menuStrip.Height=33 (fixed in `9b36cb1`), interval combo clipped ("in"), New-Version link overlap. |
| Launch 4K@100% | ✅ `correction=skipped`, menuStrip.Height=24, "1min" unclipped. |
| Move 4K@150% → FullHD@100% | ✅ `DPI changed 144→96`, menuStrip.Height=23 ✓, ColumnHeadersHeight=23 ✓ (recompute works). |
| Move 4K@100% → FullHD@100% (no DPI change) | ✅ Zero log activity, renders correctly. |
| ConnectForm (150% + after move) | ✅ Much improved vs R7; namespace combobox + txtUri render correctly. Minor: Azure-link overlap. |

**KEY FINDING — "bigger vs GA" is largely the user's own settings, not DPI:** `UserSettings.config` (last written 2026-02-13, months before testing) has `logFontSize=12` + `treeViewFontSize=12`. The dev app faithfully applies them (log shows `lstLog.Font=12pt, treeView.ItemHeight=19`); GA 6.3.1 (confirmed = chocolatey, ProductVersion 6.3.1+05cd956) does not show them in sxs comparisons. **User to reset both to 8.25 via View→Options for apples-to-apples comparisons** (or keep and disregard tree/log size diffs).

**Menu 33px root cause (FIXED, `9b36cb1`):** `mainMenuStrip`/`statusStrip` are constructed WITHOUT the components container (`new StatusStrip()`, MainForm.Designer.cs:57) so the `components.Components` ImageScalingSize loop never reached them (context menus self-add via `new ContextMenuStrip(this.components)` and were covered). Initial autoscale at system-144 bumped ImageScalingSize 20→30 and nothing reset it. Fix: explicit normalization in OnDpiScaleChanged.

**Remaining known residuals (not blocking):**
- Dashboard/Explorer tabs slightly chunky — vanilla TabControl on current main (TabControlHelper exists in tree but MainForm doesn't use it); tab-strip work = layer 440-4.
- Dashboard toolbar: "Sync with treeview" checkbox overlaps Last-refresh/"Loading..." label even at pure 96 DPI, and grid rows use Segoe UI 9pt — both from upstream #866 (Apr 2026), NOT 440-1 changes. Optional diagnostic: sxs a clean upstream-main build vs GA to isolate upstream drift.
- Interval combo clipped ("in") only on correction-fired path — recheck after `9b36cb1`; if still clipped, dashboard toolbar fixed-px layout (DashboardControl.cs:97-134) needs DPI-relative positions.
- "New Version" link overlaps "Microsoft Azure" header text; only appears in dev builds (dev version < 6.3.1).
- Window keeps 150% size after move to 100% (content correct, window roomy) — acceptable.

**Round 10 test list (short):** (a) reset logFontSize/treeViewFontSize to 8.25 in dev Options, sxs vs GA at 100% → expect near-identical; (b) launch FullHD@100% w/ primary@150% → expect menuStrip.Height=24 in log + normal menu; (c) move 150%→100% regression check; (d) interval combo "1min" readable on the (b) path.

## Round 10 RESULTS (2026-09-23) — settings removal works; tiny-treeview regression found + FIXED (`079ccaa`)

| Scenario | Result |
|---|---|
| Launch 4K@150% | ⚠️ `correction=skipped` ✓, lstLog.Font=8.25pt (settings removal works) ✓, ColumnHeadersHeight=34 ✓ — but treeView.ItemHeight=13: rows crammed under the 16px icons. |
| Launch FullHD@100% w/ primary@150% | ⚠️ `correction=fired` ✓, dashboard/grid/menus correct — but treeView.ItemHeight=9: tree unusable, rows overlap. |
| Move 4K@150% → FullHD@100% | ⚠️ Layout, fonts, menus, dashboard all correct now — but treeView.ItemHeight=6, worst cramming. |
| sxs vs GA (100% and 150%) | ✅ Menu bar, toolbar, dashboard grid, log font match GA after settings removal. Remaining "chunky": Dashboard/Explorer tabs (vanilla TabControl — layer 440-4). |

**Root cause (my cb3f900, not the old work):** `UpdateTreeViewItemHeight()` set ItemHeight = ceil(Font.GetHeight(dpi)) — 13-14px @96 / ~21px @144 — replacing the designer baseline 20 logical px that exists to fit the 16px node icons. GA never touches ItemHeight at startup → roomy rows. Log readback oddities (13/9/6 for the same formula) = native comctl32 treeview quirk under PMv2 (TVM_GETITEMHEIGHT scaled), cosmetic in logs only.
**FIX (`079ccaa`):** `DpiAwareForm.ScaleTreeViewItemHeight(treeView)` — ItemHeight = Max(ceil(Font.GetHeight(currentDpi)), ScaleToCurrentDpi(20)). 96dpi→20 (matches GA), 144dpi→30, large user fonts still grow rows. MainForm's 4 call sites delegate to it; SelectEntityForm gains an OnDpiScaleChanged override + honors treeViewFontSize at startup (adapts old d18235a, fixing its px-vs-pt default bug).
**Old-commit verdicts (user's memory):** the remembered commit = **d18235a** (TreeView ItemHeight + fontSize in SelectEntityForm, Dec 2023) → promoted/adapted into 440-1 ✓. **6bfe318** (tab font sizes) touches only OptionForm.Designer.cs → would NOT fix main-window tabs; stays in layer 440-4 (with TabControlHelper).
**Note:** the DpiScaleChanged log's menuStrip.Height lags one layout pass (read before PerformLayout); the TEMP log now also prints ImageScalingSize (the value actually normalized) — Height=33 in R10 logs was stale, menus were visually correct.

**Round 11 test list (short):** (a) launch 4K@100% sxs GA → tree rows roomy, ItemHeight=20 in log; (b) launch 4K@150% → ItemHeight=30, rows roomy; (c) move 150%↔100% both ways → tree stays correct; (d) launch FullHD w/ primary@150% (correction path) → tree correct + menuStrip.ImageScalingSize=20; (e) dead-letter Move/transfer dialog (SelectEntityForm) at 150% → tree rows correct; (f) optional: Options → treeViewFontSize=12 → rows grow on MainForm AND SelectEntityForm.
