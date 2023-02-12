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

        // RestResponse response = _client.Post(_url, payload);
        RestResponse response = _client.DoRequest(Method.Post, _url, payload);
        if (!response.IsSuccessful)
        {
            throw new Exception("Error: Bad Request");
        }

        ProjectModel? projectContent = JsonSerializer.Deserialize<ProjectModel>(
            response.Content!
        );
        if (projectContent!.Content != _projectName)
        {
            throw new Exception("Error: Response field 'Content' does not match input payload");
        }

        _scenarioContext[ConfigModel.CurrentProject] = _projectName;
    }
}
