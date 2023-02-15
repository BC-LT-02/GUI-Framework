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
    private readonly HomePage _homePage;
    private readonly ScenarioContext _scenarioContext;
    private string _expectedItemName = "";

    public DeleteStepDefinitions(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
        _homePage = new HomePage();
        _scenarioContext = scenarioContext;
    }

    [When(@"the user has selected a project")]
    public void Giventheuserhasselectedaproject()
    {
        _scenarioContext.TryGetValue(ConfigModel.CurrentProject, out string projectName);
        WebActions.HoverElement(_homePage.GetProjectTd(projectName).WebElement);
        _homePage.GetProjectContextButton(projectName).Click();
    }

    [When(@"the user clicks on the delete option of an item")]
    public void Whentheuserclicksonthedeleteoptionofanitem()
    {
        _scenarioContext.TryGetValue(ConfigModel.CurrentItem, out string itemName);
        _expectedItemName = itemName;

        WebActions.HoverElement(_homePage.GetItemTd(itemName).WebElement);
        _homePage.GetItemContextButton(itemName).Click();
        _homePage.ItemDeleteButton.Click();
    }

    [Then(@"the item should be removed from the section")]
    public void Thentheitemshouldberemovedfromthesection()
    {
        string actualText = _homePage.GetItemTd(_expectedItemName).WebElement.Text;
        Assert.That(_expectedItemName, !Is.EqualTo(actualText));
    }
}
