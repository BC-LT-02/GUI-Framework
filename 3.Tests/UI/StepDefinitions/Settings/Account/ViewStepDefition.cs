using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.WebActions;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace Todoly.Tests.UI.Steps.RecycleBin;

[Binding]
[Scope(Feature = "Settings account view")]
public class AccountViewStepDefinition : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;

    private readonly HomePage _homePage;

    public AccountViewStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _homePage = new HomePage();
    }

    [When(@"the user clicks on the Settings option and then account tab")]
    public void WhentheuserclicksontheSettingsoptionandthenaccounttab()
    {
        _homePage.SettingsButton.Click();
        _homePage.AccountTabButton.Click();
    }

    [Then(@"the user should be able to see the delete account button")]
    public void Giventheusershouldbeabletoseethedeleteaccountbutton()
    {
        Assert.True(
            _homePage.DeleteAccountButton.WebElement.Displayed,
            "The delete account button is not being displayed"
        );
    }
}
