using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

await new PcloudySeleniumRunner().RunAsync();

public class PcloudySeleniumRunner
{
    private readonly string _hubUrl = "https://browser.device.pcloudy.com/seleniumcloud/wd/hub";

    public async Task RunAsync()
    {
        RemoteWebDriver? driver = null;

        try
        {
           var pcloudyOptions = new Dictionary<string, object>
{
    ["userName"] = "Your_Username",
    ["accessKey"] = "Your_Access_Key",

    ["os"] = "Windows",
    ["osVersion"] = "11",
    ["browserVersion"] = "144",
    ["seleniumVersion"] = "4.18.1",

    ["project"] = "Project_1",
    ["build"] = "Production Run",
    ["name"] = "Wikipedia Test",
    ["tag"] = "Wikipedia",

    ["local"] = false,
    ["pCloudy_EnableVideo"] = true,
    ["idleTimeout"] = 10
};

            Console.WriteLine("========== pCloudy Options ==========");
            Console.WriteLine(JsonSerializer.Serialize(
                pcloudyOptions,
                new JsonSerializerOptions { WriteIndented = true }));

            var options = new ChromeOptions();

            options.PlatformName = "Windows";

            // IMPORTANT:
            // Do NOT set options.BrowserVersion here.
            // pCloudy will use browserVersion from pcloudy:options.

            options.AddAdditionalOption("pcloudy:options", pcloudyOptions);

            Console.WriteLine();
            Console.WriteLine("Connecting to pCloudy Selenium Grid...");
            Console.WriteLine(_hubUrl);

            var watch = Stopwatch.StartNew();

            driver = new RemoteWebDriver(
                new Uri(_hubUrl),
                options.ToCapabilities(),
                TimeSpan.FromMinutes(5));

            watch.Stop();

            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.WriteLine("Session Created Successfully");
            Console.WriteLine($"Time Taken : {watch.Elapsed}");
            Console.WriteLine($"Session ID : {driver.SessionId}");
            Console.WriteLine("======================================");

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Manage().Window.Maximize();

          Console.WriteLine("Opening Wikipedia...");

driver.Navigate().GoToUrl("https://www.wikipedia.org/");

var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

// Step 1: Verify page title
Console.WriteLine($"Page Title: {driver.Title}");

// Step 2: Search for Selenium
var searchBox = wait.Until(d => d.FindElement(By.Name("search")));
searchBox.Clear();
searchBox.SendKeys("Selenium");
searchBox.SendKeys(Keys.Enter);



// Step 9: Capture screenshot
CaptureScreenshot(driver);

// Step 10: Print success message
Console.WriteLine("Wikipedia Selenium test completed successfully.");

await Task.CompletedTask;
            CaptureScreenshot(driver);

            
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("============= ERROR =============");
            Console.WriteLine(ex.ToString());
            Console.WriteLine("=================================");
            throw;
        }
        finally
        {
            if (driver != null)
            {
                Console.WriteLine("Closing browser...");
                driver.Quit();
            }
        }
    }

    private static void CaptureScreenshot(RemoteWebDriver driver)
    {
        try
        {
            var folder = Path.Combine(AppContext.BaseDirectory, "Screenshots");
            Directory.CreateDirectory(folder);

            var fileName = $"Screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            var path = Path.Combine(folder, fileName);

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path);

            Console.WriteLine($"Screenshot saved: {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to save screenshot: {ex.Message}");
        }
    }
}