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

    [When(@"the user has selected the ""(.*)"" project")]
    public void SelectProject(string project)
    {
        _scenarioContext.TryGetValue(project, out string projectName);
        _homePage.ProjectTd(projectName).Click();
    }

    [When(@"the user clicks on the item")]
    public void ClickItem()
    {
        _scenarioContext.TryGetValue(ConfigModel.CurrentItem, out string itemName);
        GenericWebDriver.Wait.Until(
            ExpectedConditions.TextToBePresentInElement(
                _homePage.GetItemTd(itemName).WebElement,
                itemName
            )
        );
        _homePage.ItemButton(itemName).Click();
    }

    [When(@"inputs a new item name and press enter")]
    public void InputsNewItemName()
    {
        System.Console.WriteLine("Here");
        string itemName = IdHelper.GetNewId();
        System.Console.WriteLine("Here1");
        _expectedItemName = itemName;
        System.Console.WriteLine("Here2");
        GenericWebDriver.Wait.Until(
            ExpectedConditions.ElementIsVisible(_homePage.ItemTextField.Locator.GetBy())
        );
        System.Console.WriteLine("Here3");

        _homePage.ItemTextField.Clear();
        System.Console.WriteLine("Here4");
        _homePage.ItemTextField.Type(itemName);
        System.Console.WriteLine("Here5");
        _homePage.ItemTextField.Type(Keys.Enter);
        System.Console.WriteLine("Here6");
    }

    [Then(@"the item should be displayed with the new name")]
    public void VerifyItemUpdate()
    {
        string actualText = _homePage.GetItemTd(_expectedItemName).WebElement.Text;
        Assert.That(_expectedItemName, Is.EqualTo(actualText));
    }
}
