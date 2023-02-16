using System;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
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

    [When(@"inputs a new Project name")]
    public void InputsNewProjectName()
    {
        _scenarioContext.TryGetValue(ConfigModel.CurrentProject, out string projectName);

        string newProjectName = IdHelper.GetNewId();

        GenericWebDriver.Wait.Until(
            ExpectedConditions.TextToBePresentInElement(
                _homePage.ProjectTitleDiv.WebElement,
                projectName
            )
        );

        _homePage.ProjectEditInput.Clear();
        _homePage.ProjectEditInput.Type(newProjectName);

        _scenarioContext[ConfigModel.CurrentProject] = newProjectName;
    }

    [When(@"clicks on the Save icon")]
    public void ClickSaveIcon()
    {
        _homePage.ProjectEditSaveButton.Click();
    }

    [Then(@"the project should be displayed with the new name")]
    public void VerifyProjectCreation()
    {
        _scenarioContext.TryGetValue(ConfigModel.CurrentProject, out string newProjectName);

        GenericWebDriver.Wait.Until(
            ExpectedConditions.TextToBePresentInElement(
                _homePage.GetProjectTd(newProjectName).WebElement,
                newProjectName
            )
        );

        string actualText = _homePage.GetProjectTd(newProjectName).WebElement.Text;
        Assert.That(newProjectName, Is.EqualTo(actualText));
    }
}
