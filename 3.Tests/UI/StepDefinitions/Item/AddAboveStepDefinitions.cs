using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.WebActions;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace MyNamespace
{
    [Binding]
    [Scope(Feature = "Add Above Item")]
    public class AddAboveItemStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private string _itemAbove = "";

        public AddAboveItemStepDefinitions(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"the user enters ""(.*)"" and saves it")]
        public void Whentheuserentersandsavesit(string newItem)
        {
            _itemAbove = newItem;
            UIElementFactory.GetElement("Edit Item", "Items Component").Type(newItem);
            UIElementFactory.GetElement("Edit Item", "Items Component").Type(Keys.Enter);
        }

        [Then(@"the ""(.*)"" should be added above the ""(.*)""")]
        public void Thentheshouldbeaddedabovethe(string expectedItemAbove, string expectedItem)
        {
            GenericWebDriver.Wait.Until(
                ExpectedConditions.TextToBePresentInElement(
                    UIElementFactory
                        .GetElement("Get Item", "Items Component", expectedItemAbove)
                        .WebElement,
                    _itemAbove
                )
            );
            string itemAbove = UIElementFactory
                .GetElement("Item Index", "Items Component", "1")
                .WebElement.Text;
            string item = UIElementFactory
                .GetElement("Item Index", "Items Component", "2")
                .WebElement.Text;
            Assert.That(expectedItem, Is.EqualTo(item));
            Assert.That(expectedItemAbove, Is.EqualTo(itemAbove));
        }
    }
}
