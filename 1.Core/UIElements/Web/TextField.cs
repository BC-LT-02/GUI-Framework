using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Interfaces;

namespace Todoly.Core.UIElements.Web
{
    public class TextField : BaseWebElement, ITypeable
    {
        public TextField(string name, Locator locator) : base(name, locator) { }

        public void Type(string keys)
        {
            WebElement.SendKeys(keys);
        }
    }
}
