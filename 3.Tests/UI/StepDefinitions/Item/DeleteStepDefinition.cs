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

    [When(@"the user has selected the ""(.*)"" project")]
    public void SelectProject(string project)
    {
        _scenarioContext.TryGetValue(project, out string projectName);
        _homePage.ProjectTd(projectName).Click();
    }

    [When(@"the user clicks on the delete option of an item")]
    public void ClickDelete()
    {
        string itemName = _homePage.GetItemByIndex(1).WebElement.Text;
        _expectedItemName = itemName;

        WebActions.HoverElement(_homePage.GetItemTd(itemName).WebElement);
        _homePage.GetItemContextButton(itemName).Click();
        _homePage.ItemDeleteButton.Click();
    }

    [Then(@"the item should be removed from the section")]
    public void ShouldbeRemoved()
    {
        GenericWebDriver.Wait.Until(
            ExpectedConditions.TextToBePresentInElement(
                _homePage.ItemDeletedAlert.WebElement,
                "Item has been Deleted"
            )
        );
        string deletedAlert = _homePage.ItemDeletedAlert.WebElement.Text;
        Assert.That(deletedAlert, Is.EqualTo("Item has been Deleted"));
        Assert.That(
            _homePage.NoItemsOnMain.WebElement.Text,
            Is.EqualTo("There are no items to display")
        );
    }
}
