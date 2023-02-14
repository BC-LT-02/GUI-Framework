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
            var newProject = _scenarioContext.Get<RestResponse>(ConfigBuilder.Instance.GetString("api", "CurrentProject"));
            string projectId = JsonSerializer.Deserialize<ProjectModel>(newProject!.Content!)!.Id.ToString()!;
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

        [When(@"the user submits a PUT request to ""(.*)"" with a valid JSON body and invalid email")]
        public void WhentheusersubmitsaPUTrequesttowithavalidJSONbodyandinvalidemail(string endpoint, string body)
        {
            endpoint = endpoint.Replace("[id]", "12345");
            _scenarioContext["Response"] = Client.DoRequest(Method.Put, endpoint, body);
        }
    }
}
