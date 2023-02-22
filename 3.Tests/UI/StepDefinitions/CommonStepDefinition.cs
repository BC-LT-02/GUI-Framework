using System;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Views.WebAppPages;

namespace Todoly.Tests.UI.Steps.Commons;

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
            Assert.False(UIElementFactory.GetElement(elementName, CurrentView).WebElement.Displayed);
        }
        else
        {
            Assert.True(UIElementFactory.GetElement(elementName, CurrentView).WebElement.Displayed);
        }
    }

    [Then(@"the '(.*)' <(.*)> should (not )?be displayed(?: on '([a-zA-Z ]+)')?$")]
    public void ValidateDisplay(string elementName, string locatorArgument, string display, string viewName)
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        if (display == "not ")
        {
            Assert.False(UIElementFactory.GetElement(elementName, CurrentView, locatorArgument).WebElement.Displayed);
        }
        else
        {
            Assert.True(UIElementFactory.GetElement(elementName, CurrentView, locatorArgument).WebElement.Displayed);
        }
    }
}
