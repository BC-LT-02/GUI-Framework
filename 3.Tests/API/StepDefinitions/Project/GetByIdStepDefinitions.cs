using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.Project
{
    [Binding]
    [Scope(Feature = "Retrieve an existing project")]
    public class GetByIdStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public GetByIdStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a GET request to ""(.*)""")]
        public void WhentheusersubmitsaGETrequestto(string endpoint)
        {
            var newProject = _scenarioContext.Get<RestResponse>(ConfigBuilder.Instance.GetString("api", "CurrentProject"));
            string projectId = JsonSerializer.Deserialize<ProjectModel>(newProject!.Content!)!.Id.ToString()!;
            endpoint = endpoint.Replace("[id]", projectId);
            _scenarioContext["Response"] = Client.DoRequest(Method.Get, endpoint, null);
            ;
        }

        [Then(@"the API should return a ""(.*)"" response with the requested project information")]
        public void ThentheAPIshouldreturnaresponsewiththerequestedprojectinformation(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var project = JsonSerializer.Deserialize<ProjectModel>(response.Content!);
            Assert.IsType<ProjectModel>(project);
            Assert.Equal("New Project", project.Content);
        }

        [When(@"the user submits a GET request to ""(.*)"" with invalid ID")]
        public void WhentheusersubmitsaGETrequesttowithinvalidID(string endpoint)
        {
            endpoint = endpoint.Replace("[id]", "1239887766123");
            _scenarioContext["Response"] = Client.DoRequest(Method.Get, endpoint, null);
        }

        [When(@"the user submits a GET request to ""(.*)"" with invalid email")]
        public void WhentheusersubmitsaGETrequesttowithinvalidemail(string endpoint)
        {
            endpoint = endpoint.Replace("[id]", "12345");
            _scenarioContext["Response"] = Client.DoRequest(Method.Get, endpoint, null);
        }
    }
}
