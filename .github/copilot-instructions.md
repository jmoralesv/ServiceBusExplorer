# Copilot Instructions for Service Bus Explorer (Fork)

## Project Overview

**Service Bus Explorer** is a Windows Forms desktop application for managing Azure Service Bus namespaces. It lets users connect to a namespace and administer messaging entities (queues, topics, subscriptions, relays, event hubs, notification hubs), with advanced features like import/export, message testing, and dead-letter handling.

This repository is a **fork** of `paolosalvatori/ServiceBusExplorer`.

### Purpose of This Fork

The primary goal of this fork is to deliver **High DPI support** for the application, tracked in the upstream issue:

- **paolosalvatori/ServiceBusExplorer#440 — "Support High DPI Scaling"**

The app currently renders blurry text and misaligned controls on high-DPI displays. A prior attempt (upstream PR #797) was merged and later reverted (#807) due to regressions (blurry text at 100% scale). This fork takes a fresh approach: **small, reviewable pull requests**, each fixing one area, delivered sequentially to the upstream repository.

When working in this fork, assume High DPI correctness is the overarching concern. Every UI change must be verified against the shared monitor test matrix (see below).

### Technology Stack
- **Application type**: Windows Forms desktop app (`OutputType=WinExe`, `UseWindowsForms=true`)
- **Language**: C# 8 (`LangVersion=8`)
- **Main app framework**: .NET Framework 4.7.2 (`net472`)
- **Class libraries**: .NET Standard 2.0 (`netstandard2.0`)
- **Solution file**: `src/ServiceBusExplorer.sln` (legacy .sln format)
- **Test framework**: xUnit + FluentAssertions
- **CI**: GitHub Actions on `windows-2022`

## Repository Layout

```
src/
├── ServiceBusExplorer/          # Main WinForms app (net472)
│   ├── Controls/                # User controls (Handle*, Test*, Listener, Partition controls)
│   ├── Forms/                   # Forms (MainForm, ConnectForm, ContainerForm, MessageForm, dialogs)
│   ├── Helpers/                 # General helpers (GitHubReleaseProvider, etc.)
│   ├── UIHelpers/               # UI-specific helpers (Grouper, HeaderPanel, ListViewHelper, TabControlHelper, ...)
│   └── ServiceBusExplorer.csproj
├── ServiceBusExplorer.Tests/    # xUnit tests (net472)
├── Common/                      # Shared code (net472)
├── NotificationHubs/            # Notification Hubs logic (net472)
├── ServiceBus/                  # Service Bus logic (netstandard2.0)
├── EventHubs/                   # Event Hubs logic (netstandard2.0)
├── Relay/                       # Relay logic (netstandard2.0)
├── Utilities/                   # Utilities (netstandard2.0)
└── EventGridExplorerLibrary/    # Event Grid explorer library (netstandard2.0)
```

## Build, Test, and Run

All commands run from the `src` directory (matches CI in `.github/workflows/build-test.yml`).

```powershell
# Restore dependencies
dotnet restore

# Build (Release, matches CI)
dotnet build -c Release

# Build (Debug, for local development)
dotnet build -c Debug

# Run tests
dotnet test -c Release

# Run the app (after building)
.\ServiceBusExplorer\bin\Release\ServiceBusExplorer.exe
```

**Note:** This is a .NET Framework 4.7.2 WinForms app built with the modern `dotnet` CLI via SDK-style projects. It builds on Windows only (WinForms + net472). Do not attempt `dotnet run` — build and launch the `.exe`.

## High DPI Guidance (Core to This Fork)

### Approach
- **DPI awareness mode — CURRENTLY UNDER TEST**: We are actively testing both **PerMonitorV2** and **system** awareness to decide which to adopt. The prior attempt (PR #797) declared **`system`** awareness in `app.manifest`, which is believed to be the cause of the 100%-scale blurriness that led to the revert (#807). The manifest does **not** exist on `main` today (removed by the revert). **Once testing concludes, this file and `csharp.instructions.md` MUST be updated to record the chosen mode** (do not forget this). Some older code (e.g., the CheckBoxList spacing fix) already replicated PerMonitorV2-style behavior.
- **Framework helpers**: Use .NET Framework 4.7.2 high-DPI APIs such as `LogicalToDeviceUnits` and `ScaleBitmapLogicalToDevice`
- **Layout strategy**: Prefer `TableLayoutPanel` for scaling/resizing child controls instead of custom paint/resize logic where possible
- **Centralize calculations**: Put DPI math in helpers (e.g., `HeaderPanel.LogicalToDeviceUnits`) rather than repeating it per form
- **App config**: `EnableWindowsFormsHighDpiAutoResizing=true` in `App.config` (used by the prior attempt)

### Shared Monitor Test Matrix (Acceptance)

Every High DPI change must be verified on these configurations. The 100%-scale entries are **mandatory** — the previous revert (#807) was caused by a 100%-scale regression.

| Owner | Monitor | Native resolution | Scale |
|---|---|---|---|
| jmoralesv | ThinkVision E28u-20 | 3840 × 2160 (4K) | 150% |
| jmoralesv | ThinkPad P73 | 1920 × 1080 (Full HD) | 100% |
| jmoralesv | ThinkPad P16 | 3840 × 2400 (4K) | 250% |
| ErikMogensen (maintainer) | Dell | 3440 × 1440 | 100% |
| ErikMogensen (maintainer) | Surface | 2400 × 1600 | 125% |
| ErikMogensen (maintainer) | Surface | 2400 × 1600 | 150% |

At minimum, verify each change on the **ThinkPad P73 (Full HD @ 100%)** plus **one 4K monitor** before considering a layer complete.

## Conventions

### Code Quality
- **TreatWarningsAsErrors = true** — all code must build without warnings
- **Minimal comments** — code should be self-explanatory; comment only complex logic
- **No `#region` directives**
- Follow existing naming and formatting patterns in the codebase

### Formatting
- Follow `src/.editorconfig`: CRLF line endings, final newline, 4-space indent for `.cs`, 2-space for `.config`

### Detailed C# Rules
See `.github/instructions/csharp.instructions.md` for C#-specific conventions.

## Git & Contribution Workflow (Fork-Specific)

- The upstream repo is `paolosalvatori/ServiceBusExplorer`; this fork is `jmoralesv/ServiceBusExplorer`.
- High DPI work is split into **stacked feature branches** built locally, then submitted to upstream as **sequential PRs** (one at a time, waiting for each to merge before the next).
- Fork issues track each change set and reference upstream issue #440.
- The `fork-tooling` branch (which contains this file) is fork-only and is **never** submitted upstream; feature branches are cleaned of it before opening an upstream PR.
- When referencing the upstream issue in commits/PRs, use the full form `paolosalvatori/ServiceBusExplorer#440`.
