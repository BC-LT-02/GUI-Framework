using System;
using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
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

<<<<<<< HEAD:3.Tests/UI/Hooks/Hooks.cs
    [AfterTestRun]
    public static void CleanUp()
    {
        APIScripts.RemoveAllProjects();
    }

    [AfterScenario]
    public void SessionDisposal()
    {
        GenericWebDriver.Dispose();
    }

=======
>>>>>>> 5588e6d (Added initial 'BaseHook' implementation):3.Tests/UI/Hooks/ProjectHooks.cs
    [BeforeScenario("create.project")]
    public void CreateProject()
    {
        string payload = $"{{ \"Content\": \"{_projectName}\" }}";

        _client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, ConfigModel.TODO_LY_PASS);

        RestResponse response = _client.DoRequest(Method.Post, _url, payload);
        ProjectModel? projectModel = JsonSerializer.Deserialize<ProjectModel>(response.Content!);

<<<<<<< HEAD:3.Tests/UI/Hooks/Hooks.cs
        _scenarioContext[ConfigModel.CurrentProject] = _projectName;
        _scenarioContext[ConfigModel.CurrentProjectPayload] = projectModel;
=======
        _scenarioContext.Add(ConfigModel.CurrentProject, _projectName);
        _scenarioContext.Add("projectContent", projectContent);
>>>>>>> 5588e6d (Added initial 'BaseHook' implementation):3.Tests/UI/Hooks/ProjectHooks.cs
    }
}
