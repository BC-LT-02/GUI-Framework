using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.WebActions;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace SeleniumTest.Tests.Steps.Items;

[Binding]
[Scope(Feature = "Settings actions operations")]
public class SettingsStepDefinitions : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly LoginPage _loginPage = new LoginPage();

    public SettingsStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"(?:the user )?accepts the alert")]
    public void AcceptAlert()
    {
        GenericWebDriver.AcceptAlert();
    }

    [When(@"introduces his credentials")]
    public void IntroduceCredentials()
    {
        _loginPage!.EmailTextField.Clear();
        try
        {
            _loginPage.EmailTextField.Type(_scenarioContext.Get<string>("Email"));
        }
        catch
        {
            _loginPage.EmailTextField.Type(_loginPage.EmailCredentials);
        }

        _loginPage.PasswordTextField.Clear();
        _loginPage.PasswordTextField.Type(_loginPage.PassCredentials);
    }

    [When(@"the '(.*)' is selected at '(.*)'")]
    public void VerifyElementIsSelected(string elementName, string viewName)
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        Assert.That(
            UIElementFactory
                .GetElement(elementName, CurrentView)
                .WebElement.GetAttribute("selected"),
            Is.EqualTo("true")
        );
    }

    [Then(@"an alert should appear with the message ""(.*)""")]
    public void VerifyAlertMessage(string message)
    {
        var alert = GenericWebDriver.Wait.Until(ExpectedConditions.AlertIsPresent());
        Assert.That(message, Is.EqualTo(alert.Text));
    }

    [Then(@"the '(.*)' value is updated with '(.*)' at '(.*)'")]
    public void VerifyElementValueUpdate(string elementName, string newValue, string viewName)
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        Assert.That(
            UIElementFactory.GetElement(elementName, CurrentView).WebElement.GetAttribute("value"),
            Is.EqualTo(newValue)
        );
    }
}
