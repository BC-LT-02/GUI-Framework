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
    [Scope(Feature = "Add Below Item")]
    public class AddBelowStepDefinitions : CommonSteps
    {
        private readonly HomePage _homePage;
        private readonly ScenarioContext _scenarioContext;
        private string _itemName = "";
        private string _itemBelow = "";

        public AddBelowStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
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

        [When(@"the user selects Add below on the ""(.*)""")]
        public void WhentheuserselectsAddbelowonthe(string item)
        {
            _itemName = item;
            WebActions.HoverElement(_homePage.GetItemTd(item).WebElement);
            _homePage.GetItemContextButton(_itemName).Click();
            _homePage.ItemMenuAddItemBelowButton.Click();
        }

        [Then(@"the user enters ""(.*)"" and saves it")]
        public void Thentheuserentersandsavesit(string newItem)
        {
            _itemBelow = newItem;
            _homePage.AddAboveOrBelowTextField.Type(newItem);
            _homePage.AddAboveOrBelowTextField.Type(Keys.Enter);
        }

        [Then(@"the ""(.*)"" should be added below the ""(.*)""")]
        public void Thentheshouldbeaddedbelowthe(string expectedItemBelow, string expectedItem)
        {
            GenericWebDriver.Wait.Until(
            ExpectedConditions.TextToBePresentInElement(
                _homePage.GetItemTd(_itemName).WebElement, expectedItem
                )
            );
            string item = _homePage.GetItemByIndex(1).WebElement.Text;
            string itemBelow = _homePage.GetItemByIndex(2).WebElement.Text;
            Assert.That(expectedItem, Is.EqualTo(item));
            Assert.That(expectedItemBelow, Is.EqualTo(itemBelow));

            //Lunch
            //brush teeth
            //sleep
        }
    }
}
