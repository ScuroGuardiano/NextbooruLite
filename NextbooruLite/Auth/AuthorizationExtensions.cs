using Microsoft.AspNetCore.Authorization;
using NextbooruLite.Auth.Policies;

namespace NextbooruLite.Auth;

public static class AuthorizationExtensions
{
    public static void AddNextbooruAuthorization(this IServiceCollection services)
    {
        services.AddScoped<IAuthorizationHandler, UploadImageHandler>();
        services.AddScoped<IAuthorizationHandler, PublishDuringUploadHandler>();
        services.AddScoped<IAuthorizationHandler, PublishExistingImageHandler>();
        
        services.AddAuthorizationBuilder()
            .AddPolicy(PolicyNames.Admin, policy => policy.RequireRole(Role.Admin.ToString()))
            .AddPolicy(PolicyNames.UploadImage, policy => policy.Requirements.Add(new UploadImageRequirement()))
            .AddPolicy(PolicyNames.PublishImage, policy => policy.Requirements.Add(new PublishImageRequirement()))
            .SetFallbackPolicy(new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build());
    }
}