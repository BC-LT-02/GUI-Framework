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
        private readonly HomePage _homePage;
        private readonly ScenarioContext _scenarioContext;
        private string _itemName = "";
        private string _itemAbove = "";

        public AddAboveItemStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _homePage = new HomePage();
        }

        [Given(@"the user has selected the ""(.*)"" project")]
        public void Giventheuserhasselectedtheproject(string project)
        {
            _scenarioContext.TryGetValue(project, out string projectName);
            _homePage.ProjectTd(projectName).Click();
        }

        [When(@"the user selects Add above on the ""(.*)""")]
        public void Whentheuserselectsonthe(string item)
        {
            _itemName = item;
            WebActions.HoverElement(_homePage.GetItemTd(item).WebElement);
            _homePage.GetItemContextButton(_itemName).Click();
            _homePage.ItemMenuAddItemAboveButton.Click();
        }

        [Then(@"the user enters ""(.*)"" and saves it")]
        public void Whentheuserentersandsavesit(string newItem)
        {
            _itemAbove = newItem;
            _homePage.AddAboveOrBelowTextField.Type(newItem);
            _homePage.AddAboveOrBelowTextField.Type(Keys.Enter);
        }

        [Then(@"the ""(.*)"" should be added above the ""(.*)""")]
        public void Thentheshouldbeaddedabovethe(string expectedItemAbove, string expectedItem)
        {
            GenericWebDriver.Wait.Until(
            ExpectedConditions.TextToBePresentInElement(
                _homePage.GetItemByIndex(1).WebElement, _itemAbove
                )
            );
            string itemAbove = _homePage.GetItemByIndex(1).WebElement.Text;
            string item = _homePage.GetItemByIndex(2).WebElement.Text;
            Assert.That(expectedItem, Is.EqualTo(item));
            Assert.That(expectedItemAbove, Is.EqualTo(itemAbove));
        }
    }
}
