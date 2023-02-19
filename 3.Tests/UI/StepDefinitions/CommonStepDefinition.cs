using System;
using TechTalk.SpecFlow;
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

        UIElementFactory.GetElement(elementName, CurrentView).Type(input);
    }

    [Then(@"the '(.*)' should (not )?be displayed")]
    public void ValidateDisplay(string elementName, string display)
    {
        if (display != null)
        {
            Assert.False(UIElementFactory.GetElement(elementName, CurrentView).WebElement.Displayed);
        }
        else
        {
            Assert.True(UIElementFactory.GetElement(elementName, CurrentView).WebElement.Displayed);
        }
    }
}
