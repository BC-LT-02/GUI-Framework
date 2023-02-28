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
                return new ChromeDriver(AddChromeOptions());

            case "Edge":
                return new EdgeDriver();

            case "Safari":
                return new SafariDriver();

            case "Firefox":
                return new FirefoxDriver();

            default:
                throw new NotImplementedException("Error specifying the driver");
        }
    }

    // public static IWebDriver BasicConfigs(IWebDriver driver)
    // {
    //     driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(
    //         ConfigModel.DriverImplicitTimeout
    //     );
    //     driver.Manage().Window.Maximize();
    //     return driver;
    // }

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
