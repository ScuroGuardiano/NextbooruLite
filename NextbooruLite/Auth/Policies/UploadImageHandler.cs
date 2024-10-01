using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using NextbooruLite.Configuration;

namespace NextbooruLite.Auth.Policies;

public class UploadImageHandler : AuthorizationHandler<UploadImageRequirement>
{
    private readonly NextbooruOptions _nextbooruOptions;

    public UploadImageHandler(IOptionsSnapshot<NextbooruOptions> options)
    {
        _nextbooruOptions = options.Value;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UploadImageRequirement requirement)
    {
        if (context.User.IsInRole(Role.Admin.ToString()) || context.User.IsInRole(Role.Uploader.ToString()))
        {
            context.Succeed(requirement);
        }

        if (_nextbooruOptions.AllowUserUpload && context.User.IsInRole(Role.User.ToString()))
        {
            context.Succeed(requirement);
        }
        
        return Task.CompletedTask;
    }
}