using UIElements.Commons;
using UIElements.Interfaces;

namespace UIElements.Web
{
    public class TextField : BaseWebElement, ITypeable
    {
        public TextField(string name, Locator locator)
            : base(name, locator) { }

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
