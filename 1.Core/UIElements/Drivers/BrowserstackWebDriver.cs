using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using Todoly.Core.Helpers;

namespace Todoly.Core.UIElements.Drivers;

internal class BrowserStackOptions : DriverOptions
{
    public BrowserStackOptions(string browser_name, string browser_version)
    {
        BrowserName = browser_name;
        BrowserVersion = browser_version;
    }

    [Obsolete]
    public override void AddAdditionalCapability(string capabilityName, object capabilityValue)
    {
        AddAdditionalOption(capabilityName, capabilityValue);
    }

    public override ICapabilities ToCapabilities()
    {
        IWritableCapabilities capabilities = GenerateDesiredCapabilities(true);
        return capabilities.AsReadOnly();
    }
}

public class BrowserstackWebDriverFactory
{
    public static readonly string BROWSERSTACK_USERNAME = ConfigModel.BROWSERSTACK_USERNAME;
    public static readonly string BROWSERSTACK_ACCESSKEY = ConfigModel.BROWSERSTACK_ACCESSKEY;

    public static IWebDriver GetDriver()
    {
        string driverType = ConfigBuilder.Instance.GetString("ui", "DriverType");
        switch (driverType)
        {
            case "Chrome":
                var chrome = new RemoteWebDriver(
                    new Uri("https://hub.browserstack.com/wd/hub/"),
                    AddOptions()
                );
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

    public static DriverOptions AddOptions()
    {
        Dictionary<string, object> cap = new Dictionary<string, object>();

        cap.Add("browserName", "Edge");
        cap.Add("browserVersion", "latest");
        cap.Add("os", "OS X");
        cap.Add("osVersion", "Monterey");

        string build_name = "browserstack-build-1";
        cap.Add("userName", BROWSERSTACK_USERNAME);
        cap.Add("accessKey", BROWSERSTACK_ACCESSKEY);
        cap.Add("buildName", build_name);
        string browserVersion =
            cap.ContainsKey("browserVersion") == true ? (string)cap["browserVersion"] : "";
        var browserstackOptions = new BrowserStackOptions(
            (string)cap["browserName"],
            browserVersion
        );
        browserstackOptions.AddAdditionalOption("bstack:options", cap);
        return browserstackOptions;
    }
}
