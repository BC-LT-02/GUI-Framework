using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.Interfaces;

namespace Todoly.Core.UIElements.Web
{
    public class Button : BaseWebElement, IButton
    {
        public Button(string name, Locator locator) : base(name, locator) { }

        public void Click()
        {
            try
            {
                GenericWebDriver.Wait.Until(ExpectedConditions.ElementIsVisible(Locator.GetBy()));
                GenericWebDriver.Wait.Until(ExpectedConditions.ElementToBeClickable(WebElement));
                WebElement.Click();
            }
            catch (ElementNotVisibleException error)
            {
                System.Console.WriteLine($"Unable to visualize button: {Name}");
                throw error;
            }
            catch (ElementNotInteractableException error)
            {
                System.Console.WriteLine($"Unable to click button: {Name}");
                throw error;
            }
        }
    }
}
