using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.Core.Drivers;
using Todoly.Core.Helpers;

namespace Todoly.Core.UIElements.Drivers;

public class GenericWebDriver
{
    private static IWebDriver? _driver = null;
    public static IWebDriver Instance => _driver = _driver == null ? LoadDriver() : _driver;

    public static WebDriverWait Wait =>
        new WebDriverWait(Instance, TimeSpan.FromSeconds(ConfigModel.DriverExplicitTimeout));

    public static void Dispose()
    {
        if (_driver != null)
        {
            _driver!.Dispose();
            _driver = null;
        }
    }

    public static IWebDriver LoadDriver()
    {
        var key = ConfigBuilder.Instance.GetString("ui", "DriverLocation");
        IWebDriver driver;
        switch (key)
        {
            case "Local":
                driver = WebDriverFactory.GetDriver(ConfigModel.DriverType);
                break;
            case "BrowserStack":
                driver = BrowserstackWebDriverFactory.GetDriver(ConfigModel.DriverType);
                break;
            default:
                driver = RemoteWebDriverFactory.GetDriver(ConfigModel.DriverType);
                break;
        }

        return BasicConfigs(driver);
    }

    public static IWebDriver BasicConfigs(IWebDriver driver)
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(
            ConfigModel.DriverImplicitTimeout
        );
        driver.Manage().Window.Maximize();
        return driver;
    }

    public static void AcceptAlert()
    {
        Instance.SwitchTo().Alert().Accept();
    }
}
