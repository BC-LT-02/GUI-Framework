using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.Commons
{
    public class CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        public readonly RestHelper Client;

        public CommonSteps(ScenarioContext scenarioContext)
        {
            Client = new RestHelper(ConfigBuilder.Instance.GetString("api", "ApiHostUrl"));
            _scenarioContext = scenarioContext;
        }

        [Given(@"the user has (valid|invalid) credentials")]
        public void SetCredentials(string credentials)
        {
            if (credentials == "valid")
            {
                Client.AddAuthenticator(ConfigBuilder.Instance.GetString("TODO-LY-EMAIL"), ConfigBuilder.Instance.GetString("TODO-LY-PASS"));
            }
            else
            {
                Client.AddAuthenticator("invalidemail@email.com", "");
            }
        }

        [Then(@"the API should return a ""(.*)"" response")]
        public void APIShouldReturnOkResponse(string response)
        {
            RestResponse res = (RestResponse)_scenarioContext["Response"];
            Assert.True(res.IsSuccessful);
            Assert.Equal(response, res.StatusCode.ToString());
        }

        [Then(@"the API should return a (.*) status code with a ""(.*)"" error message")]
        public void APIShouldReturnStatusCodeAndUserNotFoundErrorMessage(int statusCode, string message)
        {
            RestResponse res = (RestResponse)_scenarioContext["Response"];

            var error = JsonSerializer.Deserialize<ErrorModel>(res.Content!);
            Assert.IsType<ErrorModel>(error);
            Assert.Equal(message, error!.ErrorMessage);
            Assert.Equal(statusCode, error!.ErrorCode);
        }
    }
}
