using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.Project
{
    [Binding]
    [Scope(Feature = "Retrieve all existing project")]
    public class GetAllStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string url = "projects.json";

        public GetAllStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user sends a GET request to the endpoint")]
        public void WhentheusersendsaGETrequesttotheendpoint()
        {
            Client.AddDefaultHeader("Authorization", _scenarioContext["Authorization"].ToString()!);
            Client.AddDefaultHeader("Accept", "*/*");

            _scenarioContext["Response"] = Client.Get(url);
        }

        [Then(@"the response should have a status code of ""(.*)"" and the response should contain a list of all projects")]
        public void Thentheresponseshouldhaveastatuscodeofandtheresponseshouldcontainalistofallprojects(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.Equal(statusCode, response.StatusCode.ToString());

            var user = JsonSerializer.Deserialize<ProjectPayload>(response.Content!);
            Assert.IsType<ProjectPayload>(user);
        }

        [When(@"the user sends a GET request to the api endpoint")]
        public void WhentheusersendsaGETrequesttotheapiendpoint()
        {
            Client.AddDefaultHeader("Accept", "*/*");

            _scenarioContext["Response"] = Client.Get(url);
        }

        [Then(@"the response should have a status code of ""(.*)"" and a ""(.*)"" error message indicating that the user is not authorized to access the resource.")]
        public void Thentheresponseshouldhaveastatuscodeofandaerrormessageindicatingthattheuserisnotauthorizedtoaccesstheresource(string statusCode, string errorMessage)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());

            var error = JsonSerializer.Deserialize<ErrorResponseModel>(response.Content!);
            Assert.IsType<ErrorResponseModel>(error);
            Assert.Equal(errorMessage, error!.ErrorMessage);
            Assert.Equal(102, error!.ErrorCode);
        }
    }
}
