using System;
using System.Linq;
using System.Text.Json;
using OpenQA.Selenium;
using RestSharp;
using Sprache;
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
    private readonly string _url;
    private readonly string _projectName;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _client = new RestHelper(ConfigModel.ApiHostUrl);
        _url = ConfigModel.ProjectUri;
        _projectName = IdHelper.GetNewId();
    }

    [AfterTestRun]
    public static void CleanUp()
    {
        APIScripts.RemoveAllProjects();
    }

    // [AfterScenario]
    // public void SessionDisposal()
    // {
    //     GenericWebDriver.Dispose();
    // }

    [BeforeScenario("create.project")]
    public void CreateProject()
    {
        string payload = $"{{ \"Content\": \"{_projectName}\" }}";

        _client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, ConfigModel.TODO_LY_PASS);

        RestResponse response = _client.DoRequest(Method.Post, _url, payload);
        ProjectModel? projectModel = JsonSerializer.Deserialize<ProjectModel>(response.Content!);

        _scenarioContext[ConfigModel.CurrentProject] = _projectName;
        _scenarioContext[ConfigModel.CurrentProjectPayload] = projectModel;
    }

    [AfterScenario]
    public void CaptureScreenshot()
    {
        if (_scenarioContext.TestError != null)
        {
            Screenshot image = ((ITakesScreenshot)GenericWebDriver.Instance).GetScreenshot();
            string fileName = $"{_scenarioContext.ScenarioInfo.Title}_{DateTime.Now}";
            fileName = string.Join(" ", fileName.Split().Select(word => char.ToUpper(word[0]) + word.Substring(1)));
            fileName = fileName.Replace(" ", "");
            fileName = fileName.Replace("/", "");
            fileName = fileName.Replace(":", "");
            image.SaveAsFile($"../../../Assets/{fileName}.png", ScreenshotImageFormat.Png);
        }

        GenericWebDriver.Dispose();

    }
}
