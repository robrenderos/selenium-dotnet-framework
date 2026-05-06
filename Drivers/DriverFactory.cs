using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

public static class DriverFactory
{
    public static IWebDriver GetDriver(string browser, bool headless = false, bool remote = false)
    {
        IWebDriver driver;
        Uri gridUrl = new Uri("http://localhost:4444/wd/hub"); // Standard Selenium Grid URL

        switch (browser.ToLower())
        {
            case "chrome":
                var chromeOptions = new ChromeOptions();
                if (headless) chromeOptions.AddArgument("--headless=new");
                chromeOptions.AddArgument("--incognito");
                chromeOptions.AddArgument("--start-maximized");

                driver = remote 
                    ? new RemoteWebDriver(gridUrl, chromeOptions) 
                    : new ChromeDriver(chromeOptions);
                break;

            case "firefox":
                var firefoxOptions = new FirefoxOptions();
                if (headless) firefoxOptions.AddArgument("-headless");
                firefoxOptions.AddArgument("-private");

                driver = remote 
                    ? new RemoteWebDriver(gridUrl, firefoxOptions) 
                    : new FirefoxDriver(firefoxOptions);
                break;

                case "edge": // <--- ADD THIS CASE
        var edgeOptions = new EdgeOptions();
        if (headless) edgeOptions.AddArgument("--headless");
        edgeOptions.AddArgument("-inprivate"); // Edge uses -inprivate instead of --incognito
        
        driver = remote ? new RemoteWebDriver(gridUrl, edgeOptions) : new EdgeDriver(edgeOptions);
        break;

            default:
                throw new ArgumentException($"Browser '{browser}' not supported");
        }

        return driver;
    }
}