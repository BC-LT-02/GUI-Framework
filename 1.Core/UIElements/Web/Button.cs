using SeleniumTest.Core.Interfaces;
using UIElements.Commons;
using UIElements.Interfaces;

namespace UIElements.Web
{
    public class Button : BaseWebElement, IClickable
    {
        public Button(string name, Locator locator, IGenericWebDriver driver) : base(name, locator, driver) { }

        public void Click()
        {
            WebElement.Click();
        }
    }
}
