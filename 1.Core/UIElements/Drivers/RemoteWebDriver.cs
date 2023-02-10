using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace SeleniumTest.Core.RemoteDrivers;

public class RemoteWebDriverFactory
{
    public static IWebDriver GetDriver(string driverType)
    {
        switch (driverType)
        {
            case "Chrome":
                var chrome = new ChromeOptions();
                return RemoteConfigs(chrome);
            case "Edge":
                var edge = new EdgeOptions();
                return RemoteConfigs(edge);
            case "Safari":
                var safari = new SafariOptions();
                return RemoteConfigs(safari);
            case "Firefox":
                var firefox = new FirefoxOptions();
                return RemoteConfigs(firefox);
            default:
                throw new NotImplementedException("Error specifying the driver");
        }
    }

    public static IWebDriver RemoteConfigs(DriverOptions capabilities)
    {
        var driver = new RemoteWebDriver(new Uri("http://localhost:4444/"), capabilities);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(
            ConfigModel.DriverExplicitTimeout
        );
        driver.Manage().Window.Maximize();
        return driver;
    }
}
