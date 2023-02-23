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
[Scope(Feature = "Item Priority")]
public class PriorityStepDefinitions : CommonSteps
{
    private readonly HomePage _homePage;
    private readonly ScenarioContext _scenarioContext;

    public PriorityStepDefinitions(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
        _homePage = new HomePage();
        _scenarioContext = scenarioContext;
    }

    [Then(@"the <([\w ]+)> color should be (.*)")]
    public void PriorityShouldBeSet(string itemName, string itemColor)
    {
        Assert.That(_homePage.GetItemColor(itemName, itemColor).WebElement.Displayed);
        // Assert.That(UIElementFactory.GetElement("Item Color", "Items Component", itemName, itemColor).WebElement.Displayed);
    }
}
