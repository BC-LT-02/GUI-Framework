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
    private string _itemName = "";

    public PriorityStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"the user (checks|unchecks) the item")]
    public void WhenIchecktheitem(string action)
    {
        if (action == "checks")
        {
            _itemName = UIElementFactory
                .GetElement("Item Index", "Items Component", "1")
                .WebElement.Text;
            UIElementFactory.GetElement("Item Checkbox", "Items Component", _itemName!).Click();
        }
        else
        {
            UIElementFactory.GetElement("Checked Item See All", "Items Component").Click();

            _itemName = UIElementFactory
                .GetElement("Checked Item", "Items Component", "DoneItem")
                .WebElement.Text;
            UIElementFactory
                .GetElement("Checked Item Checkbox", "Items Component", _itemName)
                .Click();
        }
    }

    [Then(@"the user enters ""(.*)"" and saves it")]
    public void Thentheuserentersandsavesit(string newItem)
    {
        UIElementFactory.GetElement("Edit Item", "Items Component").Type(newItem);
        UIElementFactory.GetElement("Edit Item", "Items Component").Type(newItem);
    }

    [Then(@"the <([\w ]+)> color should be (.*)")]
    public void PriorityShouldBeSet(string itemName, string itemColor)
    {
        Assert.That(
            UIElementFactory.GetElement("Item Color", "Items Component", itemColor).WebElement.Text,
            Is.EqualTo(itemName)
        );
    }

    [Then(@"the item should be listed in the (Done|Undone) Items")]
    public void Thentheitemshouldbelistedinthe(string status)
    {
        string expectedItem;
        if (status == "Done")
        {
            expectedItem = UIElementFactory
                .GetElement("Checked Item", "Items Component", _itemName!)
                .WebElement.Text;
        }
        else
        {
            expectedItem = UIElementFactory
                .GetElement("Item Index", "Items Component", "2")
                .WebElement.Text;
        }

        Assert.That(expectedItem, Is.EqualTo(_itemName!));
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
                UIElementFactory
                    .GetElement("Get Item", "Items Component", expectedNewItem)
                    .WebElement,
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
