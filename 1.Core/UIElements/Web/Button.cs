using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Interfaces;

namespace Todoly.Core.UIElements.Web
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
