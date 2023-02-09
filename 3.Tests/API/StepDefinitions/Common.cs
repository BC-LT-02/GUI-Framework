using System;
using DotNetEnv;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;

namespace Todoly.Tests.API.Steps.Commons
{
    public class CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        public readonly RestHelper Client = new RestHelper("https://todo.ly/api");

        public CommonSteps(ScenarioContext scenarioContext)
        {
            DotNetEnv.Env.TraversePath().Load();
            _scenarioContext = scenarioContext;
        }

        [Given(@"the user has a valid authentication")]
        public void Giventheuserhasavalidauthentication()
        {
            _scenarioContext["Authorization"] = System.Environment.GetEnvironmentVariable(
                "VALID_AUTHORIZATION"
            );
        }

        [Given(@"the user is authenticated")]
        public void Giventheuserisauthenticated()
        {
            _scenarioContext["Authorization"] = System.Environment.GetEnvironmentVariable(
                "AUTHORIZATION"
            );
        }
        [Given(@"the user is authenticated with ""(.*)"" and ""(.*)""")]
        public void Giventheuserisauthenticatedwithusernameandpassword(string username, string password)
        {
            _scenarioContext["username"] = username;
            _scenarioContext["password"] = password;
        }

        [Given(@"the user is not authenticated")]
        public void Giventheuserinotsauthenticated()
        {
            _scenarioContext["Authorization"] = "";
        }
    }
}
