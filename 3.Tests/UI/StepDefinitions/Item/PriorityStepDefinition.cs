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
    private string _expectedItemName = "";

    public PriorityStepDefinitions(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
        _homePage = new HomePage();
        _scenarioContext = scenarioContext;
    }

    [When(@"the user has selected the ""(.*)"" project")]
    public void SelectProject(string project)
    {
        _scenarioContext.TryGetValue(project, out string projectName);
        WebActions.HoverElement(_homePage.GetProjectTd(projectName).WebElement);
        _homePage.GetProjectContextButton(projectName).Click();
    }

    [When(@"the user clicks on the priority (.*) option of an item")]
    public void ClickPriority(string priorityValue)
    {
        _scenarioContext.TryGetValue(ConfigModel.CurrentItem, out string itemName);
        _expectedItemName = itemName;

        WebActions.HoverElement(_homePage.GetItemTd(itemName).WebElement);
        _homePage.GetItemContextButton(itemName).Click();
        _homePage.ItemPriorityButton(priorityValue).Click();
    }

    [Then(@"the item color should be (.*)")]
    public void PriorityShouldBeSet(string itemColor)
    {
        Assert.That(_homePage.GetItemColor(_expectedItemName, itemColor).WebElement.Displayed);
    }
}
