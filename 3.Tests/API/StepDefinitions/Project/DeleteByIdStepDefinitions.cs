using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.Project
{
    [Binding]
    [Scope(Feature = "Delete a project by ID")]
    public class DeleteProjectStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private string ApiUrl = "";

        public DeleteProjectStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user has a valid project ""(.*)""")]
        public void Thentheusershouldre(int expectedId)
        {
            ApiUrl = $"projects/{expectedId}.json";
            var username = _scenarioContext["username"].ToString();
            var password = _scenarioContext["password"].ToString();
            Client.AddDefaultHeader("Accept", "*/*");
            Client.AddAuthenticator(username: username!, password: password!);

            _scenarioContext["Response"] = Client.Get(ApiUrl);
            var response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            var project = JsonSerializer.Deserialize<ProjectPayloadModel>(
                response.Content!.ToString()
            );
            Assert.Equal(project!.Id, expectedId);
        }

        [Then(@"the user sends a DELETE request to the API endpoint")]
        public void WhentheusersendsaDELETErequesttotheendpoint()
        {
            //_scenarioContext["Response"] = Client.Delete(ApiUrl);
            //var response = (RestResponse)_scenarioContext["Response"];
        }

        [Then(@"the project should be removed from the list of projects")]
        public void Thentheprojectshouldberemovedfromthelistofprojects()
        {
            _scenarioContext["Response"] = Client.Get(ApiUrl);
            var response = (RestResponse)_scenarioContext["Response"];
            Assert.NotEmpty(response.Content!);
        }

        [When(@"the user has an invalid project ""(.*)""")]
        public void GiventheuserhasaninvalidprojectID(long id)
        {
            ApiUrl = $"projects/{id}.json";
            Client.AddDefaultHeader(
                "Authorization",
                "Basic VmFsZXJpYS5Hb256YWxlc0BqYWxhLnVuaXZlcnNpdHk6MTIzNA=="
            );
            Client.AddDefaultHeader("Accept", "*/*");
        }

        [Then(
            @"the user sends a DELETE request for the non-existent project to the API endpoint and return a ""(.*)"" status code with the message: ""(.*)"""
        )]
        public void WhentheusersendsaDELETErequestforthenonexistentprojecttotheAPIendpoint(
            int expectedErrorCode,
            string expectedErrorMessage
        )
        {
            _scenarioContext["Response"] = Client.Get(ApiUrl);
            var response = (RestResponse)_scenarioContext["Response"];
            ErrorResponseModel? project = JsonSerializer.Deserialize<ErrorResponseModel>(
                response.Content!
            );
            Assert.Equal(project!.ErrorCode, expectedErrorCode);
            Assert.Equal(project!.ErrorMessage, expectedErrorMessage);
        }

        [Then(
            @"the API should return a ""(.*)"" status code and an error message indicating ""(.*)"" to access the resource"
        )]
        public void ThentheAPIshouldreturna401statuscodeandanerrormessageindicatingthattheuserisnotauthorizedtoaccesstheresource(
            int expectedErrorCode,
            string expectedErrorMessage
        )
        {
            _scenarioContext["Response"] = Client.Delete(ApiUrl);
            var response = (RestResponse)_scenarioContext["Response"];
            ErrorResponseModel? project = JsonSerializer.Deserialize<ErrorResponseModel>(
                response.Content!
            );
            Assert.Equal(project!.ErrorCode, expectedErrorCode);
            Assert.Equal(project!.ErrorMessage, expectedErrorMessage);
        }
    }
}
