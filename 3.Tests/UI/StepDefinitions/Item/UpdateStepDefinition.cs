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
[Scope(Feature = "Item Update")]
public class UpdateStepDefinitions : CommonSteps
{
    private readonly HomePage _homePage;
    private readonly ScenarioContext _scenarioContext;
    private string _expectedItemName = "";

    public UpdateStepDefinitions(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
        _homePage = new HomePage();
        _scenarioContext = scenarioContext;
    }

    [When(@"the user has selected a project")]
    public void SelectProject()
    {
        _scenarioContext.TryGetValue(ConfigModel.CurrentProject, out string projectName);
        _homePage.ProjectTd(projectName).Click();
    }

    [When(@"the user clicks on the item")]
    public void ClickItem()
    {
        _scenarioContext.TryGetValue(ConfigModel.CurrentItem, out string itemName);
        _homePage.ItemButton(itemName).Click();
    }

    [When(@"inputs a new item name and press enter")]
    public void InputsNewItemName()
    {
        string itemName = IdHelper.GetNewId();
        _expectedItemName = itemName;

        _homePage.ItemTextField.Clear();
        _homePage.ItemTextField.Type(itemName);
        _homePage.ItemTextField.Type(Keys.Enter);
    }

    [Then(@"the item should be displayed with the new name")]
    public void VerifyItemUpdate()
    {
        string actualText = _homePage.GetItemTd(_expectedItemName).WebElement.Text;
        Assert.That(_expectedItemName, Is.EqualTo(actualText));
    }
}
