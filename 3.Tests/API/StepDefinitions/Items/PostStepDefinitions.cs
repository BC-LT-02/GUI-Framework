// using RestSharp;
// using TechTalk.SpecFlow;
// using Todoly.Tests.API.Steps.Commons;
// using Todoly.Views.Models;

// namespace Todoly.Tests.API.Steps.Item
// {
//     [Binding]
//     [Scope(Feature = "Create a new item in a project")]
//     public class PostStepDefinitions : CommonSteps
//     {
//         private readonly ScenarioContext _scenarioContext;
//         private readonly string url = "items.json";

//         public PostStepDefinitions(ScenarioContext scenarioContext)
//             : base(scenarioContext)
//         {
//             _scenarioContext = scenarioContext;
//         }

//         [When(
//             @"the user makes a POST request to the API endpoint with a valid JSON or XML payload and ID project"
//         )]
//         public void WhentheusermakesaPOSTrequesttotheAPIendpointwithavalidJSONorXMLpayloadandIDproject()
//         {
//             ItemModel body = new ItemModel(
//                 null,
//                 content: "This is a new item",
//                 null,
//                 null,
//                 projectId: 4053023,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null,
//                 null
//             );
//             _scenarioContext["Response"] = Client.Post<ItemModel>(url, body);
//         }

//         [Then(
//             @"the API should return an (.*) status code and the new item should be added to the project"
//         )]
//         public void ThentheAPIshouldreturnanstatuscodeandthenewitemshouldbeaddedtotheproject(
//             string statusCode
//         )
//         {
//             RestResponse response = (RestResponse)_scenarioContext["Response"];
//             Assert.True(response.IsSuccessful);
//             Assert.Equal(statusCode, response.StatusCode.ToString());
//         }
//     }
// }
