using System.Text.Json;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;
using RestSharp;
using TechTalk.SpecFlow;

namespace Todoly.Tests.API.Steps.Project
{
    [Binding]
    [Scope(Feature = "Project Creation")]
    public class PostStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string url = "projects.json";

        public PostStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user sends a POST request to the API endpoint with a valid JSON or XML payload")]
        public void WhentheusersendsaPOSTrequesttotheAPIendpointwithavalidJSONorXMLpayload()
        {
            ProjectPayloadModel body = new ProjectPayloadModel(
                null,
                content: "My New Project",
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
            );
            _scenarioContext["Response"] = Client.Post<ProjectPayloadModel>(url, body);
        }

        [Then(@"the response should have a status code of ""(.*)"" and the new project should be added to the database and the response should contain the details of the newly created project")]
        public void Thentheresponseshouldhaveastatuscodeofandthenewprojectshouldbeaddedtothedatabaseandtheresponseshouldcontainthedetailsofthenewlycreatedproject(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var project = JsonSerializer.Deserialize<ProjectPayloadModel>(response.Content!);
            Assert.IsType<ProjectPayloadModel>(project);
        }

        [When(@"the user sends a POST request to the API endpoint with a JSON or XML payload that is missing required fields")]
        public void WhentheusersendsaPOSTrequesttotheAPIendpointwithaJSONorXMLpayloadthatismissingrequiredfields()
        {
            ProjectPayloadModel body = new ProjectPayloadModel(
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
            );
            _scenarioContext["Response"] = Client.Post<ProjectPayloadModel>(url, body);
        }

        [Then(@"the response should have a status code of ""(.*)"" and a error message indicating missing fields")]
        public void Thentheresponseshouldhaveastatuscodeofandaerrormessageindicatingmissingfields(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var res = JsonSerializer.Deserialize<ErrorResponseModel>(response.Content!);
            Assert.IsType<ErrorResponseModel>(res);
        }
    }
}
