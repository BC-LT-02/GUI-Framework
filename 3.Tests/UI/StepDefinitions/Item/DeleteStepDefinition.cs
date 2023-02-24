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
[Scope(Feature = "Item Deletion")]
public class DeleteStepDefinitions : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;

    public DeleteStepDefinitions(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Then(@"the item should be removed from the section")]
    public void ShouldbeRemoved()
    {
        GenericWebDriver.Wait.Until(
            ExpectedConditions.TextToBePresentInElement(
                UIElementFactory.GetElement("Item Deleted Alert", "Items Component").WebElement,
                "Item has been Deleted"
            )
        );
        Assert.That(
            UIElementFactory.GetElement("No Items", "Items Component").WebElement.Text,
            Is.EqualTo("There are no items to display")
        );
    }
}
