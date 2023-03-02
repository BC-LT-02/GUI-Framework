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

    public SettingsStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
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
