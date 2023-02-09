using System;
using TechTalk.SpecFlow;
using Todoly.Tests.UI.Steps.Commons;

namespace SeleniumTest.Tests.Steps.Project;

[Binding]
[Scope(Feature = "Project Creation")]
public class PostStepDefinitions : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;

    public PostStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"the user clicks the New Project button")]
    public void WhenTheUserClicksTheNewProjectButton()
    {
        Assert.IsTrue(true);
    }

    [When(@"inputs a new project name")]
    public void WhenInputsANewProjectName()
    {
        _scenarioContext.Pending();
    }

    [When(@"clicks the Add button")]
    public void WhenClicksTheAddButton()
    {
        _scenarioContext.Pending();
    }

    [Then(@"a new project with the chosen name should be displayed in the projects list")]
    public void ThenANewProjectWithTheChosenNameShouldBeDisplayedInTheProjectsList()
    {
        Assert.IsTrue(true);

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
