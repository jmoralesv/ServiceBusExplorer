---
description: 'Guidelines for C# development in the Service Bus Explorer fork'
applyTo: '**/*.cs'
---

# C# Development for Service Bus Explorer

## C# Version and Features
- **Language version**: C# 8 (`LangVersion=8`)
- **Target frameworks**: .NET Framework 4.7.2 (`net472`) for the app and some libraries; .NET Standard 2.0 (`netstandard2.0`) for the rest
- Use modern features up to C# 8 where appropriate (e.g., `using` declarations, switch expressions, pattern matching, nullable reference type syntax)
- **Do not** use features newer than C# 8 (no C# 9+ records, no file-scoped namespaces, no primary constructors, no collection expressions) — the compiler is pinned to C# 8

## Code Style

### No Regions
- **Never use `#region` directives** — they are not part of the coding standards

### Comments
- **Minimal comments**: only add comments for complex logic that isn't self-explanatory
- Code should be self-documenting through clear naming
- For complex algorithms or DPI calculations, explain the "why", not the "what"

### Code Reuse
- Prefer extracting common logic into methods or helper classes
- Avoid code duplication — refactor when you see patterns repeating
- Use the SOLID principles to guide design
- Use the DRY principle to avoid redundancy and foster reuse and maintainability
- For High DPI work specifically: centralize DPI math in UI helpers (`UIHelpers/`) rather than duplicating `LogicalToDeviceUnits` calls across forms and controls

## Naming Conventions

- PascalCase for class names, method names, properties, and public members
- camelCase for private fields and local variables
- Prefix interface names with `I` (e.g., `IServiceBusHelper`)
- Follow the existing naming patterns in the surrounding code — this is a mature codebase with established conventions; consistency with neighbors matters more than introducing new patterns

## Formatting

- Follow `src/.editorconfig`: CRLF line endings, final newline at end of file, 4-space indentation for `.cs` files
- Use `nameof` instead of string literals when referring to member names
- This codebase uses **traditional (block-scoped) namespaces** — do not convert to file-scoped namespaces (not supported in C# 8 anyway)

## Project Structure

- **Main app** (`src/ServiceBusExplorer/`): WinForms forms and user controls
  - `Forms/` — top-level forms (MainForm, ConnectForm, ContainerForm, MessageForm, dialogs)
  - `Controls/` — user controls; two families dominate: `Handle*Control` (entity management) and `Test*Control` (send/receive testing), plus `ListenerControl` / `PartitionListenerControl`
  - `UIHelpers/` — UI helpers and custom controls (Grouper, HeaderPanel, ListViewHelper, TabControlHelper, CheckistBoxExtensions, etc.)
  - `Helpers/` — non-UI helpers
- **Libraries** (`src/ServiceBus`, `src/EventHubs`, `src/Relay`, `src/Utilities`, `src/Common`, `src/NotificationHubs`, `src/EventGridExplorerLibrary`): service logic and shared code
- **Tests** (`src/ServiceBusExplorer.Tests/`): xUnit tests

## WinForms and High DPI (Core Concern of This Fork)

- **DPI awareness mode: PerMonitorV2** (decided 2026-09-20 after 5 test rounds). `system` awareness was rejected: it renders at the system DPI (primary monitor's scale at logon) and Windows bitmap-scales the window on other monitors — that is the blur that caused revert #807 (reproduced: `DeviceDpi=144` logged on a 96-DPI monitor). PerMonitorV2 renders natively per monitor and is migration-forward (.NET 6+ invests in PMv2; modern .NET still defaults to `SystemAware`, semantically equal to net472 `system`). Declared in `app.manifest` + `App.config` (`DpiAwareness=PerMonitorV2`).
- **Always pair PMv2 with `AutoScaleMode.Dpi`** (`AutoScaleDimensions = 96F, 96F`) + `EnableWindowsFormsHighDpiAutoResizing=true` inside `System.Windows.Forms.ApplicationConfigurationSection` — never in `appSettings`, where WinForms silently ignores it. `AutoScaleMode.Font` is non-linear across DPI changes; do not use it.
- Custom-painted controls with hardcoded logical sizes must recompute on `DpiChanged` using the new `DeviceDpi` / `LogicalToDeviceUnits`, then re-layout and repaint.
- Use .NET Framework 4.7.2 high-DPI APIs: `LogicalToDeviceUnits`, `ScaleBitmapLogicalToDevice`, `DeviceDpi`
- **Prefer `TableLayoutPanel`** for scaling/resizing child controls over custom paint/resize logic
- When fixing layout in a control, also update its `.Designer.cs` consistently
- Custom `CustomPaint` handlers must account for the current DPI
- Verify every UI change against the shared monitor test matrix in `.github/copilot-instructions.md` — the 100%-scale configurations are mandatory

## Nullability

- Nullable reference types are **not enabled** project-wide (`net472` / `netstandard2.0` with C# 8). Do not add `#nullable enable` broadly or sprinkle `?` annotations without a deliberate, scoped decision
- Continue using explicit null checks (`== null` / `!= null`) as the existing code does

## Error Handling

- Use try-catch for expected exceptions (Service Bus calls, I/O)
- Log to the application's log panel via the existing logging mechanism (`WriteToLog`) rather than introducing new logging frameworks
- Surface user-facing errors through the app's existing dialog/message patterns

## Testing

- **xUnit** is the test framework, **FluentAssertions** for assertions
- Tests live in `src/ServiceBusExplorer.Tests/`
- Run with `dotnet test -c Release` from `src`
- **Do not emit "Arrange", "Act", "Assert" comments** — code should be clear
- Follow existing test naming conventions in the project
- Much of this app is UI-heavy and historically hard to unit test; prefer testing logic in helpers/managers over pixel-level UI behavior. High DPI correctness is validated through the manual monitor test matrix, not unit tests.

## Code Analysis

- **TreatWarningsAsErrors = true** — all code must build without warnings
- Fix warnings; don't suppress unless absolutely necessary with clear justification

## Security

- **Never commit connection strings or secrets** to the repository
- Service Bus connection strings are provided at runtime through the Connect dialog
