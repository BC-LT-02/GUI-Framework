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
        IWebDriver driver;
        switch (driverType)
        {
            case "Chrome":
                driver = new ChromeDriver(AddChromeOptions());
                break;
            case "Edge":
                driver = new EdgeDriver();
                break;
            case "Safari":
                driver = new SafariDriver();
                break;
            case "Firefox":
                driver = new FirefoxDriver();
                break;
            case "BrowserStack":
                driver = BrowserstackWebDriverFactory.GetDriver();
                break;
            default:
                throw new NotImplementedException("Error specifying the driver");
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

    public static ChromeOptions AddChromeOptions()
    {
        var chromeOptions = new ChromeOptions();
        if (ConfigModel.DriverMode == "Headless")
        {
            chromeOptions.AddArgument("--headless");
        }

        return chromeOptions;
    }
}
