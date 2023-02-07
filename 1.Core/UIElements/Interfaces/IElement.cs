using OpenQA.Selenium;
using UIElements.Commons;
using UIElements.Enums;

namespace UIElements.Interfaces
{
    public interface IElement
    {
        IWebElement WebElement { get; set; }

        public string Name { get; set; }

        //public ElementType ElementType { get; set; }

        public Locator Locator { get; set; }
    }
}
