using TechTalk.SpecFlow;
using Todoly.Tests.UI.Steps.Commons;

namespace SeleniumTest.Tests.Steps.Project;

[Binding]
[Scope(Feature = "Project Creation")]
public class CreateStepDefinitions : CommonSteps
{
    public CreateStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }
}
