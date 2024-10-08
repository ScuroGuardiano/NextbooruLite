using System.ComponentModel.DataAnnotations;

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

    public string MediaStoragePath { get; set; } = "./media";

    public List<string> AllowedUploadExtensions { get; set; } = [];
    
    public bool AllowConversion { get; set; } = true;
    public List<string> AllowedConversionFormats { get; set; } = [];
    
    [Range(1, int.MaxValue)]
    public int DefaultResultsPerPage { get; set; } = 20;
    [Range(1, int.MaxValue)]
    public int MaxResultsPerPage { get; set; } = 100;

    public int ThumbnailWidth { get; set; } = 300;
    public int ThumbnailQuality { get; set; } = 65;
    public string ThumbnailFormat { get; set; } = "webp";

    public int PreviewWidth { get; set; } = 1024;
    public int PreviewQuality { get; set; } = 70;
    public string PreviewFormat { get; set; } = "webp";
}
