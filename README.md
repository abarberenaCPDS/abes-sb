# abes-sb

[![C#](https://img.shields.io/badge/language-C%23-239120?logo=csharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![.NET Framework 4.6.2](https://img.shields.io/badge/.NET_Framework-4.6.2-512BD4?logo=.net&logoColor=white)](https://dotnet.microsoft.com/download/dotnet-framework/net462)
[![Windows](https://img.shields.io/badge/platform-Windows-0078D4?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![WCF](https://img.shields.io/badge/communication-WCF-5C2D91)](https://learn.microsoft.com/dotnet/framework/wcf/)
[![Azure Service Bus](https://img.shields.io/badge/Azure_Service_Bus-relay-0078D4?logo=microsoftazure&logoColor=white)](https://azure.microsoft.com/products/service-bus)
[![Legacy samples](https://img.shields.io/badge/status-legacy-lightgrey)](#-about)

C# examples of WCF communication through Azure Service Bus relay bindings, with Windows Forms clients and hosts. The repository includes the shared ServiceModelEx library for WCF hosting, discovery, security, transactions, and other infrastructure.

These are legacy .NET Framework samples using `WindowsAzure.ServiceBus` 4.1.6 and `netTcpRelayBinding`.

## 📖 About

This repository is a hands-on reference for classic WCF communication over Azure Service Bus relay bindings. It includes Windows Forms clients and hosts plus the shared `ServiceModelEx` library, which provides WCF hosting, discovery, security, transactions, and related infrastructure.

These are legacy .NET Framework samples using `WindowsAzure.ServiceBus` 4.1.6 and `netTcpRelayBinding`. They are intended for learning and maintenance of existing applications rather than new development.

## 🗂️ Samples and layout

| Path | Purpose |
| --- | --- |
| `Essentials/ServiceBus/TCP Relay Binding/` | Client invokes `MyMethod()`; the host displays an incrementing counter. |
| `Essentials/ServiceBus/TCP Relay Streamed Binding/` | Client requests a WAV file with `StreamMusic()` and plays the returned stream. |
| `ServiceModelEx/` | Shared library referenced by both sample solutions. |
| [AGENTS.md](AGENTS.md) | Contributor workflow and coding conventions. |

Each sample has its own `.sln`, `Host/`, and `Client/`. Forms and embedded resources are stored alongside their source files.

## ✅ Prerequisites

- Windows with Visual Studio supporting C# desktop development, MSBuild, and the .NET Framework 4.6.2 targeting pack.
- NuGet CLI available as `nuget` in a Visual Studio Developer PowerShell session.
- An Azure relay namespace and compatible relay endpoints, with SAS credentials for the host and client.

## 🔨 Restore and build

From the repository root, restore all three solutions:

```powershell
nuget restore "ServiceModelEx/ServiceModelEx.sln"
nuget restore "Essentials/ServiceBus/TCP Relay Binding/TCP Relay Binding.sln"
nuget restore "Essentials/ServiceBus/TCP Relay Streamed Binding/TCP Relay Streamed Binding.sln"
```

**Dependency-path issue:** `ServiceModelEx.csproj` contains package `HintPath` entries pointing to absent `Queued Services/Response Service -  ResponseScope/` and `Essentials/MEX Explorer/` directories. Before building, use Visual Studio's References dialog to point the following assemblies to their restored copies under `ServiceModelEx/packages/`:

- `Microsoft.ServiceBus.dll`: `WindowsAzure.ServiceBus.4.1.6/lib/net45/`
- `Microsoft.WindowsAzure.Configuration.dll`: `Microsoft.WindowsAzure.ConfigurationManager.2.0.0.0/lib/net40/`

Other shared-library package paths point into the streamed sample's `packages/` directory, which is why both sample restores are listed above.

Build each sample and its shared-library dependency:

```powershell
msbuild "Essentials/ServiceBus/TCP Relay Binding/TCP Relay Binding.sln" /p:Configuration=Debug
msbuild "Essentials/ServiceBus/TCP Relay Streamed Binding/TCP Relay Streamed Binding.sln" /p:Configuration=Debug
```

## ⚙️ Configure and run

1. In the chosen sample's `Host/App.config` and `Client/App.config`, replace `[DEMO]` in the endpoint addresses with your namespace. Keep the host/client addresses aligned: `/MyService` for the counter sample or `/Music` for streaming.
2. Set `sb-key-name` and `sb-key-value` to the appropriate SAS policy name and key in both applications. Keep credentials out of commits and screenshots.
3. For streaming, check the client's `asset-name` setting. The supplied `m-i.wav` is copied to the host's output `Resources/` directory during the build.
4. Build after changing configuration. Start `Host.exe` from the selected sample's `Host/bin/Debug/` directory, then start `Client.exe` from `Client/bin/Debug/`. Run the streamed host with its output directory as the working directory so it can find `Resources/`.
5. Use the client button to invoke the service. Confirm that the counter increases or that the audio plays, then close the client before the host.

## 🧪 Validation and contributing

There is no automated test suite or CI workflow in this repository. Validate changes by building affected solutions on Windows and exercising the corresponding host/client interaction. Include reproduction steps and results in pull requests; include screenshots for UI changes.

Use [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) with one-line subjects, such as `fix(relay): close the client channel on exit` or `docs: clarify streaming setup`. See [AGENTS.md](AGENTS.md) for local style conventions.

## 📄 Licensing

The ServiceModelEx distribution includes an [IDesign licence](ServiceModelEx/IDesign%20Licence.pdf). Review its terms before reusing or redistributing that code. No repository-wide licence file is provided.
