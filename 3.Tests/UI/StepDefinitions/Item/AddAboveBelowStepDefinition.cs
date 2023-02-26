using System.Threading;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.WebActions;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace MyNamespace
{
    [Binding]
    [Scope(Feature = "Add Above Below Item")]
    public class AddBelowStepDefinitions : CommonSteps
    {
        private readonly HomePage _homePage;
        private readonly ScenarioContext _scenarioContext;
        private string _newItem = "";

        public AddBelowStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _homePage = new HomePage();
        }

        [Then(@"the user enters ""(.*)"" and saves it")]
        public void Thentheuserentersandsavesit(string newItem)
        {
            _newItem = newItem;
            UIElementFactory.GetElement("Edit Item", "Items Component").Type(newItem);
            UIElementFactory.GetElement("Edit Item", "Items Component").Type(Keys.Enter);
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
                    UIElementFactory.GetElement("Get Item", "Items Component", _newItem).WebElement,
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
}
