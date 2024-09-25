namespace NextbooruLite.Configuration;

public class NextbooruOptions
{
    public const string Key = "Nextbooru";
    /// <summary>
    /// Allows users with role "User" to upload an image
    /// </summary>
    public bool AllowUserUpload { get; set; } = true;
    
    /// <summary>
    /// Allows users with role "User" to publish an image that is owned by them
    /// </summary>
    public bool AllowUserPublish { get; set; } = false;
}