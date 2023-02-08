using OpenQA.Selenium;

namespace SeleniumTest.Core.Drivers;

public class GenericWebDriver
{
    private static IWebDriver? _driver = null;
    public static IWebDriver Instance =>
        _driver = _driver == null ? WebDriverFactory.GetDriver(ConfigModel.DriverType) : _driver;

    public static void Dispose()
    {
        _driver!.Dispose();
        _driver = null;
    }
}
