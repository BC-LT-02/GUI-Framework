using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Serilog;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.Interfaces;

namespace Todoly.Core.UIElements.Web
{
    public class TextField : BaseWebElement, ITextField
    {
        public TextField(string name, Locator locator) : base(name, locator) { }

        public void Clear()
        {
            try
            {
                GenericWebDriver.Wait.Until(ExpectedConditions.ElementToBeClickable(WebElement));
                WebElement.Clear();
                GenericWebDriver.Wait.Until(
                    ExpectedConditions.TextToBePresentInElementValue(WebElement, "")
                );
            }
            catch (ElementNotVisibleException error)
            {
                foreach (ILogger logger in Logger.Instance)
                {
                    logger.Error($"Unable to visualize {Name} button with ${Locator.Value}");
                }

                throw error;
            }
            catch (ElementNotInteractableException error)
            {
                foreach (ILogger logger in Logger.Instance)
                {
                    logger.Error($"Unable to interact with {Name} button with ${Locator.Value}");
                }

                throw error;
            }
            catch (WebDriverTimeoutException error)
            {
                foreach (ILogger logger in Logger.Instance)
                {
                    logger.Error($"{Name} text field not cleared.");
                }

                throw error;
            }
        }

        public void Type(string keys)
        {
            try
            {
                if (keys == Keys.Enter)
                {
                    WebElement.SendKeys(Keys.Enter);
                }
                else
                {
                    Clear();
                    WebElement.SendKeys(keys);
                    GenericWebDriver.Wait.Until(
                        ExpectedConditions.TextToBePresentInElementValue(WebElement, keys)
                    );
                }
            }
            catch (WebDriverTimeoutException error)
            {
                foreach (ILogger logger in Logger.Instance)
                {
                    logger.Error($"Keys not sent to {Name} text field with ${Locator.Value}.");
                }

                throw error;
            }
        }
    }
}
