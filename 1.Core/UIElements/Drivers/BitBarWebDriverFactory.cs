using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Remote;
using Todoly.Core.Helpers;

namespace Todoly.Core.UIElements.Drivers;

public class BitBarWebDriverFactory
{
    public static IWebDriver GetDriver()
    {
        string driverType = ConfigBuilder.Instance.GetString("BITBAR-BROWSER");
        string uri = ConfigBuilder.Instance.GetString("BITBAR-ENDPOINT");
        switch (driverType)
        {
            case "Chrome":
                var chrome = new RemoteWebDriver(new Uri(uri), AddChromeOptions());
                return chrome;
            case "Edge":
                var edge = new EdgeDriver();
                return BasicConfigs(edge);
            case "Safari":
                var safari = new SafariDriver();
                return BasicConfigs(safari);
            case "Firefox":
                var firefox = new FirefoxDriver();
                return BasicConfigs(firefox);
            default:
                throw new NotImplementedException("Error specifying the BitBar driver");
        }
    }

    public static IWebDriver BasicConfigs(IWebDriver driver)
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(
            ConfigModel.DriverImplicitTimeout
        );
        driver.Manage().Window.Maximize();
        return driver;
    }

    public static RemoteSessionSettings AddChromeOptions()
    {
        RemoteSessionSettings options = new RemoteSessionSettings();
        options.AddMetadataSetting("platform", "Windows");
        options.AddMetadataSetting("osVersion", "10");
        options.AddMetadataSetting("browserName", "chrome");
        options.AddMetadataSetting("version", "109");
        options.AddMetadataSetting("resolution", "1920x1080");
        options.AddMetadataSetting(
            "bitbar_apiKey",
            ConfigBuilder.Instance.GetString("BITBAR-APIKEY")
        );
        options.AddMetadataSetting(
            "bitbar_project",
            ConfigBuilder.Instance.GetString("BITBAR-PROJECT")
        );
        /*
        */
        return options;
    }
}
