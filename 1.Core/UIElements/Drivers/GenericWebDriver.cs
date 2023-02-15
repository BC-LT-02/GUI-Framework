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
        return key.Equals("Local")
            ? WebDriverFactory.GetDriver(ConfigModel.DriverType)
            : RemoteWebDriverFactory.GetDriver(ConfigModel.DriverType);
    }
}
