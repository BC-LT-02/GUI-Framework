using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.User
{
    [Binding]
    [Scope(Feature = "Retrieve user information")]
    public class GetStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public GetStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a GET request to ""(.*)""")]
        public void WhentheusersubmitsaGETrequestto(string endpoint)
        {
            _scenarioContext["Response"] = Client.DoRequest(Method.Get, endpoint, null);
        }

        [Then(@"the API should return a ""(.*)"" response with the requested user information")]
        public void ThentheAPIshouldreturnastatuscode(string response)
        {
            RestResponse res = (RestResponse)_scenarioContext["Response"];
            Assert.True(res.IsSuccessful);
            Assert.Equal(response, res.StatusCode.ToString());
            var user = JsonSerializer.Deserialize<UserModel>(res.Content!);

            Assert.IsType<UserModel>(user);
            Assert.Contains(user.Email!, ConfigBuilder.Instance.GetString("TODO-LY-EMAIL"));
        }
    }
}
