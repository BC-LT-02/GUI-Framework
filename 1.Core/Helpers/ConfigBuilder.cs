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
        string res = DotNetEnv.Env.GetString(key);

        return res != null ? res :
            throw new Exception("Key not found");
    }

    public string GetString(string framework, string key)
    {
        string res = Config.GetSection(framework)[key]!;

        return res != null ? res :
            throw new Exception("Framework or Key not found");
    }

    public int GetInt(string key)
    {
        return Convert.ToInt32(DotNetEnv.Env.GetInt(key));
    }

    public int GetInt(string framework, string key)
    {
        return Convert.ToInt32(Config.GetSection(framework)[key]);
    }

    public static ConfigBuilder Instance => _instance;
}
