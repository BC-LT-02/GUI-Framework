using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Todoly.Core.Helpers;

namespace Todoly.Core.UIElements.Drivers;

internal class BrowserStackOptions : DriverOptions
{
    public BrowserStackOptions(string browser_name, string browser_version)
    {
        BrowserName = browser_name;
        BrowserVersion = browser_version;
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
    public static readonly string BROWSERSTACK_URL = ConfigModel.BROWSERSTACK_URL;
    public static readonly string DriverType = ConfigModel.DriverType;

    public static IWebDriver GetDriver() => new RemoteWebDriver(new Uri(BROWSERSTACK_URL), AddOptions());
    public static DriverOptions AddOptions()
    {
        var capabilities = new Dictionary<string, object>()
        {
            {"browserName", DriverType},
            {"browserVersion", "latest"},
            {"os", "OS X"},
            {"osVersion", "Monterey"},
            { "userName", BROWSERSTACK_USERNAME },
            { "accessKey", BROWSERSTACK_ACCESSKEY },
            { "buildName", "browserstack-build-1" }
        };

        string browserVersion =
            capabilities.ContainsKey("browserVersion") == true ? (string)capabilities["browserVersion"] : "";
        var browserstackOptions = new BrowserStackOptions(
            (string)capabilities["browserName"],
            browserVersion
        );

        browserstackOptions.AddAdditionalOption("bstack:options", capabilities);
        return browserstackOptions;
    }
}
