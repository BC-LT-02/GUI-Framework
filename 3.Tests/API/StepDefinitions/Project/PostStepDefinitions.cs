using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.Project
{
    [Binding]
    [Scope(Feature = "Project Creation")]
    public class PostStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public PostStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a POST request to ""(.*)"" with a valid JSON body")]
        public void WhentheusersubmitsaPOSTrequesttowithavalidJSONbody(string endpoint, string body)
        {
            _scenarioContext["Response"] = Client.DoRequest(Method.Post, endpoint, body);
        }

        [Then(@"the API should return a ""(.*)"" response with the new project information")]
        public void ThentheAPIshouldreturnaresponsewiththenewprojectinformation(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var project = JsonSerializer.Deserialize<ProjectModel>(response.Content!);
            Assert.IsType<ProjectModel>(project);
            Assert.Equal("New Project", project.Content);
        }

        [AfterScenario("delete.project")]
        public void DeleteProject()
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            var projectId = JsonSerializer.Deserialize<ProjectModel>(response.Content!)!.Id.ToString();
            Client.AddAuthenticator(ConfigBuilder.Instance.GetString("TODO-LY-EMAIL"), ConfigBuilder.Instance.GetString("TODO-LY-PASS"));
            Client.DoRequest(Method.Delete, $"projects/{projectId}.json", null);
        }

        [When(@"the user submits a POST request to ""(.*)"" with an empty body")]
        public void WhentheusersubmitsaPOSTrequesttowithanemptybody(string endpoint)
        {
            _scenarioContext["Response"] = Client.DoRequest(Method.Post, endpoint, "");
        }
    }
}
