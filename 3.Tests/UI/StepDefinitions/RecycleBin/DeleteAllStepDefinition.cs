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

    private readonly HomePage _homePage;

    public DeleteAllStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _homePage = new HomePage();
    }

    [Then(@"the snack bar message is ""(.*)""")]
    public void Giventhesnackbarmessageis(string expectedMessage)
    {
        Assert.That(_homePage.InfoMessageText.WebElement.Text, Is.EqualTo(expectedMessage));
    }

    [Then(@"the recycle bin should should be empty")]
    public void Giventherecyclebinshouldshouldbeempty()
    {
        Assert.True(_homePage.NoItemsDiv.WebElement.Displayed, "The recycle bin is not empty");
    }
}
