using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace SeleniumTest.Tests;

[Binding]
[Scope(Feature = "Password update")]
public class UpdatePasswordStepDefinition : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;
    public UpdatePasswordStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
}
