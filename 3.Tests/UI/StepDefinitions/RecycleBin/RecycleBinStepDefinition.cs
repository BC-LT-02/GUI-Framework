using TechTalk.SpecFlow;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace Todoly.Tests.UI.Steps.RecycleBin;

[Binding]
[Scope(Feature = "Recycle Bin")]
public class RecycleBinStepDefinitions : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;

    public RecycleBinStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Then(@"the recycle bin should should be empty")]
    public void Giventherecyclebinshouldshouldbeempty()
    {
        Assert.True(
            UIElementFactory.GetElement("No Items", "Home Page").WebElement.Displayed,
            "The recycle bin is not empty"
        );
    }
}
