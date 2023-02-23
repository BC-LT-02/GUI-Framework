using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.WebActions;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.Models;
using Todoly.Views.WebAppPages;

namespace CheckItemTest
{
    [Binding]
    [Scope(Feature = "Checking a Todo Item")]
    public class CheckItemStepDefinitions : CommonSteps
    {
        private readonly HomePage _homePage;
        private readonly ScenarioContext _scenarioContext;
        private string _itemName = "";

        public CheckItemStepDefinitions(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _homePage = new HomePage();
        }

        [When(@"the user checks the item")]
        public void WhenIchecktheitem()
        {
            _itemName = _scenarioContext.Get<string>(ConfigModel.CurrentItem);
            _homePage.ItemCheckBox(_itemName!).Click();
        }

        [Then(@"the item should be listed in the Done Items")]
        public void Thentheitemshouldbelistedinthe()
        {
            var expectedItem = _homePage.CheckedItem(_itemName!).WebElement.Text;
            Assert.That(expectedItem, Is.EqualTo(_itemName!));
        }
    }
}
