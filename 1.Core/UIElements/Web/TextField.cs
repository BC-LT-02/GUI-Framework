using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.Interfaces;

namespace Todoly.Core.UIElements.Web
{
    public class TextField : BaseWebElement, ITypeable
    {
        public TextField(string name, Locator locator) : base(name, locator) { }

        public void Clear()
        {
            try
            {
                GenericWebDriver.Wait.Until(ExpectedConditions.ElementIsVisible(Locator.GetBy()));
                GenericWebDriver.Wait.Until(ExpectedConditions.ElementToBeClickable(WebElement));
                WebElement.Clear();
                GenericWebDriver.Wait.Until(ExpectedConditions.TextToBePresentInElementValue(WebElement, ""));
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
            catch (WebDriverTimeoutException error)
            {
                System.Console.WriteLine($"Text not cleared.");
                throw error;
            }
        }
        public void Type(string keys)
        {
            try
            {
                WebElement.SendKeys(keys);
                GenericWebDriver.Wait.Until(ExpectedConditions.TextToBePresentInElementValue(WebElement, keys));
            }
            catch (WebDriverTimeoutException error)
            {
                System.Console.WriteLine($"Keys not sent.");
                throw error;
            }
        }
    }
}
