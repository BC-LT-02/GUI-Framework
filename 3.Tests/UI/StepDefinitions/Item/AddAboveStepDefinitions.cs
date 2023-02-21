using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
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

        [When(@"the user selects on the ""(.*)""")]
        public void Whentheuserselectsonthe(string item)
        {
            _itemName = item;
            WebActions.HoverElement(_homePage.GetProjectTd(item).WebElement);
        }

        [Given(@"selects ""(.*)""")]
        public void Givenselects(string AddAbove)
        {
            _homePage.GetProjectContextButton(_itemName).Click();
            
        }

        [Then(@"an input text box should be displayed above the ""(.*)""")]
        public void Thenaninputtextboxshouldbedisplayedabovethe(string args1)
        {
            _scenarioContext.Pending();
        }

        [When(@"the user enters ""(.*)"" and saves it")]
        public void Whentheuserentersandsavesit(string args1)
        {
            _scenarioContext.Pending();
        }

        [Then(@"the ""(.*)"" should be added above the ""(.*)""")]
        public void Thentheshouldbeaddedabovethe(string args1, string args2)
        {
            _scenarioContext.Pending();
        }
    }
}
