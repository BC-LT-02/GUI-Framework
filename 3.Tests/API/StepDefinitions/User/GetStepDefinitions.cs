using System.Text.Json;
using Features.GeneralSteps;
using Models;
using RestSharp;
using TechTalk.SpecFlow;

namespace Features.User.Get
{
    [Binding]
    [Scope(Feature = "Retrieve an existing user")]
    public class GetStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        // private readonly string url = "user.json";

        public GetStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a GET request to ""(.*)""")]
        public void WhentheusersubmitsaGETrequestto(string url)
        {
            Client.AddDefaultHeader("Authorization", _scenarioContext["Authorization"].ToString()!);
            Client.AddDefaultHeader("Accept", "*/*");

            _scenarioContext["Response"] = Client.Get(url);
        }

        [Then(@"the API should return a ""(.*)"" status code and the requested user information in JSON body format")]
        public void ThentheAPIshouldreturnastatuscodeandtherequesteduserinformationinJSONbodyformat(string statusCode, string body)
        {

            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());

            var user = JsonSerializer.Deserialize<UserPayloadModel>(response.Content!);
            Assert.IsType<UserPayloadModel>(user);
            Assert.Contains(user.Email!, body);
        }

        [When(@"the user submits a GET request to ""(.*)"" with an ""(.*)"" invalid user email")]
        public void WhentheusersubmitsaGETrequesttowithaninvaliduseremail(string url, string email)
        {
            Client.Authenticate(email, "password");
            _scenarioContext["Response"] = Client.Get(url);
        }

        [Then(@"the API should return a ""(.*)"" response with a (.*) status code and a ""(.*)"" error message indicating that the user was not found")]
        public void ThentheAPIshouldreturnaresponsewithastatuscodeandaerrormessageindicatingthattheuserwasnotfound(string response, int statusCode, string message)
        {
            RestResponse res = (RestResponse)_scenarioContext["Response"];

            Assert.True(res.IsSuccessful);
            Assert.Equal(response, res.StatusCode.ToString());

            var error = JsonSerializer.Deserialize<ErrorResponseModel>(res.Content!);
            Assert.IsType<ErrorResponseModel>(error);
            Assert.Equal(message, error!.ErrorMessage);
            Assert.Equal(statusCode, error!.ErrorCode);
        }

        [Then(@"the API should return a ""(.*)"" response with a (.*) status code and a ""(.*)"" error message indicating that the user is not authorized to access the resource.")]
        public void ThentheAPIshouldreturnaresponsewithastatuscodeandaerrormessageindicatingthattheuserisnotauthorizedtoaccesstheresource(string response, int statusCode, string message)
        {
            RestResponse res = (RestResponse)_scenarioContext["Response"];

            Assert.True(res.IsSuccessful);
            Assert.Equal(response, res.StatusCode.ToString());

            var error = JsonSerializer.Deserialize<ErrorResponseModel>(res.Content!);
            Assert.IsType<ErrorResponseModel>(error);
            Assert.Equal(message, error!.ErrorMessage);
            Assert.Equal(statusCode, error!.ErrorCode);
        }
    }
}
