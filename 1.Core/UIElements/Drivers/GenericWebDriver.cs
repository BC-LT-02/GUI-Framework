﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Todoly.Core.Helpers;

namespace Todoly.Core.UIElements.Drivers;
public class GenericWebDriver
{
    private static IWebDriver? _driver = null;
    public static IWebDriver Instance =>
        _driver = _driver == null ? WebDriverFactory.GetDriver(ConfigModel.DriverType) : _driver;

    public static WebDriverWait Wait => new WebDriverWait(Instance, TimeSpan.FromSeconds(30));

    public static void Dispose()
    {
        _driver!.Dispose();
        _driver = null;
    }
}