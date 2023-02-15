using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.Interfaces;
using Todoly.Core.UIElements.Web;
using Todoly.Views.WebAppPages;

namespace SeleniumTest.Tests;

[Binding]
[Scope(Feature = "User Login")]
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
}

