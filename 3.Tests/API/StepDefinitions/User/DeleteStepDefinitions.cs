using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.User
{
    [Binding]
    [Scope(Feature = "User Deletion")]
    public class DeleteStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public DeleteStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a POST request to ""(.*)"" with a valid JSON body")]
        public void WhentheusersubmitsaPOSTrequesttowithavalidJSONbody(string url, string body)
        {
            UserPayloadModel? user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserPayloadModel>(body);
            _scenarioContext["Response"] = Client.Post<UserPayloadModel>(url, user);
        }

        [When(@"the user submits a DELETE request to ""(.*)"" to delete his account")]
        public void GiventheusersubmitsaDELETErequesttotodeletehisaccount(string url)
        {
            Client.Authenticate("deleteUser@email.com", "password");
            Client.Delete(url);
        }

        [Then(@"the API should return a ""(.*)"" status code and the deleted user information in JSON format")]
        public void ThentheAPIshouldreturnastatuscodeandthedeleteduserinformationinJSONformat(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];

            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var user = JsonSerializer.Deserialize<UserPayloadModel>(response.Content!);
            Assert.IsType<UserPayloadModel>(user);
            Assert.Equal("deleteUser@email.com", user.Email);
        }

        [When(@"the user submits a DELETE request to ""(.*)""")]
        public void WhentheusersubmitsaDELETErequestto(string url)
        {
            Client.AddDefaultHeader("Authorization", _scenarioContext["Authorization"].ToString()!);
            Client.AddDefaultHeader("Accept", "*/*");
            _scenarioContext["Response"] = Client.Delete(url);
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
