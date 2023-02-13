// using System.Text.Json;
// using RestSharp;
// using TechTalk.SpecFlow;
// using Todoly.Tests.API.Steps.Commons;
// using Todoly.Views.Models;

// namespace Todoly.Tests.API.Steps.Project
// {
//     [Binding]
//     [Scope(Feature = "Project Creation")]
//     public class PostStepDefinitions : CommonSteps
//     {
//         private readonly ScenarioContext _scenarioContext;
//         private readonly string url = "projects.json";

//         public PostStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
//         {
//             _scenarioContext = scenarioContext;
//         }

//         [When(@"the user sends a POST request to the API endpoint with a valid JSON or XML payload")]
//         public void WhentheusersendsaPOSTrequesttotheAPIendpointwithavalidJSONorXMLpayload()
//         {
//             ProjectModel body = new ProjectModel("My New Project");
//             _scenarioContext["Response"] = Client.Post<ProjectModel>(url, body);
//         }

//         [Then(@"the response should have a status code of ""(.*)"" and the new project should be added to the database and the response should contain the details of the newly created project")]
//         public void Thentheresponseshouldhaveastatuscodeofandthenewprojectshouldbeaddedtothedatabaseandtheresponseshouldcontainthedetailsofthenewlycreatedproject(string statusCode)
//         {
//             RestResponse response = (RestResponse)_scenarioContext["Response"];
//             Assert.True(response.IsSuccessful);
//             Assert.Equal(statusCode, response.StatusCode.ToString());
//             var project = JsonSerializer.Deserialize<ProjectModel>(response.Content!);
//             Assert.IsType<ProjectModel>(project);
//         }

//         [When(@"the user sends a POST request to the API endpoint with a JSON or XML payload that is missing required fields")]
//         public void WhentheusersendsaPOSTrequesttotheAPIendpointwithaJSONorXMLpayloadthatismissingrequiredfields()
//         {
//             ProjectModel body = new ProjectModel(
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
//             _scenarioContext["Response"] = Client.Post<ProjectModel>(url, body);
//         }

//         [Then(@"the response should have a status code of ""(.*)"" and a error message indicating missing fields")]
//         public void Thentheresponseshouldhaveastatuscodeofandaerrormessageindicatingmissingfields(string statusCode)
//         {
//             RestResponse response = (RestResponse)_scenarioContext["Response"];

//             Assert.True(response.IsSuccessful);
//             Assert.Equal(statusCode, response.StatusCode.ToString());
//             var res = JsonSerializer.Deserialize<ErrorModel>(response.Content!);
//             Assert.IsType<ErrorModel>(res);
//         }
//     }
// }
