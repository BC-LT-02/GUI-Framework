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

    [When(@"the user clicks the recycle bin context menu and clicks the empty recycle bin button")]
    public void Whentheuserclickstherecyclebincontextmenuandclickstheemptyrecyclebinbutton()
    {
        WebActions.HoverElement(_homePage.RecycleBinDiv.WebElement);
        _homePage.RecycleBinContextButton.Click();
        _homePage.RecycleBinEmptyButton.Click();
    }

    [Then(@"the recycle bin should not contain any item")]
    public void Thentherecyclebinshouldnotcontainanyitem()
    {
        GenericWebDriver.Wait.Until(
            ExpectedConditions.TextToBePresentInElement(
                _homePage.ProjectTitleDiv.WebElement,
                "Recycle Bin"
            )
        );
        Assert.True(_homePage.NoItemsDiv.WebElement.Displayed, "The recycle bin is not empty");
    }
}
