using TechTalk.SpecFlow;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;
using Todoly.Core.Helpers;

namespace SeleniumTest.Tests;

[Binding]
[Scope(Feature = "Password update")]
public class UpdatePasswordStepDefinition : CommonSteps
{
    private readonly HomePage _homePage;
    private ProfilePage? _profilePage;
    private readonly ScenarioContext _scenarioContext;
    public UpdatePasswordStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _homePage = new HomePage();
        _scenarioContext = scenarioContext;
    }

    [Given(@"the user clicks on the Settings option on the Nav Bar")]
    public void GiventheuserclicksontheSettingsoptionontheNavBar()
    {
        _homePage.SettingsButton.Click();
        _profilePage = new ProfilePage();
    }

    [When(@"the user inputs his password on the Old Password input")]
    public void WhentheuserinputshispasswordontheOldPasswordinput()
    {
        _profilePage!.OldPassTextField.Type(ConfigModel.TODO_LY_PASS);
    }

    [When(@"inputs a new valid password ""(.*)"" on the New Password input")]
    public void WheninputsanewvalidpasswordontheNewPasswordinput(string password)
    {
        _profilePage!.NewPassTextField.Type(password);
        _scenarioContext.Add("Password", password);
    }

    [When(@"clicks on the OK button")]
    public void WhenclicksontheOKbutton()
    {
        _profilePage!.OkButton.Click();
    }

    [Then(@"the password is updated closing the settings view")]
    public void Thenthepasswordisupdatedclosingthesettingsview()
    {
        Assert.False(_profilePage!.NonDisplayedCloseButton.WebElement.Displayed);
    }
}
