using System;
using OpenQA.Selenium;

namespace SeleniumTest.Core.Interfaces;

public interface IGenericWebDriver : IDisposable
{
    public IWebDriver Instance();
}
