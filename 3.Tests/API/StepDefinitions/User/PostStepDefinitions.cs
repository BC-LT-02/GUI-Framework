using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using TechTalk.SpecFlow;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.User
{
    [Binding]
    [Scope(Feature = "User Creation")]
    public class PostStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public PostStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a POST request to ""(.*)"" with a valid JSON body")]
        public void WhentheusersubmitsaPOSTrequesttowithavalidJSONbody(string url, string body)
        {
            UserPayloadModel? user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserPayloadModel>(body);
            _scenarioContext["Response"] = Client.Post<UserPayloadModel>(url, user);
        }

        [Then(@"the API should return a ""(.*)"" status code and the new user information in JSON format")]
        public void ThentheAPIshouldreturnastatuscodeandthenewuserinformationinJSONformat(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var user = JsonSerializer.Deserialize<UserPayloadModel>(response.Content!);
            Assert.IsType<UserPayloadModel>(user);
            Assert.Equal("newUser@email.com", user.Email);
        }

        [AfterScenario]
        public void DeleteUser()
        {
            RestClient client = new RestClient("https://todo.ly/api");
            client.Authenticator = new HttpBasicAuthenticator("newUser@email.com", "password");

            RestRequest request = new RestRequest("user/0.json", Method.Delete);
            client.Execute(request);
        }

        [When(@"the user submits a POST request to ""(.*)"" with a JSON body that is missing email required fields")]
        public void WhentheusersubmitsaPOSTrequesttowithaJSONbodythatismissingemailrequiredfields(string url, string body)
        {
            UserPayloadModel? user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserPayloadModel>(body);
            _scenarioContext["Response"] = Client.Post<UserPayloadModel>(url, user);
        }

        [Then(@"the API should return a ""(.*)"" response with a (.*) status code and a ""(.*)"" error message indicating missing fields")]
        public void ThentheAPIshouldreturnaresponsewithastatuscodeandaerrormessageindicatingmissingfields(string response, int statusCode, string message)
        {
            RestResponse res = (RestResponse)_scenarioContext["Response"];

            Assert.True(res.IsSuccessful);
            Assert.Equal(response, res.StatusCode.ToString());
            var error = JsonSerializer.Deserialize<ErrorResponseModel>(res.Content!);
            Assert.IsType<ErrorResponseModel>(error);
            Assert.Equal(message, error!.ErrorMessage);
            Assert.Equal(statusCode, error!.ErrorCode);
        }

        [When(@"the user submits a POST request to ""(.*)"" with a JSON body that has an invalid email")]
        public void WhentheusersubmitsaPOSTrequesttowithaJSONbodythathasaninvalidemail(string url, string body)
        {
            UserPayloadModel? user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserPayloadModel>(body);
            _scenarioContext["Response"] = Client.Post<UserPayloadModel>(url, user);
        }

        [Then(@"the API should return a ""(.*)"" response with a (.*) status code and a ""(.*)"" error message indicating invalid data")]
        public void ThentheAPIshouldreturnaresponsewithastatuscodeandaerrormessageindicatinginvaliddata(string response, int statusCode, string message)
        {
            RestResponse res = (RestResponse)_scenarioContext["Response"];

            Assert.True(res.IsSuccessful);
            Assert.Equal(response, res.StatusCode.ToString());
            var error = JsonSerializer.Deserialize<ErrorResponseModel>(res.Content!);
            Assert.IsType<ErrorResponseModel>(error);
            Assert.Equal(message, error!.ErrorMessage);
            Assert.Equal(statusCode, error!.ErrorCode);
        }

        [When(@"the user submits a POST request to ""(.*)"" with a JSON body that has an email previously used to create an account")]
        public void WhentheusersubmitsaPOSTrequesttowithaJSONbodythathasanemailpreviouslyusedtocreateanaccount(string url, string body)
        {
            UserPayloadModel? user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserPayloadModel>(body);
            _scenarioContext["Response"] = Client.Post<UserPayloadModel>(url, user);
        }

        [Then(@"the API should return a ""(.*)"" response with a (.*) status code and a ""(.*)"" error message indicating the email already exists")]
        public void ThentheAPIshouldreturnaresponsewithastatuscodeandaerrormessageindicatingtheemailalreadyexists(string response, int statusCode, string message)
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
