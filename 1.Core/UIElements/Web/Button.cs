using UIElements.Commons;
using UIElements.Interfaces;

namespace UIElements.Web
{
    public class Button : BaseWebElement, IClickable
    {
        public Button(string name, Locator locator) : base(name, locator) { }

        public void Click()
        {
            WebElement.Click();
        }
    }
}
