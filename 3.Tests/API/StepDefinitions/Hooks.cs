using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        public readonly RestHelper Client;

        public Hooks(ScenarioContext scenarioContext)
        {
            Client = new RestHelper(ConfigBuilder.Instance.GetString("api", "ApiHostUrl"));
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("create.project")]
        public void CreateProject()
        {
            Client.AddAuthenticator(ConfigBuilder.Instance.GetString("TODO-LY-EMAIL"), ConfigBuilder.Instance.GetString("TODO-LY-PASS"));
            string body = "{ \"Content\": \"New Project\" }";
            var response = Client.DoRequest(Method.Post, "/projects.json", body);
            _scenarioContext.Add(ConfigBuilder.Instance.GetString("api", "CurrentProject"), response);
        }

        [AfterScenario("delete.project")]
        public void DeleteProject()
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            var projectId = JsonSerializer.Deserialize<ProjectModel>(response.Content!)!.Id.ToString();
            Client.AddAuthenticator(ConfigBuilder.Instance.GetString("TODO-LY-EMAIL"), ConfigBuilder.Instance.GetString("TODO-LY-PASS"));
            Client.DoRequest(Method.Delete, $"projects/{projectId}.json", null);
        }
    }
}
