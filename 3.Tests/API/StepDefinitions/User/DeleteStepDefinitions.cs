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

        [BeforeScenario("create.user")]
        public void CreateUser()
        {
            string body = "{ \"Email\": \"newusername@testing.com\", \"FullName\": \"New Name\", \"Password\": \"password\"  }";
            Client.DoRequest(Method.Post, "/user.json", body);
        }

        [When(@"the user submits a DELETE request to ""(.*)""")]
        public void WhentheusersubmitsaDELETErequestto(string endpoint)
        {
            Client.AddAuthenticator("newusername@testing.com", "password");
            _scenarioContext["Response"] = Client.DoRequest(Method.Delete, endpoint, null);
        }

        [When(@"the user submits a DELETE request to ""(.*)"" with invalid email")]
        public void WhentheusersubmitsaDELETErequesttowithinvalidemail(string endpoint)
        {
            _scenarioContext["Response"] = Client.DoRequest(Method.Delete, endpoint, null);
        }

        [Then(@"the API should return a ""(.*)"" response with the deleted user information")]
        public void ThentheAPIshouldreturnaresponsewiththedeleteduserinformation(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var user = JsonSerializer.Deserialize<UserModel>(response.Content!);
            Assert.IsType<UserModel>(user);
            Assert.Equal("New Name", user.FullName);
            Assert.Equal("newusername@testing.com", user.Email);
        }
    }
}
