using System.Collections.Generic;
using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.Project
{
    [Binding]
    [Scope(Feature = "Retrieve all existing projects")]
    public class GetAllStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public GetAllStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a GET request to ""(.*)""")]
        public void WhentheusersubmitsaGETrequestto(string endpoint)
        {
            _scenarioContext["Response"] = Client.DoRequest(Method.Get, endpoint, null);
        }

        [Then(@"the API should return a ""(.*)"" response with the list of all the projects")]
        public void ThentheAPIshouldreturnaresponsewiththelistofalltheprojects(string response)
        {
            RestResponse res = (RestResponse)_scenarioContext["Response"];
            Assert.True(res.IsSuccessful);
            Assert.Equal(response, res.StatusCode.ToString());
            var projects = JsonSerializer.Deserialize<List<ProjectModel>>(res.Content!);

            Assert.IsType<List<ProjectModel>>(projects);
            foreach (ProjectModel project in projects)
            {
                Assert.NotNull(project.Content);
                Assert.NotNull(project.Id);
            }
        }
    }
}
