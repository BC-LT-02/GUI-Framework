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
    private string _expectedItemName = "";
    private string _expectedItemDueDate = "";

    public DueDateStepDefinitions(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"the user clicks on the Set Due Date option")]
    public void ClickDueDateItem()
    {
        _scenarioContext.TryGetValue(ConfigModel.CurrentItem, out string itemName);
        _expectedItemName = itemName;

        WebActions.HoverElement(
            UIElementFactory.GetElement("Get Item", "Items Component", itemName).WebElement
        );
        UIElementFactory.GetElement("Item DueDate", "Items Component", itemName).Click();
    }

    [When(@"inputs ""(.*)"" as due date")]
    public void InputsNewDueDate(string dueDate)
    {
        _expectedItemDueDate = dueDate;
        GenericWebDriver.Wait.Until(
            ExpectedConditions.ElementIsVisible(
                UIElementFactory.GetElement("DueDate TextField", "Items Component").Locator.GetBy()
            )
        );

        UIElementFactory.GetElement("DueDate TextField", "Items Component").Clear();
        UIElementFactory.GetElement("DueDate TextField", "Items Component").Type(dueDate);
        UIElementFactory.GetElement("DueDate TextField", "Items Component").Type(Keys.Enter);
    }

    [When(@"clicks on Postpone (.*)")]
    public void PostponeDueDate(string postponeTime)
    {
        WebActions.HoverElement(
            UIElementFactory.GetElement("Get Item", "Items Component", _expectedItemName).WebElement
        );
        UIElementFactory.GetElement("Item DueDate", "Items Component", _expectedItemName).Click();
        UIElementFactory.GetElement("Postpone Select", "Items Component").Click();
        UIElementFactory.GetElement("Postpone X Time", "Items Component", postponeTime).Click();
        UIElementFactory.GetElement("Postpone Button", "Items Component").Click();
    }

    [Then(@"the item should be displayed as overdue")]
    public void DueDateOverdue()
    {
        GenericWebDriver.Wait.Until(
            ExpectedConditions.TextToBePresentInElement(
                UIElementFactory
                    .GetElement("Item DueDate Td", "Items Component", _expectedItemName)
                    .WebElement,
                "days overdue"
            )
        );
        string actualText = UIElementFactory
            .GetElement("Item DueDate", "Items Component", _expectedItemName)
            .WebElement.Text;
        Assert.That(actualText, Does.Contain("days overdue"));
    }

    [Then(@"the item should be displayed with the ""(.*)"" date-tag")]
    public void VerifyDueDate(string dateTag)
    {
        GenericWebDriver.Wait.Until(
            ExpectedConditions.TextToBePresentInElement(
                UIElementFactory
                    .GetElement("Item DueDate Td", "Items Component", _expectedItemName)
                    .WebElement,
                dateTag
            )
        );
        string actualText = UIElementFactory
            .GetElement("Item DueDate", "Items Component", _expectedItemName)
            .WebElement.Text;
        Assert.That(dateTag, Is.EqualTo(actualText));
    }
}
