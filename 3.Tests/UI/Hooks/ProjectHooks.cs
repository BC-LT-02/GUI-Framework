using System;
using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Views.Models;

namespace SeleniumTest.Tests.Hooks;

[Binding]
public class ProjectHooks
{
    private readonly ScenarioContext _scenarioContext;
    private readonly RestHelper _client;
    private readonly string _url;
    private readonly string _projectName;

    public ProjectHooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _client = new RestHelper(ConfigModel.ApiHostUrl);
        _url = ConfigModel.ProjectUri;
        _projectName = IdHelper.GetNewId();
    }

    [AfterScenario]
    public void SessionDisposal()
    {
        GenericWebDriver.Dispose();
    }

    [BeforeScenario("create.project")]
    public void CreateProject()
    {
        string payload = $"{{ \"Content\": \"{_projectName}\" }}";

        _client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, ConfigModel.TODO_LY_PASS);

        RestResponse response = _client.DoRequest(Method.Post, _url, payload);
        _ = JsonSerializer.Deserialize<ProjectModel>(
            response.Content!
        );

        _scenarioContext[ConfigModel.CurrentProject] = _projectName;
    }

    // [AfterScenario("delete.project")]
    // public void DeleteProject()
    // {
    //     _client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, ConfigModel.TODO_LY_PASS);

    //     RestResponse getResponse = _client.DoRequest(Method.Get, _url, null);

    //     ProjectModel[]? projectContent = JsonSerializer.Deserialize<ProjectModel[]>(getResponse.Content!);

    //     Console.WriteLine("Was the request successful " + projectContent.);

    //     // RestResponse response = _client.DoRequest(Method.Delete, _url, null);
    //     // Console.WriteLine("Was the request successful " + response.Content);
    // }
}
