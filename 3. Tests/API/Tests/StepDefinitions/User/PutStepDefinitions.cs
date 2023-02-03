﻿using System.Text.Json;
using Features.GeneralSteps;
using Models;
using RestSharp;
using TechTalk.SpecFlow;

namespace Features.User.Put
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
        public void WhentheusersubmitsaPUTrequesttowithavalidJSONbody(string url, string body)
        {
            Client.AddDefaultHeader("Authorization", _scenarioContext["Authorization"].ToString()!);
            Client.AddDefaultHeader("Accept", "*/*");

            UserPayloadModel? user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserPayloadModel>(body);
            _scenarioContext["Response"] = Client.Put<UserPayloadModel>(url, user);
        }

        [Then(@"the API should return a ""(.*)"" status code and the updated user information in JSON format")]
        public void ThentheAPIshouldreturnastatuscodeandtheupdateduserinformationinJSONformat(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var user = JsonSerializer.Deserialize<UserPayloadModel>(response.Content!);
            Assert.IsType<UserPayloadModel>(user);
            Assert.Equal("New Name", user.FullName);
        }

        [When(@"the user submits a PUT request to ""(.*)"" with an invalid ""(.*)"" user email")]
        public void WhentheusersubmitsaPUTrequesttowithaninvaliduseremail(string url, string email)
        {
            Client.AddDefaultHeader("Authorization", "Basic aW52YWxpZEBlbWFpbC5jb206UGFzc3dvcmQ=");
            Client.AddDefaultHeader("Accept", "*/*");

            UserPayloadModel body = new UserPayloadModel(
                email,
                "newPassword",
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
            _scenarioContext["Response"] = Client.Put<UserPayloadModel>(url, body);
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

        [When(@"the user submits a PUT request to ""(.*)""")]
        public void WhentheusersubmitsaPUTrequestto(string url)
        {
            _scenarioContext["Response"] = Client.Put<UserPayloadModel>(url, body: null!);
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
