using System;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.WebActions;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace SeleniumTest.Tests.Steps.Items;

[Binding]
[Scope(Feature = "Item Due Date")]
public class DueDateStepDefinitions : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;

    public DueDateStepDefinitions(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"inputs ""(.*)"" as due date")]
    public void InputsNewDueDate(string dueDate)
    {
        string format = "d MMM";
        switch (dueDate)
        {
            case "Today":
                dueDate = DateTime.Now.ToString(format);
                break;
            case "Tomorrow":
                dueDate = DateTime.Now.AddDays(1).ToString(format);
                break;
            case "Yesterday":
                dueDate = DateTime.Now.AddDays(-1).ToString(format);
                break;
            default:
                break;
        }

        GenericWebDriver.Wait.Until(
            ExpectedConditions.ElementIsVisible(
                UIElementFactory.GetElement("DueDate TextField", "Items Component").Locator.GetBy()
            )
        );

        UIElementFactory.GetElement("DueDate TextField", "Items Component").Clear();
        UIElementFactory.GetElement("DueDate TextField", "Items Component").Type(dueDate);
        UIElementFactory.GetElement("DueDate TextField", "Items Component").Type(Keys.Enter);
    }

    [When(@"clicks on (.*) ""(.*)""")]
    public void PostponeDueDate(string postponeTime, string itemName)
    {
        WebActions.HoverElement(
            UIElementFactory.GetElement("Get Item", "Items Component", itemName).WebElement
        );
        UIElementFactory.GetElement("Item DueDate", "Items Component", itemName).Click();
        UIElementFactory.GetElement("Postpone Select", "Items Component").Click();
        UIElementFactory.GetElement("Postpone X Time", "Items Component", postponeTime).Click();
        UIElementFactory.GetElement("Postpone Button", "Items Component").Click();
    }

    [Then(@"the ""(.*)"" should be displayed in ""(.*)"" section")]
    public void DisplayedInSection(string itemName, string sectionName)
    {
        UIElementFactory.GetElement("Section Name", "Home Page", sectionName).Click();
        string actualText = UIElementFactory
            .GetElement("Get Item", "Items Component", itemName)
            .WebElement.Text;
        Assert.That(actualText, Does.Contain(itemName));
    }

    [Then(@"the ""(.*)"" date-tag should be displayed as ""(.*)""")]
    public void VerifyDateTag(string itemName, string dateTag)
    {
        GenericWebDriver.Wait.Until(
            ExpectedConditions.TextToBePresentInElement(
                UIElementFactory
                    .GetElement("Item DueDate Td", "Items Component", itemName)
                    .WebElement,
                dateTag
            )
        );
        string actualText = UIElementFactory
            .GetElement("Item DueDate", "Items Component", itemName)
            .WebElement.Text;
        Assert.That(actualText, Does.Contain(dateTag));
    }
}
