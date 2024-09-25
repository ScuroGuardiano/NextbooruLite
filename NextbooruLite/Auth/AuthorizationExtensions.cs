using Microsoft.AspNetCore.Authorization;
using NextbooruLite.Auth.Policies;

namespace NextbooruLite.Auth;

public static class AuthorizationExtensions
{
    public static void AddNextbooruAuthorization(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationHandler, UploadImageHandler>();
        
        services.AddAuthorizationBuilder()
            .AddPolicy(PolicyNames.Admin, policy => policy.RequireRole(Role.Admin.ToString()))
            .AddPolicy(PolicyNames.UploadImage, policy => policy.Requirements.Add(new UploadImageRequirement()))
            .SetFallbackPolicy(new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build());
    }
}