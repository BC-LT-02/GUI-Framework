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
[Scope(Feature = "Project drag and drop actions")]
public class DragAndDropStepDefinitions : CommonSteps
{
    private readonly HomePage _homePage;
    private readonly ScenarioContext _scenarioContext;

    public DragAndDropStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _homePage = new HomePage();
        _scenarioContext = scenarioContext;
    }

    [When(@"the user drags and drop a project on top of another project of the list")]
    public void DragAndDropOnTop()
    {
        _scenarioContext.TryGetValue(ConfigModel.CurrentProject, out string projectName);
        var source = _homePage.GetProjectHandle(projectName);
        var target = _homePage.GetProjectHandle("Work");
        WebActions.DragAndDrop(source.WebElement, target.WebElement);
    }

    [Then(@"the project should be displayed as a child of the other project")]
    public void VerifyProjectUpdate()
    {
        _scenarioContext.Pending();
    }
}
