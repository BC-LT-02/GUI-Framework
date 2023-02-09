using SeleniumTest.Core;
using SeleniumTest.Core.Drivers;
using TechTalk.SpecFlow;
using UIElements.Interfaces;
using UIElements.Web;
using Views.WebAppPages;

namespace SeleniumTest.Tests;

[Binding]
[Scope(Feature = "User Login")]
[TestFixture]
public class LoginChromeTests
{
    private readonly LoginPage _loginPage;
    private HomePage? _homePage;
    private readonly ScenarioContext _scenarioContext;

    public LoginChromeTests(ScenarioContext scenarioContext)
    {
        _loginPage = new LoginPage();
        _scenarioContext = scenarioContext;
    }

    [Given(@"the user navigates to the URL")]
    public void GivenTheUserNavigatesToTheURL()
    {
        GenericWebDriver.Instance.Navigate().GoToUrl(ConfigModel.HostUrl);
    }

    [When(@"the user clicks on Login")]
    public void WhenTheUserClicksOnLogin()
    {
        _loginPage.LoginButton.Click();
    }

    [When(@"introduces his credentials")]
    public void WhenIntroducesHisCredentials()
    {
        _loginPage.EmailTextField.Clear();
        _loginPage.EmailTextField.Type(_loginPage.EmailCredentials);
        _loginPage.PasswordTextField.Clear();
        _loginPage.PasswordTextField.Type(_loginPage.PassCredentials);
    }

    [When(@"clicks on Login button")]
    public void WhenClicksOnLoginButton()
    {
        _loginPage.ConfirmLoginButton.Click();
    }

    [Then(@"the user should be able to see the main page")]
    public void ThenTheUserShouldBeAbleToSeeTheMainPage()
    {
        _homePage = new HomePage();
        IClickable element = _homePage.LogoutButton;
        Button logoutButton = (Button)element;
        Assert.True(logoutButton.WebElement.Displayed);
        Assert.That(GenericWebDriver.Instance.Title, Is.EqualTo("Todo.ly"));
    }

    [AfterScenario]
    public void TearDown()
    {
        GenericWebDriver.Dispose();
    }
}

