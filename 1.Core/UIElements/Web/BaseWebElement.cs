using OpenQA.Selenium;
using SeleniumTest.Core.Drivers;
using UIElements.Commons;
using UIElements.Interfaces;

namespace UIElements.Web
{
    public class BaseWebElement : IElement
    {
        public BaseWebElement(string name, Locator locator)
        {
            Name = name;
            Locator = locator;
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
                    _webElement = GenericWebDriver.Instance.FindElement(Locator.GetBy());
                }

                return _webElement;
            }
            set => _webElement = value;
        }
    }
}
