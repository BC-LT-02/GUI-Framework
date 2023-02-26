using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.WebActions;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace Todoly.Tests.UI.Steps.RecycleBin;

[Binding]
[Scope(Feature = "Empty recycle bin")]
public class DeleteAllStepDefinitions : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;

    public DeleteAllStepDefinitions(ScenarioContext scenarioContext)
        : base(scenarioContext)
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
