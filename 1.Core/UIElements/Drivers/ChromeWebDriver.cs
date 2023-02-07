using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.Core;
using SeleniumTest.Core.Interfaces;

namespace SeleniumTest.Core.Drivers;

public class ChromeWebDriver : IGenericWebDriver
{
    private readonly IWebDriver _driver;

    public ChromeWebDriver()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(
            ConfigModel.DriverExplicitTimeout
        );
        _driver.Manage().Window.Maximize();
    }

    public IWebDriver Instance()
    {
        return _driver;
    }

    public void Dispose()
    {
        _driver.Dispose();
    }
}
