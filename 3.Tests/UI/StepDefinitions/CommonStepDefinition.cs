using System;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.WebActions;
using Todoly.Views.WebAppPages;

namespace Todoly.Tests.UI.Steps.Commons;

[Binding]
public class CommonSteps
{
    private readonly ScenarioContext _scenarioContext;
    private string? _currentView;
    public string CurrentView
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_currentView))
            {
                throw new Exception("No view name was specified");
            }

            return _currentView!;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _currentView = value;
            }
        }
    }

    public CommonSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the user is logged in")]
    public void Login()
    {
        LoginPage loginPage = new LoginPage();
        loginPage!.LoginIntoApplication();
    }

    [When(@"(?:the user )?clicks on '([a-zA-Z ]+)'(?: on '([a-zA-Z ]+)')?$")]
    public void Click(string elementName, string viewName)
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        UIElementFactory.GetElement(elementName, CurrentView).Click();
    }

    [When(@"(?:the user )?types ""(.*)"" on '([a-zA-Z ]+)'(?: on '([a-zA-Z ]+)')?$")]
    public void Type(string input, string elementName, string viewName)
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        if (input == "Password Credential")
        {
            UIElementFactory.GetElement(elementName, CurrentView).Type(ConfigModel.TODO_LY_PASS);
        }
        else
        {
            if (elementName == "New Password")
            {
                _scenarioContext.Add("Password", input);
            }
            else if (elementName == "Email")
            {
                _scenarioContext.Add("Email", input);
            }

            UIElementFactory.GetElement(elementName, CurrentView).Type(input);
        }
    }

    [Then(@"the '(.*)' should (not )?be displayed(?: on '([a-zA-Z ]+)')?$")]
    public void ValidateDisplay(string elementName, string display, string viewName)
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        if (display == "not ")
        {
            Assert.False(
                UIElementFactory.GetElement(elementName, CurrentView).WebElement.Displayed
            );
        }
        else
        {
            Assert.True(UIElementFactory.GetElement(elementName, CurrentView).WebElement.Displayed);
        }
    }

<<<<<<< HEAD
    [Then(@"the '(.*)' <(.*)> should (not )?be displayed(?: on '([a-zA-Z ]+)')?$")]
    public void ValidateDisplay(string elementName, string locatorArgument, string display, string viewName)
=======
    [When(@"(?:the user )?hovers on '([a-zA-Z ]+)'(?: on '([a-zA-Z ]+)')?$")]
    public void Hover(string elementName, string viewName)
>>>>>>> e1720dc (Refactored test cases)
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

<<<<<<< HEAD
        if (display == "not ")
        {
            Assert.False(UIElementFactory.GetElement(elementName, CurrentView, locatorArgument).WebElement.Displayed);
        }
        else
        {
            Assert.True(UIElementFactory.GetElement(elementName, CurrentView, locatorArgument).WebElement.Displayed);
        }
=======
        WebActions.HoverElement(UIElementFactory.GetElement(elementName, CurrentView).WebElement);
    }

    [Then(@"the main title text is ""(.*)""")]
    public void Thenthemaintitletextis(string expectedTitle)
    {
        GenericWebDriver.Wait.Until(
            ExpectedConditions.TextToBePresentInElement(
                UIElementFactory.GetElement("Current Project Title", CurrentView).WebElement,
                expectedTitle
            )
        );
>>>>>>> e1720dc (Refactored test cases)
    }
}
