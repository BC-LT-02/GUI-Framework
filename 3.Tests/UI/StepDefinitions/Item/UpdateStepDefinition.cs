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
        string randomItemName = IdHelper.GetNewId();
        _expectedItemName = randomItemName;
        GenericWebDriver.Wait.Until(
            ExpectedConditions.ElementIsVisible(_homePage.ItemTextField.Locator.GetBy())
        );

        _homePage.ItemTextField.Clear();
        _homePage.ItemTextField.Type(_expectedItemName);
        _homePage.CurrentProjectButton.Click();
    }

    [Then(@"the item should be displayed with the new name")]
    public void VerifyItemUpdate()
    {
        string actualText = _homePage.GetItemTd(_expectedItemName).WebElement.Text;
        Assert.That(_expectedItemName, Is.EqualTo(actualText));
    }
}
