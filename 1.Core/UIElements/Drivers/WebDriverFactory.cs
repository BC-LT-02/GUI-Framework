using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using Todoly.Core.Helpers;

namespace Todoly.Core.UIElements.Drivers;

public class WebDriverFactory
{
    public static IWebDriver GetDriver(string driverType)
    {
        switch (driverType)
        {
            case "Chrome":
                var chrome = new ChromeDriver();
                return BasicConfigs(chrome);
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
                throw new NotImplementedException("Error specifying the driver");
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
}
