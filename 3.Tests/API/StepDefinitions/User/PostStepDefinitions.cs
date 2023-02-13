using System.Text.Json;
using RestSharp;
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
        public void WhentheusersubmitsaPOSTrequesttowithavalidJSONbody(string endpoint, string body)
        {
            _scenarioContext["Response"] = Client.DoRequest(Method.Post, endpoint, body);
        }

        [Then(@"the API should return a ""(.*)"" response with the new user information")]
        public void ThentheAPIshouldreturnastatuscodeandthenewuserinformationinJSONformat(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var user = JsonSerializer.Deserialize<UserModel>(response.Content!);
            Assert.IsType<UserModel>(user);
            Assert.Equal("newUser@email.com", user.Email);
        }

        [AfterScenario]
        public void DeleteUser()
        {
            Client.AddAuthenticator("newUser@email.com", "password");
            Client.DoRequest(Method.Delete, "user/0.json", null);
        }

        [When(@"the user submits a POST request to ""(.*)"" with a JSON body that is missing email required fields")]
        public void WhentheusersubmitsaPOSTrequesttowithaJSONbodythatismissingemailrequiredfields(string endpoint, string body)
        {
            _scenarioContext["Response"] = Client.DoRequest(Method.Post, endpoint, body);
        }

        [When(@"the user submits a POST request to ""(.*)"" with a JSON body that has an existing email")]
        public void WhentheusersubmitsaPOSTrequesttowithaJSONbodythathasanemailpreviouslyusedtocreateanaccount(string endpoint, string body)
        {
            _scenarioContext["Response"] = Client.DoRequest(Method.Post, endpoint, body);
        }
    }
}
