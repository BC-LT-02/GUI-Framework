using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using Allure.Commons;
using OpenQA.Selenium;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Views.WebAppPages;
using Todoly.Views.Models;

namespace SeleniumTest.Tests.Hooks;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;
    private readonly RestHelper _client;
    private readonly string _urlProject;
    private readonly string _projectName;
    private readonly string _userFullName;
    private readonly string _userTimeZone;
    private readonly string _urlUserPutUri;
    private readonly string _urlItem;
    private ProjectModel? _projectModel;
    private ItemModel? _itemModel;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _client = new RestHelper(ConfigModel.ApiHostUrl);
        _urlProject = ConfigModel.ProjectUri;
        _projectName = IdHelper.GetNewId();
        _urlUserPutUri = ConfigModel.UserPutUri;
        _userFullName = ConfigModel.UserFullName;
        _userTimeZone = ConfigModel.UserTimeZone;
        _urlItem = ConfigModel.ItemUri;
    }

    [BeforeTestRun]
    public static void BeforeTest()
    {
        string logsDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Logs");

        if (Directory.Exists(logsDirectory))
        {
            foreach (string filePath in Directory.GetFiles(logsDirectory))
            {
                string fileName = Path.GetFileName(filePath);
                if (Regex.IsMatch(fileName, @"Latest.*\.txt"))
                {
                    File.Delete(filePath);
                }
            }
        }

        AllureLifecycle.Instance.CleanupResultDirectory();
    }

    [BeforeFeature]
    public static void BeforeFeature(FeatureContext context)
    {
        ConfigLogger.Information($"Initializing {context.FeatureInfo.Title} feature");
    }

    [AfterFeature]
    public static void AfterFeature(FeatureContext context)
    {
        ConfigLogger.Information($"Ending {context.FeatureInfo.Title} feature");
        ConfigLogger.Information("Disposing driver.");
        ConfigLogger.Instance = null!;
    }

    [BeforeScenario]
    public static void BeforeScenario(ScenarioContext context)
    {
        ConfigLogger.Information($"Initializing {context.ScenarioInfo.Title} scenario");
    }

    [AfterStep]
    public static void AfterStep(ScenarioContext context)
    {
        if (context.TestError != null)
        {
            byte[] content = GetScreenshot();
            AllureLifecycle.Instance.AddAttachment(
                "Failed test screenshot",
                "application/png",
                content
            );
        }
    }

    private static byte[] GetScreenshot()
    {
        return ((ITakesScreenshot)GenericWebDriver.Instance).GetScreenshot().AsByteArray;
    }

    [AfterTestRun]
    public static void CleanUp()
    {
        APIScripts.RemoveAllProjects();
    }

    [AfterScenario("delete.projects")]
    public static void RemoveProjects()
    {
        APIScripts.RemoveAllProjects();
    }

    [AfterScenario("collapse.item.options")]
    public static void CollapseItemOptions()
    {
        UIElementFactory.GetElement("Less Option", "Items Component").Click();
    }

    [BeforeScenario(Order = 1)]
    public void CreateProject()
    {
        var scenarioTags = _scenarioContext.ScenarioInfo.Tags.ToList();

        scenarioTags = scenarioTags
            .Where(tag => tag.StartsWith("create.project."))
            .Select(tag => tag.Replace("create.project.", ""))
            .ToList();

        if (scenarioTags.Count.Equals(0))
        {
            return;
        }

        foreach (string tag in scenarioTags)
        {
            string payload = $"{{ \"Content\": \"{tag}\" }}";

            _client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, ConfigModel.TODO_LY_PASS);

            RestResponse response = _client.DoRequest(Method.Post, _urlProject, payload);
            _projectModel = JsonSerializer.Deserialize<ProjectModel>(response.Content!);

            _scenarioContext[tag] = tag;
            _scenarioContext[tag + "Model"] = _projectModel;
        }
    }

    [AfterScenario("restore.default.fullname")]
    public void UpdateFullName()
    {
        string payload = $"{{ \"FullName\": \"{_userFullName}\" }}";

        _client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, ConfigModel.TODO_LY_PASS);
        _client.DoRequest(Method.Put, _urlUserPutUri, payload);
    }

    [AfterScenario("restore.default.timezone")]
    public void UpdateTimeZone()
    {
        string payload = $"{{ \"TimeZoneId\": \"{_userTimeZone}\" }}";

        _client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, ConfigModel.TODO_LY_PASS);
        _client.DoRequest(Method.Put, _urlUserPutUri, payload);
    }

    [AfterScenario]
    public void CaptureScreenshot()
    {
        string title = Regex.Replace(_scenarioContext.ScenarioInfo.Title, "(?i)successfully", "");

        if (_scenarioContext.TestError != null)
        {
            if (ConfigBuilder.Instance.GetString("ui", "DriverLocation") == "BrowserStack")
            {
                ((IJavaScriptExecutor)GenericWebDriver.Instance).ExecuteScript(
                    "browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" "
                        + title
                        + " failed\"}}"
                );
            }

            Screenshot image = ((ITakesScreenshot)GenericWebDriver.Instance).GetScreenshot();
            string path = $"../../../Assets/{_scenarioContext.ScenarioInfo.Title}";
            path = string.Join(
                    " ",
                    path.Split().Select(word => char.ToUpper(word[0]) + word.Substring(1))
                )
                .Replace(" ", "");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = new string(
                DateTime.Now
                    .ToString()
                    .Where(c => !char.IsWhiteSpace(c) && c != '/' && c != ':')
                    .ToArray()
            );

            image.SaveAsFile($"{path}/{fileName}.png", ScreenshotImageFormat.Png);
        }
        else
        {
            if (ConfigBuilder.Instance.GetString("ui", "DriverLocation") == "BrowserStack")
            {
                ((IJavaScriptExecutor)GenericWebDriver.Instance).ExecuteScript(
                "browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" "
                    + title
                    + " successfully\"}}"
            );
            }
        }

        GenericWebDriver.Dispose();
    }

    [AfterScenario("recover.password")]
    public void RecoverPassword()
    {
        string payload = $"{{ \"Password\": \"{ConfigModel.TODO_LY_PASS}\" }}";
        string password = _scenarioContext.Get<string>("Password");
        _client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, password);
        _client.DoRequest(Method.Put, _urlUserPutUri, payload);
    }

    [AfterScenario("recover.email")]
    public void RecoverEmail()
    {
        string payload = $"{{ \"Email\": \"{ConfigModel.TODO_LY_EMAIL}\" }}";
        string email = _scenarioContext.Get<string>("Email");
        _client.AddAuthenticator(email, ConfigModel.TODO_LY_PASS);
        _client.DoRequest(Method.Put, _urlUserPutUri, payload);
    }

    [BeforeScenario(Order = 2)]
    public void CreateItems()
    {
        var itemNameTags = _scenarioContext.ScenarioInfo.Tags.ToList();

        itemNameTags = itemNameTags
            .Where(tag => tag.StartsWith("create.item."))
            .Select(tag => tag.Replace("create.item.", ""))
            .ToList();

        if (itemNameTags.Count is 0)
        {
            return;
        }

        foreach (string itemName in itemNameTags)
        {
            bool isChecked = itemName.Contains("checked.");

            string payload = isChecked
                ? $"{{ \"Content\": \"{itemName.Replace("checked.", "")}\", \"ProjectId\": {_projectModel!.Id}, \"Checked\": \"true\" }}"
                : $"{{ \"Content\": \"{itemName}\", \"ProjectId\": {_projectModel!.Id} }}";

            _client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, ConfigModel.TODO_LY_PASS);

            RestResponse response = _client.DoRequest(Method.Post, _urlItem, payload);
            _itemModel = JsonSerializer.Deserialize<ItemModel>(response.Content!);

            _scenarioContext[itemName] = itemName;
            _scenarioContext[itemName + "Model"] = _itemModel;
        }
    }

    [AfterScenario]
    public void SessionDisposal(ScenarioContext context)
    {
        ConfigLogger.Information($"Ending {context.ScenarioInfo.Title} scenario");

        GenericWebDriver.Dispose();
    }
}
