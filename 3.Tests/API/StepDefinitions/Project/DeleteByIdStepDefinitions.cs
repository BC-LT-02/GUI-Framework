using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.Project
{
    [Binding]
    [Scope(Feature = "Delete an existing project by ID")]
    public class DeleteProjectStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public DeleteProjectStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a DELETE request to ""(.*)""")]
        public void WhentheusersubmitsaDELETErequestto(string endpoint)
        {
            var newProject = _scenarioContext.Get<RestResponse>(ConfigBuilder.Instance.GetString("api", "CurrentProject"));
            string projectId = JsonSerializer.Deserialize<ProjectModel>(newProject!.Content!)!.Id.ToString()!;
            endpoint = endpoint.Replace("[id]", projectId);
            _scenarioContext["Response"] = Client.DoRequest(Method.Delete, endpoint, null);
        }

        [When(@"the user submits a DELETE request to ""(.*)"" with invalid email")]
        public void WhentheusersubmitsaDELETErequesttowithinvalidemail(string endpoint)
        {
            endpoint = endpoint.Replace("[id]", "12345");
            _scenarioContext["Response"] = Client.DoRequest(Method.Delete, endpoint, null);
        }

        [Then(@"the API should return a ""(.*)"" response with the deleted project information")]
        public void ThentheAPIshouldreturnaresponsewiththedeletedprojectinformation(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var project = JsonSerializer.Deserialize<ProjectModel>(response.Content!);
            Assert.IsType<ProjectModel>(project);
            Assert.Equal("New Project", project.Content);
        }
    }
}
