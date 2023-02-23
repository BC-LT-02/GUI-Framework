using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.WebActions;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace SeleniumTest.Tests.Steps.Project;

[Binding]
[Scope(Feature = "Project Update")]
public class UpdateNameStepDefinitions : CommonSteps
{
    private readonly HomePage _homePage;
    private readonly ScenarioContext _scenarioContext;

    public UpdateNameStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _homePage = new HomePage();
        _scenarioContext = scenarioContext;
    }

    [When(@"the user clicks the edit button on ""(.*)""")]
    public void ClickEditButton(string projectName)
    {
        _scenarioContext[ConfigModel.CurrentProject] = projectName;
        WebActions.HoverElement(_homePage.GetProjectTd(projectName).WebElement);
        _homePage.GetProjectContextButton(projectName).Click();
        _homePage.ProjectEditButton.Click();
    }
}
