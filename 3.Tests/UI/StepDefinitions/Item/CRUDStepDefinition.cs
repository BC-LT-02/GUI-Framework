using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.WebActions;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace CreateItemTest;

[Binding]
[Scope(Feature = "Items CRUD operations")]
public class CreateStepDefinitions : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;
    private string _expectedItemName = "";

    public CreateStepDefinitions(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"enters the item ""(.*)"" on Add New Todo input")]
    public void Whentheuserclicks(string itemName)
    {
        _expectedItemName = itemName;
        UIElementFactory.GetElement("Add New Todo", "Items Component").Type(itemName);
        UIElementFactory.GetElement("Add New Todo", "Items Component").Type(Keys.Enter);
    }

    [When(@"inputs ""(.*)"" as new item name")]
    public void InputsNewItemName(string newName)
    {
        GenericWebDriver.Wait.Until(
            ExpectedConditions.ElementIsVisible(
                UIElementFactory.GetElement("Edit Item", "Items Component").Locator.GetBy()
            )
        );
        UIElementFactory.GetElement("Edit Item", "Items Component").Clear();
        UIElementFactory.GetElement("Edit Item", "Items Component").Type(newName);
        UIElementFactory.GetElement("Current Project", "Items Component").Click();
    }

    [Then(@"the ""(.*)"" should be displayed")]
    public void VerifyItemUpdate(string itemName)
    {
        string actualText = UIElementFactory
            .GetElement("Get Item", "Items Component", itemName)
            .WebElement.Text;
        Assert.That(itemName, Is.EqualTo(actualText));
    }

    [Then(@"the item should be removed from the section")]
    public void ShouldbeRemoved()
    {
        Assert.That(
            UIElementFactory.GetElement("No Items", "Items Component").WebElement.Text,
            Is.EqualTo("There are no items to display")
        );
    }
}
