# Repository Guidelines

## Project Structure & Module Organization

- `ServiceModelEx/` contains the shared WCF library, organized by features such as `Hosting/`, `ServiceBus/`, `Discovery/`, `Security/`, and `Transactions/`.
- `Essentials/ServiceBus/TCP Relay Binding/` and `Essentials/ServiceBus/TCP Relay Streamed Binding/` each contain a solution with Windows Forms `Host/` and `Client/` applications referencing the shared library.
- Forms use paired `.cs`, `.Designer.cs`, and `.resx` files. Embedded assets live in resource files and `Resources/` directories. No dedicated test project is present.

## Build, Test, and Development Commands

Use Windows with Visual Studio/MSBuild, the .NET Framework 4.6.2 targeting pack, and NuGet CLI. Run these commands from the repository root:

```powershell
nuget restore "ServiceModelEx/ServiceModelEx.sln"
nuget restore "Essentials/ServiceBus/TCP Relay Binding/TCP Relay Binding.sln"
msbuild "Essentials/ServiceBus/TCP Relay Binding/TCP Relay Binding.sln" /p:Configuration=Debug
```

Restore downloads `packages.config` dependencies; MSBuild compiles the host, client, and library. Repeat the sample commands with `TCP Relay Streamed Binding` for the streaming example. Some shared-library `HintPath` entries reference absent sample directories; resolve these references against restored packages before expecting a clean build.

For local execution, configure matching host/client endpoints and credentials in `App.config`, then launch `Host/bin/Debug/Host.exe` followed by `Client/bin/Debug/Client.exe` within the selected sample directory.

## Coding Style & Naming Conventions

Match the surrounding C# style: sample applications use four-space indentation; much of `ServiceModelEx` uses three spaces. Keep opening braces on separate lines. Use PascalCase for types and methods, `I` prefixes for interfaces, and existing field conventions (`m_Name` or `_name`) within each file. Preserve matching WCF contracts in host and client. Use Visual Studio designers for generated form/resource files. No repository-wide formatter configuration is present.

## Testing Guidelines

No automated testing framework or coverage threshold is configured. Build both affected solutions and manually exercise host startup, client calls, and streaming behavior where applicable. Record configuration prerequisites, steps, and results in the pull request.

## Commit & Pull Request Guidelines

Use Conventional Commits with concise, imperative, one-line subjects: `type(scope): description`, with an optional scope. Examples: `fix(relay): close the client channel` and `docs: clarify setup`. Pull requests should explain behavior changes, identify affected samples, link relevant issues, and include validation results. Include screenshots for Windows Forms UI changes.

## Security & Configuration

Keep Azure credentials and SAS keys out of commits and screenshots. Review `App.config` changes before committing, and exclude generated `bin/`, `obj/`, and restored package output.
