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
    private readonly HomePage _homePage;
    private readonly ScenarioContext _scenarioContext;
    private string _expectedItemName = "";
    private string _expectedItemDueDate = "";

    public DueDateStepDefinitions(ScenarioContext scenarioContext)
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

    [When(@"the user clicks on the Set Due Date option")]
    public void ClickDueDateItem()
    {
        _scenarioContext.TryGetValue(ConfigModel.CurrentItem, out string itemName);
        _expectedItemName = itemName;

        WebActions.HoverElement(_homePage.GetItemTd(itemName).WebElement);
        _homePage.GetItemDueDateButton(itemName).Click();
    }

    [When(@"inputs ""(.*)"" as due date")]
    public void InputsNewItemName(string dueDate)
    {
        _expectedItemDueDate = dueDate;
        GenericWebDriver.Wait.Until(
            ExpectedConditions.ElementIsVisible(_homePage.ItemDueDateTextField.Locator.GetBy())
        );

        _homePage.ItemDueDateTextField.Clear();
        _homePage.ItemDueDateTextField.Type(dueDate);
        _homePage.ItemDueDateTextField.Type(Keys.Enter);
    }

    [Then(@"the item should be displayed with the same date-tag")]
    public void VerifyItemUpdate()
    {
        GenericWebDriver.Wait.Until(
            ExpectedConditions.TextToBePresentInElement(
                _homePage.GetItemDueDateTd(_expectedItemName).WebElement,
                _expectedItemDueDate
            )
        );
        string actualText = _homePage.GetItemDueDateButton(_expectedItemName).WebElement.Text;
        Assert.That(_expectedItemDueDate, Is.EqualTo(actualText));
    }
}
