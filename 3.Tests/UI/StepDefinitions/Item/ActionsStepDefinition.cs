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
[Scope(Feature = "Items actions operations")]
public class PriorityStepDefinitions : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;

    public PriorityStepDefinitions(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"the user checks ""(.*)""")]
    public void WhenIchecktheitem(string itemName)
    {
        UIElementFactory.GetElement("Item Checkbox", "Items Component", itemName).Click();
    }

    [Then(@"the <([\w ]+)> color should be (.*)")]
    public void PriorityShouldBeSet(string itemName, string itemColor)
    {
        Assert.That(
            UIElementFactory.GetElement("Item Color", "Items Component", itemColor).WebElement.Text,
            Is.EqualTo(itemName)
        );
    }

    [Then(@"""(.*)"" should be listed in the Done Items")]
    public void Thentheitemshouldbelistedinthe(string itemName)
    {
        var expectedItem = UIElementFactory
            .GetElement("Checked Item", "Items Component", itemName)
            .WebElement.Text;
        Assert.That(expectedItem, Is.EqualTo(itemName));
    }

    [Then(@"the ""(.*)"" should be added (below|above) the ""(.*)""")]
    public void Thentheshouldbeaddedbelowthe(
        string expectedNewItem,
        string position,
        string expectedItem
    )
    {
        string item;
        string new_item;
        GenericWebDriver.Wait.Until(
            ExpectedConditions.TextToBePresentInElement(
                UIElementFactory.GetElement("Get Item", "Items Component", expectedNewItem).WebElement,
                expectedNewItem
            )
        );

        if (position == "above")
        {
            item = UIElementFactory
                .GetElement("Item Index", "Items Component", "2")
                .WebElement.Text;
            new_item = UIElementFactory
                .GetElement("Item Index", "Items Component", "1")
                .WebElement.Text;
        }
        else
        {
            item = UIElementFactory
                .GetElement("Item Index", "Items Component", "1")
                .WebElement.Text;
            new_item = UIElementFactory
                .GetElement("Item Index", "Items Component", "2")
                .WebElement.Text;
        }

        Assert.That(expectedItem, Is.EqualTo(item));
        Assert.That(expectedNewItem, Is.EqualTo(new_item));
    }
}
