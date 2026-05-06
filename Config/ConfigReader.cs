using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
public static class ConfigReader
{
    private static IConfiguration _configuration;

    static ConfigReader()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables() // <--- Add this!
            .Build();
    }

    public static string Browser => _configuration["browser"] ?? "chrome";
    
    // 1. Get the environment name (e.g., "staging")
    public static string Environment => _configuration["environment"] ?? "dev";

    // 2. Use the environment name to find the correct URL in the "urls" object
    public static string BaseUrl 
{
    get 
    {
        // Add the '?' to allow the string to be null temporarily during lookup
        string? url = _configuration[$"urls:{Environment}"];
        
        if (string.IsNullOrEmpty(url))
            throw new Exception($"URL for environment '{Environment}' not found in appsettings.json");
        
        return url;
    }
}

    public static bool Headless => bool.Parse(_configuration["headless"] ?? "false");
    public static bool Remote => bool.Parse(_configuration["remote"] ?? "false");
}