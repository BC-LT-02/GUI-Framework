using OpenQA.Selenium;
using Todoly.Core.UIElements.Commons;

namespace Todoly.Core.UIElements.Interfaces
{
    public interface IElement
    {
        IWebElement WebElement { get; set; }
        public string Name { get; set; }
        public Locator Locator { get; set; }
    }
}
