using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace SeleniumTest.Tests;

[Binding]
[Scope(Feature = "Profile settings view")]
public class ViewProfileStepDefinition : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;
    public ViewProfileStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
}
