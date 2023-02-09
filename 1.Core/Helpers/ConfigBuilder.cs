using System;
using Microsoft.Extensions.Configuration;

namespace Todoly.Core.Helpers;

public class ConfigBuilder
{
    private static readonly ConfigBuilder _instance = new ConfigBuilder();
    private readonly IConfigurationBuilder builder;
    private IConfigurationRoot Config { get; }

    private ConfigBuilder()
    {
        DotNetEnv.Env.TraversePath().Load();
        builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
        Config = builder.Build();
    }

    public string GetString(string key)
    {
        string envVar = DotNetEnv.Env.GetString(key);

        return !string.IsNullOrEmpty(envVar) ? envVar : Config[key]!;
    }

    public int GetInt(string key)
    {
        int envVar = DotNetEnv.Env.GetInt(key);
        return envVar != 0 ? envVar : Convert.ToInt32(Config[key]);
    }

    public static ConfigBuilder Instance => _instance;
}
