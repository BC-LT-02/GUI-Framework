using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.Project
{
    [Binding]
    [Scope(Feature = "Retrieve an existing project")]
    public class GetByIdStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string url = "projects.json";

        public GetByIdStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user sends a GET request to the api endpoint with a valid project ID")]
        public void WhentheusersendsaGETrequesttotheapiendpointwithavalidprojectID()
        {
            Client.AddDefaultHeader("Authorization", _scenarioContext["Authorization"].ToString()!);
            Client.AddDefaultHeader("Accept", "*/*");

            _scenarioContext["Response"] = Client.Get(url);
        }

        [Then(
            @"the response should have a status code of ""(.*)"" and should contain the details of the valid project"
        )]
        public void Thentheresponseshouldhaveastatuscodeofandshouldcontainthedetailsofthevalidproject(
            string statusCode
        )
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());

            var user = JsonSerializer.Deserialize<ProjectPayload>(response.Content!);
            Assert.IsType<ProjectPayload>(user);
        }

        [When(
            @"the user sends a GET request to the api endpoint with an invalid project ID ""(.*)"""
        )]
        public void WhentheusersendsaGETrequesttotheapiendpointwithaninvalidprojectID(string id)
        {
            Client.AddDefaultHeader(
                "Authorization",
                "Basic YWRyaWVsLmdpbWVuZXNAamFsYS51bml2ZXJzaXR5OlRvZG8ubHkzMjY4MA=="
            );
            Client.AddDefaultHeader("Accept", "*/*");

            _scenarioContext["Response"] = Client.Get($"projects/{id}.json");
        }

        [Then(
            @"the response should have a status code of ""(.*)"" and the response should contain an error message ""(.*)"""
        )]
        public void Thentheresponseshouldhaveastatuscodeofandtheresponseshouldcontainanerrormessage(
            string statusCode,
            string errorMessage
        )
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());

            var error = JsonSerializer.Deserialize<ErrorResponseModel>(response.Content!);
            Assert.IsType<ErrorResponseModel>(error);
            Assert.Equal(errorMessage, error!.ErrorMessage);
            Assert.Equal(102, error!.ErrorCode);
        }

        [When(@"the user sends a GET request to the api endpoint with an valid project ID")]
        public void WhentheusersendsaGETrequesttotheapiendpointwithanvalidprojectID()
        {
            Client.AddDefaultHeader("Accept", "*/*");

            _scenarioContext["Response"] = Client.Get(url);
        }

        [Then(
            @"the response should have a status code of ""(.*)"" and a ""(.*)"" error message indicating that the user is not authorized to access the resource."
        )]
        public void Thentheresponseshouldhaveastatuscodeofandaerrormessageindicatingthattheuserisnotauthorizedtoaccesstheresource(
            string statusCode,
            string errorMessage
        )
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
