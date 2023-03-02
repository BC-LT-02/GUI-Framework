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

    public static void DragAndDrop(IWebElement source, IWebElement target, int offsetX, int offsetY)
    {
        Actions actions = new Actions(GenericWebDriver.Instance);
        actions.ClickAndHold(source).MoveToElement(target, offsetX, offsetY).Release().Perform();
    }

    public static void NavigateTo(string url)
    {
        GenericWebDriver.Instance.Navigate().GoToUrl(url);
    }
}
