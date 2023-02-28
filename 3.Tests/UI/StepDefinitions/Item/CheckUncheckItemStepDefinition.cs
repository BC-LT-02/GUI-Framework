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
    [Scope(Feature = "Checking and Unchecking a Todo Item")]
    public class CheckUncheckItemStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private string _itemName = "";

        public CheckUncheckItemStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
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
                UIElementFactory
                    .GetElement("Checked Item See All", "Items Component")
                    .Click();

                _itemName = UIElementFactory
                    .GetElement("Checked Item", "Items Component", "DoneItem")
                    .WebElement.Text;
                UIElementFactory.GetElement("Checked Item Checkbox", "Items Component", _itemName).Click();
            }
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
    }
}
