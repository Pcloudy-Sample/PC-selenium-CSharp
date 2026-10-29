<div align="center">

# Run Selenium Tests with C# on Pcloudy

[![Pcloudy](https://img.shields.io/badge/Made%20by-Pcloudy-1a73e8?style=for-the-badge)](https://www.pcloudy.com) [![Selenium](https://img.shields.io/badge/Selenium-.NET-blue?style=for-the-badge)](https://www.selenium.dev/)

</div>

## Getting Started

[Pcloudy](https://www.pcloudy.com) is a cloud testing platform that gives you access to real browsers and devices directly from your automation scripts. This project is a simple C# Selenium example showing how to run browser automation on Pcloudy’s remote Selenium grid.

## Prerequisites

- .NET SDK 8.0 or higher
- A [Pcloudy account](https://www.pcloudy.com) with a valid email and access key
- Network access to the Pcloudy Selenium endpoint

## Getting Started

Clone the project and restore dependencies:

```powershell
git clone https://github.com/Pcloudy-Sample/PC-selenium-CSharp.git
cd PC-selenium-CSharp
dotnet restore
```

### Configure your credentials

Open `Program.cs` and update the `pcloudyOptions` dictionary with your Pcloudy account values.

```csharp
var pcloudyOptions = new Dictionary<string, object>
{
    ["userName"] = "YOUR_PLOUDY_EMAIL",
    ["accessKey"] = "YOUR_PLOUDY_ACCESS_KEY",
    ["os"] = "Windows",
    ["osVersion"] = "11",
    ["browserVersion"] = "127",
    ["seleniumVersion"] = "4.18.1",
    ["project"] = "Project_1",
    ["build"] = "Production Run",
    ["name"] = "Wikipedia Test",
    ["tag"] = "Wikipedia",
    ["local"] = false,
    ["pCloudy_EnableVideo"] = true,
    ["idleTimeout"] = 10
};
```

> **Note:** These values are hardcoded for the sample. For real use, replace them with environment variables or a secure secret store.

## Running the Sample

Run the sample with:

```powershell
dotnet run --project PC-selenium-CSharp.csproj
```

The sample launches a remote Chrome browser on Pcloudy, opens `https://www.wikipedia.org/`, searches for `Selenium`, and captures a screenshot.

## Key files

- `Program.cs` — Selenium test runner and Pcloudy capability configuration
- `PC-selenium-CSharp.csproj` — .NET project file with Selenium dependencies

## Capabilities used in this sample

| Capability | Description |
|---|---|
| `userName` | Pcloudy account email |
| `accessKey` | Pcloudy access key |
| `os` | Operating system to run on Pcloudy |
| `osVersion` | OS version to target |
| `browserVersion` | Browser version to use |
| `seleniumVersion` | Selenium version to use |
| `project` | Pcloudy project name |
| `build` | Build name displayed in Pcloudy |
| `name` | Test name displayed in Pcloudy |
| `tag` | Test tag |
| `local` | Local testing flag |
| `pCloudy_EnableVideo` | Enable video recording |
| `idleTimeout` | Idle session timeout in minutes |

## Important notes

- Do not set `options.BrowserVersion` on `ChromeOptions` if `browserVersion` is already specified in `pcloudy:options`.
- The Pcloudy Selenium hub URL is configured in `Program.cs` as `_hubUrl`.
- Screenshots are saved to the `Screenshots/` folder.

## Troubleshooting

- If the session fails during creation, verify your Pcloudy credentials and hub URL.
- If the browser does not start, check your network access to the Pcloudy Selenium endpoint.
- If the build fails, make sure the project is restored and the correct .NET SDK is installed.

## Customization

- Change `browserVersion` inside `pcloudyOptions` to target a different browser version.
- Update `project`, `build`, `name`, and `tag` to reflect your test run.
- Add more Selenium actions after `driver.Navigate().GoToUrl("https://www.wikipedia.org/")`.

## Browser support

This sample is designed to work with any browser supported by Pcloudy. To target a different browser, update the Selenium options object, set the appropriate `browserName`, and adjust `pcloudyOptions["browserVersion"]` for the browser/version you want to use.



## Project Structure

```
PC-selenium-CSharp/
├── PC-selenium-CSharp.csproj    # .NET project file
├── Program.cs                   # Selenium test runner and Pcloudy configuration
└── README.md                    # Project documentation
```

## API Documentation

For more Pcloudy integration information, see:

- [Pcloudy API Documentation](https://content.pcloudy.com/apidocs/index.html)

## Learn More

- [Pcloudy Website](https://www.pcloudy.com)

## Contributions

Contributions are welcome. Open an issue before submitting a pull request.
