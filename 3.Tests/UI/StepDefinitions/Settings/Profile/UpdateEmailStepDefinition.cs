using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using Todoly.Core.UIElements.Drivers;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace SeleniumTest.Tests;

[Binding]
[Scope(Feature = "Email update")]
public class UpdateEmailStepDefinition : CommonSteps
{
    private readonly HomePage _homePage;
    private LoginPage? _loginPage;
    private ProfilePage? _profilePage;
    private readonly ScenarioContext _scenarioContext;
    public UpdateEmailStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext)
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

    [When(@"the user inputs a new valid email ""(.*)"" on the Email input")]
    public void WhentheuserinputsanewvalidemailontheEmailinput(string email)
    {
        _profilePage!.EmailTextField.Type(email);
        _scenarioContext.Add("Email", email);
    }

    [When(@"clicks on the OK button")]
    public void WhenclicksontheOKbutton()
    {
        _profilePage!.OkButton.Click();
    }

    [Then(@"an alert should appear with the message ""(.*)""")]
    public void Thenanalertshouldappearwiththemessage(string message)
    {
        var alert = GenericWebDriver.Wait.Until(ExpectedConditions.AlertIsPresent());
        Assert.That(message, Is.EqualTo(alert.Text));
    }

    [When(@"the user clicks on the accept button being logged out")]
    public void Whentheuserclicksontheacceptbuttonbeingloggedout()
    {
        GenericWebDriver.Instance.SwitchTo().Alert().Accept();
        _loginPage = new LoginPage();
    }

    [When(@"clicks on Login")]
    public void WhenclicksonLogin()
    {
        _loginPage!.LoginButton.Click();
    }

    [When(@"introduces his new credentials")]
    public void WhenIntroducesHisCredentials()
    {
        _loginPage!.EmailTextField.Clear();
        _loginPage.EmailTextField.Type(_scenarioContext.Get<string>("Email"));
        _loginPage.PasswordTextField.Clear();
        _loginPage.PasswordTextField.Type(_loginPage.PassCredentials);
    }

    [When(@"clicks on Login button")]
    public void GivenclicksonLoginbutton()
    {
        _loginPage!.ConfirmLoginButton.Click();
    }

    [Then(@"the user should be logged in")]
    public void Thentheusershouldbeloggedin()
    {
        Assert.True(_homePage.LogoutButton.WebElement.Displayed);
        Assert.That(GenericWebDriver.Instance.Title, Is.EqualTo("Todo.ly"));
    }
}
