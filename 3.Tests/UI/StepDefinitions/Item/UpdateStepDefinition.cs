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
    private readonly ScenarioContext _scenarioContext;
    private string _expectedItemName = "";

    public UpdateStepDefinitions(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"the user clicks on the item")]
    public void ClickItem()
    {
        string itemName = UIElementFactory.GetElement("Item Index", "Items Component", "1")
                                          .WebElement.Text;
        GenericWebDriver.Wait.Until(
           ExpectedConditions.TextToBePresentInElement(
               UIElementFactory.GetElement("Get Item", "Items Component", itemName).WebElement,
               itemName
           )
        );
        UIElementFactory.GetElement("Get Item", "Items Component", itemName).Click();
    }

    [When(@"inputs a new item name and press enter")]
    public void InputsNewItemName()
    {
        string randomItemName = IdHelper.GetNewId();
        _expectedItemName = randomItemName;
        GenericWebDriver.Wait.Until(
            ExpectedConditions.ElementIsVisible(
                UIElementFactory.GetElement("Edit Item", "Items Component").Locator.GetBy()
            )
        );

        UIElementFactory.GetElement("Edit Item", "Items Component").Clear();
        UIElementFactory.GetElement("Edit Item", "Items Component").Type(_expectedItemName);
        UIElementFactory.GetElement("Current Project", "Items Component").Click();
    }

    [Then(@"the item should be displayed with the new name")]
    public void VerifyItemUpdate()
    {
        string actualText = UIElementFactory
            .GetElement("Get Item", "Items Component", _expectedItemName)
            .WebElement.Text;
        Assert.That(_expectedItemName, Is.EqualTo(actualText));
    }
}
