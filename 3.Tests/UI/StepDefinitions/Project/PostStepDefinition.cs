using System;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace SeleniumTest.Tests.Steps.Project;

[Binding]
[Scope(Feature = "Project Creation")]
public class PostStepDefinitions : CommonSteps
{
    private readonly HomePage _homePage;
    private readonly ScenarioContext _scenarioContext;

    public PostStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _homePage = new HomePage();
        _scenarioContext = scenarioContext;
    }

    [When(@"the user clicks the New Project button")]
    public void ClickNewProjectButton()
    {
        _homePage.AddNewProjectButton.Click();
    }

    [When(@"inputs a new project name")]
    public void InputsNewProjectName()
    {
        string projectName = IdHelper.GetNewId();

        _homePage.AddNewProjectInput.Clear();
        _homePage.AddNewProjectInput.Type(projectName);

        _scenarioContext[ConfigModel.CurrentProject] = projectName;
    }

    [When(@"clicks the Add button")]
    public void ClicksTheAddButton()
    {
        _homePage.AddNewProjectNameButton.Click();
    }

    [Then(@"a new project with the chosen name should be displayed in the projects list")]
    public void VerifyProjectCreation()
    {
        _scenarioContext.TryGetValue(ConfigModel.CurrentProject, out string projectName);
        
        GenericWebDriver.Wait.Until(
            ExpectedConditions.TextToBePresentInElement(
                _homePage.ProjectTitleDiv.WebElement,
                projectName
            )
        );

        string actualText = _homePage.GetProjectTd(projectName).WebElement.Text;
        Assert.That(projectName, Is.EqualTo(actualText));
    }
}
