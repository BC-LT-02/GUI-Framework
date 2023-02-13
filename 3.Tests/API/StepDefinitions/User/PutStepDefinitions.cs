using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.User
{
    [Binding]
    [Scope(Feature = "User Update")]
    public class PutStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public PutStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a PUT request to ""(.*)"" with a valid JSON body")]
        public void WhentheusersubmitsaPUTrequesttowithavalidJSONbody(string endpoint, string body)
        {
            _scenarioContext["Response"] = Client.DoRequest(Method.Put, endpoint, body);
        }

        [Then(@"the API should return a ""(.*)"" response with the updated user information")]
        public void ThentheAPIshouldreturnaresponsewiththeupdateduserinformation(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var user = JsonSerializer.Deserialize<UserModel>(response.Content!);
            Assert.IsType<UserModel>(user);
            Assert.Equal("New Name", user.FullName);
        }

        [AfterScenario("update.user.fullname")]
        public void UpdateUserFullName()
        {
            Client.AddAuthenticator(ConfigBuilder.Instance.GetString("TODO-LY-EMAIL"), ConfigBuilder.Instance.GetString("TODO-LY-PASS"));
            string body = "{ \"FullName\": \"Base Name\" }";
            Client.DoRequest(Method.Put, "/user/0.json", body);
        }
    }
}
