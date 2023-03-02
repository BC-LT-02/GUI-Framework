﻿using System;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.WebActions;
using Todoly.Views.Helpers;
using Todoly.Views.WebAppPages;

namespace Todoly.Tests.UI.Steps.Commons;

[Binding]
public class CommonSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly LoginPage _loginPage = new LoginPage();

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
        _loginPage.LoginIntoApplication();
    }

    [When(@"(?:the user )?clicks on '([a-zA-Z ]+)'(?: at '([a-zA-Z ]+)')?$")]
    public void Click(string elementName, string viewName)
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        UIElementFactory.GetElement(elementName, CurrentView).Click();
    }

    [When(@"(?:the user )?clicks on '([a-zA-Z ]+)' <([a-zA-Z ]+)>(?: at '([a-zA-Z ]+)')?$")]
    public void Click(string elementName, string locatorArgument, string viewName)
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        UIElementFactory.GetElement(elementName, CurrentView, locatorArgument).Click();
    }

    [When(@"(?:the user )?types ""(.*)"" on '([a-zA-Z ]+)'(?: at '([a-zA-Z ]+)')?$")]
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

    [When(
        @"(?:the user )?opens the Project Context Menu on <([a-zA-Z ]+)>(?: at '([a-zA-Z ]+)')?$"
    )]
    public void OpenContextMenu(string locatorArgument, string viewName)
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        _scenarioContext[ConfigModel.CurrentProject] = locatorArgument;

        WebActions.HoverElement(
            UIElementFactory.GetElement("Project Button", CurrentView, locatorArgument).WebElement
        );
        UIElementFactory.GetElement("Project Context Button", CurrentView, locatorArgument).Click();
    }

    [When(@"the user drags and drop '([\w ]+)' '([\w ]+)' (above|on top of) '([\w ]+)'(?: at '([a-zA-Z ]+)')?$")]
    public void DragAndDrop(string locatorArgument1, string elementName, string placeToDrop, string locatorArgument2, string viewName)
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        int x = 0, y = 0;
        if (placeToDrop == "above")
        {
            y = -1;
        }
        else if (placeToDrop == "on top of")
        {
            x = 15;
            y = 1;
        }

        var source = UIElementFactory.GetElement(elementName, CurrentView, locatorArgument1).WebElement;
        var target = UIElementFactory.GetElement(elementName, CurrentView, locatorArgument2).WebElement;

        WebActions.DragAndDrop(source, target, x, y);
    }

    [When(@"(?:the user )?clicks on '([a-zA-Z ]+)' on the Project Context Menu")]
    public void ProjectContextMenuAction(string locatorArgument)
    {
        locatorArgument = ProjectContextMenuHelper.ParseButtonName(locatorArgument);
        UIElementFactory
            .GetElement("Context Menu Buttons", "Project Component", locatorArgument)
            .Click();
    }

    [Then(@"the '(.*)' should (not )?be displayed(?: at '([a-zA-Z ]+)')?$")]
    public void ValidateDisplay(string elementName, string display, string viewName)
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        if (display == "not ")
        {
            Assert.True(UIElementFactory.GetElement(elementName, CurrentView).IsInvisible());
        }
        else
        {
            Assert.True(UIElementFactory.GetElement(elementName, CurrentView).WebElement.Displayed);
        }
    }

    [Then(@"the '(.*)' <(.*)> should (not )?be displayed(?: at '([a-zA-Z ]+)')?$")]
    public void ValidateDisplay(
        string elementName,
        string locatorArgument,
        string display,
        string viewName
    )
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        if (display == "not ")
        {
            Assert.True(UIElementFactory.GetElement(elementName, CurrentView).IsInvisible());
        }
        else
        {
            Assert.True(
                UIElementFactory
                    .GetElement(elementName, CurrentView, locatorArgument)
                    .WebElement.Displayed
            );
        }
    }

    [When(@"(?:the user )?hovers on '([a-zA-Z ]+)'(?: at '([a-zA-Z ]+)')?$")]
    public void Hover(string elementName, string viewName)
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        WebActions.HoverElement(UIElementFactory.GetElement(elementName, CurrentView).WebElement);
    }

    [When(@"(?:the user )?hovers on ""([\w ]+)""(?: <([\w ]+)>)?(?: at '([\w ]+)')?$")]
    public void HoverItemName(string elementName, string itemName, string viewName)
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        WebActions.HoverElement(
            UIElementFactory.GetElement(elementName, CurrentView, itemName).WebElement
        );
    }

    [When(
        @"(?:the user )?clicks on [\x22']([\w ]+)[\x22'](?: <([\w ]+)>)?(?: on [\x22']([\w ]+)[\x22'])? option at [\x22']([\w ]+)[\x22']$"
    )]
    public void ClickContextOption(
        string elementName,
        string itemName,
        string optionName,
        string viewName
    )
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        UIElementFactory.GetElement("Item Context Button", CurrentView, itemName).Click();
        UIElementFactory.GetElement(elementName, CurrentView, optionName).Click();
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
    }

    [Then(@"the snack bar message is '(.*)' at '([a-zA-Z ]+)'")]
    public void Giventhesnackbarmessageis(string expectedMessage, string viewName)
    {
        if (viewName != null)
        {
            CurrentView = viewName;
        }

        Assert.That(
            UIElementFactory.GetElement("Information Message", CurrentView).WebElement.Text,
            Is.EqualTo(expectedMessage)
        );
    }

    [Then(@"the project '([\w ]+)' should appear before '([\w ]+)'")]
    public void VerifyProjectsOrder(string project1, string project2)
    {
        string[] projectNames = APIScripts.RetrieveProjectNames();

        Assert.That(Array.IndexOf(projectNames, project1), Is.LessThan(Array.IndexOf(projectNames, project2)));
    }

    [When(@"(?:the user )?enters the item [\x22\x27]([\w ]+)[\x22\x27] on [\x22\x27]([\w ]+)[\x22\x27] input$")]
    public void TypeOnElement(string input, string elementName)
    {
        UIElementFactory.GetElement(elementName, "Items Component").Type(input);
        UIElementFactory.GetElement(elementName, "Items Component").Type(Keys.Enter);
    }
}
