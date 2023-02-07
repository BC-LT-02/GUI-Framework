using SeleniumTest.Core.Interfaces;
using UIElements.Commons;
using UIElements.Interfaces;

namespace UIElements.Web
{
    public class TextField : BaseWebElement, ITypeable
    {
        public TextField(string name, Locator locator, IGenericWebDriver driver) : base(name, locator, driver) { }

        public void Type(string keys)
        {
            WebElement.SendKeys(keys);
        }

        public void Clear()
        {
            WebElement.Clear();
        }
    }
}
