namespace NextbooruLite.Configuration;

public static class AppSettings
{
    public static string EnvPrefix => "NBL_";

    public static Dictionary<string, string> EnvMappings { get; } = new () {
        { "DB_HOST", $"{EnvPrefix}DATABASE__HOST" },
        { "DB_PORT", $"{EnvPrefix}DATABASE__PORT" },
        { "DB_USERNAME", $"{EnvPrefix}DATABASE__USERNAME" },
        { "DB_PASSWORD", $"{EnvPrefix}DATABASE__PASSWORD" },
        { "DB_DATABASE", $"{EnvPrefix}DATABASE__DATABASE" },
        { "MEDIA_STORAGE_PATH", $"{EnvPrefix}{NextbooruOptions.Key.ToUpperInvariant()}__MEDIA_STORAGE_PATH" },
    };
}
