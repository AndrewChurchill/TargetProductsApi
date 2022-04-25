using TargetProductsApi.Common.Configuration;

namespace TargetProductsApi;

public static class ConfigurationResolver
{
    public static Configuration Resolve(IConfiguration config)
    {
        Configuration resolved = new();

        resolved.MongoConnection = GetSetting(config, "TARGET_PRODUCT_API_MONGO_CONNECTION", "DatabaseConnection:ConnectionString");
        resolved.RedSkyUrl = GetSetting(config, "TARGET_PRODUCT_API_RED_SKY_URL", "RedSkyConnection:Url");
        resolved.RedSkyKey = GetSetting(config, "TARGET_PRODUCT_API_RED_SKY_KEY", "RedSkyConnection:Key");

        return resolved;
    }

    private static string GetSetting(IConfiguration config, string environmentVar, string appsettingsEntry)
    {
        // Environment variables take precedence.
        string value = Environment.GetEnvironmentVariable(environmentVar);
        if (!string.IsNullOrEmpty(value))
        {
            return value;
        }

        // If we didn't find the desired environment variable, fall back to appsettings entries.
        value = config.GetValue<string>(appsettingsEntry);
        if (!string.IsNullOrEmpty(value))
        {
            return value;
        }

        throw new InvalidDataException(
            $"Could not find environment variable {environmentVar} or appsettings entry {appsettingsEntry}");
    }
}
