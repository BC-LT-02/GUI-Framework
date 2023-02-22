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
    private LoginPage? _loginPage;
    private readonly ProfilePage? _profilePage;
    private readonly ScenarioContext _scenarioContext;
    public UpdateEmailStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
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

    [When(@"introduces his new credentials")]
    public void WhenIntroducesHisCredentials()
    {
        _loginPage!.EmailTextField.Clear();
        _loginPage.EmailTextField.Type(_scenarioContext.Get<string>("Email"));
        _loginPage.PasswordTextField.Clear();
        _loginPage.PasswordTextField.Type(_loginPage.PassCredentials);
    }
}
