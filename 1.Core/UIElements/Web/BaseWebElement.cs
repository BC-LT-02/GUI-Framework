using OpenQA.Selenium;
using SeleniumTest.Core.Drivers;
using SeleniumTest.Core.Interfaces;
using UIElements.Commons;
using UIElements.Interfaces;

namespace UIElements.Web
{
    public class BaseWebElement : IElement
    {
        private readonly IGenericWebDriver _driver;

        public BaseWebElement(string name, Locator locator, IGenericWebDriver driver)
        {
            Name = name;
            Locator = locator;
            _driver = driver;
        }

        public string Name { get; set; }

        public Locator Locator { get; set; }

        private IWebElement? _webElement;

        public IWebElement WebElement
        {
            get
            {
                if (_webElement == null)
                {
                    _webElement = _driver.Instance().FindElement(Locator.GetBy());
                }

                return _webElement;
            }
            set => _webElement = value;
        }
    }
}
