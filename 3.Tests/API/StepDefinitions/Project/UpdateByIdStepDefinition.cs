using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.Project.Project.Update
{
    [Binding]
    [Scope(Feature = "Update a Project by ID")]
    public class StepDefinitionsUpdate : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private string ApiUrl = "";

        public StepDefinitionsUpdate(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user has a valid project ""(.*)"" and submits a PUT request to the API endpoint")]
        public void WhentheuserhasavalidprojectIDandsubmitsaPUTrequesttotheAPIendpoint(int expectedId)
        {
            ApiUrl = $"projects/{expectedId}.json";
            var username = _scenarioContext["username"].ToString();
            var password = _scenarioContext["password"].ToString();
            Client.AddDefaultHeader("Accept", "*/*");
            Client.AddAuthenticator(username: username!, password: password!);

            ProjectPayloadModel body = new ProjectPayloadModel(
                id: expectedId,
                content: "New Content Name",
                itemOrder: 4
            );

            _scenarioContext["Response"] = Client.Put<ProjectPayloadModel>(ApiUrl, body);
        }

        [Then(
            "the API should return a (.*) status code and the project should be updated in the database"
        )]
        public void Thenincludestheupdatedprojectcontentitemscounticonitemtypeparentidcollapsedanditemorderintherequestbody(string expectedCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(expectedCode, response.StatusCode.ToString());
            var project = JsonSerializer.Deserialize<ProjectPayloadModel>(response.Content!);
            Assert.IsType<ProjectPayloadModel>(project);

        }

        [When(
            @"the user has a invalid project ""(.*)"" and submits a PUT request to the API endpoint"
        )]
        public void ThentheuserhasainvalidprojectIDandsubmitsaPUTrequesttotheAPIendpoint(int expectedID)
        {
            ApiUrl = $"projects/{expectedID}.json";
            var username = _scenarioContext["username"].ToString();
            var password = _scenarioContext["password"].ToString();
            Client.AddDefaultHeader("Accept", "*/*");
            Client.AddAuthenticator(username: username!, password: password!);

            ProjectPayloadModel body = new ProjectPayloadModel(
                id: expectedID,
                content: "New Content",
                itemOrder: 4
            );
            _scenarioContext["Response"] = Client.Put<ProjectPayloadModel>(ApiUrl, body);
        }

        [Then(
            @"the API should return a ""(.*)"" status code and an no JSON file"
        )]
        public void ThentheAPIshouldreturnaOKstatuscodeandanemptyJSON(string expectedCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(expectedCode, response.StatusCode.ToString());
            Assert.Empty(response.Content!);
        }
    }
}
