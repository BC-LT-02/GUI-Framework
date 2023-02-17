﻿using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using OpenQA.Selenium;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Views.Models;

namespace SeleniumTest.Tests.Hooks;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;
    private readonly RestHelper _client;
    private readonly string _urlProject;
    private readonly string _projectName;
    private readonly string _userFullName;
    private readonly string _urlUserPutUri;
    private readonly string _urlItem;
    private readonly string _itemName;
    private ProjectModel? _projectModel;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _client = new RestHelper(ConfigModel.ApiHostUrl);
        _urlProject = ConfigModel.ProjectUri;
        _projectName = IdHelper.GetNewId();
        _urlUserPutUri = ConfigModel.UserPutUri;
        _userFullName = ConfigModel.UserFullName;
        _urlItem = ConfigModel.ItemUri;
        _itemName = IdHelper.GetNewId();
    }

    [AfterTestRun]
    public static void CleanUp()
    {
        APIScripts.RemoveAllProjects();
    }

    [AfterScenario("delete.projects")]
    public static void RemoveProjects()
    {
        APIScripts.RemoveAllProjects();
    }

    [AfterScenario]
    public void SessionDisposal()
    {
        GenericWebDriver.Dispose();
    }
    
    [BeforeScenario(Order = 1)]
    public void CreateProject()
    {
        var scenarioTags = _scenarioContext.ScenarioInfo.Tags.ToList();

        scenarioTags = scenarioTags
            .Where(tag => tag.StartsWith("create.project."))
            .Select(tag => tag.Replace("create.project.", ""))
            .ToList();

        if (scenarioTags.Count.Equals(0))
        {
            return;
        }

        foreach (string tag in scenarioTags)
        {
            string payload = $"{{ \"Content\": \"{tag}\" }}";

            _client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, ConfigModel.TODO_LY_PASS);

            RestResponse response = _client.DoRequest(Method.Post, _urlProject, payload);
            _projectModel = JsonSerializer.Deserialize<ProjectModel>(response.Content!);

            _scenarioContext[tag] = tag;
            _scenarioContext[tag + "Model"] = _projectModel;
        }
    }

    [AfterScenario("update.fullname")]
    public void UpdateFullName()
    {
        string payload = $"{{ \"FullName\": \"{_userFullName}\" }}";

        _client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, ConfigModel.TODO_LY_PASS);
        _client.DoRequest(Method.Put, _urlUserPutUri, payload);
    }

    [AfterScenario]
    public void CaptureScreenshot()
    {
        if (_scenarioContext.TestError != null)
        {
            Screenshot image = ((ITakesScreenshot)GenericWebDriver.Instance).GetScreenshot();
            string path = $"../../../Assets/{_scenarioContext.ScenarioInfo.Title}";
            path = string.Join(" ", path.Split().Select(word => char.ToUpper(word[0]) + word.Substring(1))).Replace(" ", "");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = new string(DateTime.Now.ToString()
                              .Where(c => !char.IsWhiteSpace(c) && c != '/' && c != ':')
                              .ToArray());

            image.SaveAsFile($"{path}/{fileName}.png", ScreenshotImageFormat.Png);
        }

        GenericWebDriver.Dispose();
    }

    [AfterScenario("recover.password")]
    public void RecoverPassword()
    {
        string payload = $"{{ \"Password\": \"{ConfigModel.TODO_LY_PASS}\" }}";
        string password = _scenarioContext.Get<string>("Password");
        _client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, password);
        _client.DoRequest(Method.Put, _urlUserPutUri, payload);
    }

    [AfterScenario("recover.email")]
    public void RecoverEmail()
    {
        string payload = $"{{ \"Email\": \"{ConfigModel.TODO_LY_EMAIL}\" }}";
        string email = _scenarioContext.Get<string>("Email");
        _client.AddAuthenticator(email, ConfigModel.TODO_LY_PASS);
        _client.DoRequest(Method.Put, _urlUserPutUri, payload);
    }

    [BeforeScenario("create.item", Order = 2)]
    public void CreateAnItem()
    {
        string payload = $"{{ \"Content\": \"{_itemName}\", \"ProjectId\": {_projectModel!.Id} }}";
        _client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, ConfigModel.TODO_LY_PASS);

        RestResponse response = _client.DoRequest(Method.Post, _urlItem, payload);
        if (!response.IsSuccessful)
        {
            throw new Exception("Error: Bad Request");
        }

        ItemModel? itemContent = JsonSerializer.Deserialize<ItemModel>(response.Content!);

        if (itemContent!.Content != _itemName)
        {
            throw new Exception("Error: Response field 'Content' does not match input payload");
        }

        _scenarioContext.Add(ConfigModel.CurrentItem, _itemName);
        _scenarioContext.Add("itemContent", itemContent);
    }

    [AfterScenario]
    public void SessionDisposal()
    {
        GenericWebDriver.Dispose();
    }
}
