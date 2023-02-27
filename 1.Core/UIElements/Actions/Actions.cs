using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Todoly.Core.UIElements.Drivers;

namespace Todoly.Core.UIElements.WebActions;

public class WebActions
{
    public static void HoverElement(IWebElement element)
    {
        Actions actions = new Actions(GenericWebDriver.Instance);
        actions.MoveToElement(element).Perform();
    }

    public static void DragAndDrop(IWebElement source, IWebElement target)
    {
        Actions actions = new Actions(GenericWebDriver.Instance);
        actions.DragAndDrop(source, target).Perform();
    }

    public static void NavigateTo(string url)
    {
        GenericWebDriver.Instance.Navigate().GoToUrl(url);
    }
}
