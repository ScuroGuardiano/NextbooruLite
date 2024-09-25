using System.ComponentModel;

namespace NextbooruLite.Auth;

public enum Role
{
    [Description("User can view public images and upload with verification required")]
    User,
    
    [Description("Uploader can upload without verification")]
    Uploader,
    
    [Description("Admin user can do anything")]
    Admin,
    
    [Description("Anonymous user can view public images.")]
    Anonymous,
}