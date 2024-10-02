namespace NextbooruLite.Auth.Policies;

public static class PolicyNames
{
    /// <summary>
    /// Publish policy decides if user is allowed to make the image public
    /// </summary>
    public const string PublishImage = nameof(PublishImage);
    
    /// <summary>
    /// Upload policy decides if user is allowed to upload an image
    /// </summary>
    public const string UploadImage = nameof(UploadImage);
    
    /// <summary>
    /// ViewAnyImage policy decides if user can view any image
    /// </summary>
    public const string ViewAnyImage = nameof(ViewAnyImage);
    
    /// <summary>
    /// ViewImage policy decides if user is allowed to read the image
    /// </summary>
    public const string ViewImage = nameof(ViewImage);
    
    /// <summary>
    /// Edit policy decides if user is allowed to edit the image
    /// </summary>
    public const string EditImage = nameof(EditImage);
    
    /// <summary>
    /// Delete policy decides if user is allowed to delete the image
    /// </summary>
    public const string DeleteImage = nameof(DeleteImage);
    
    public const string Admin = nameof(Admin);
}