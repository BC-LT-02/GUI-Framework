using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.Project.Project.Update
{
    [Binding]
    [Scope(Feature = "Update an existing project by ID")]
    public class UpdateByIdStepDefinition : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public UpdateByIdStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a PUT request to ""(.*)"" with a valid JSON body")]
        public void WhentheusersubmitsaPUTrequesttowithavalidJSONbody(string endpoint, string body)
        {
            string projectId = JsonSerializer.Deserialize<ProjectModel>(newProject!.Content!)!.Id.ToString()!;
            // endpoint = $"/projects/{projectId}.json";
            endpoint = endpoint.Replace("[id]", projectId);
            _scenarioContext["Response"] = Client.DoRequest(Method.Put, endpoint, body);
        }

        [Then(@"the API should return a ""(.*)"" response with the updated project information")]
        public void ThentheAPIshouldreturnaresponsewiththeupdatedprojectinformation(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var project = JsonSerializer.Deserialize<ProjectModel>(response.Content!);
            Assert.IsType<ProjectModel>(project);
            Assert.Equal("Updated Project", project.Content);
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
