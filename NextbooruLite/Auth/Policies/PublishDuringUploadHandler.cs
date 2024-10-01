using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using NextbooruLite.Configuration;
using NextbooruLite.Dto.Requests;

namespace NextbooruLite.Auth.Policies;

/// <summary>
/// Initially I wanted this handler to be invoked with null Image resource but I realised it's not a good idea
/// Instead I am using here UploadFileFormData object which is available only during upload.
/// </summary>
public class PublishDuringUploadHandler : AuthorizationHandler<PublishImageRequirement, UploadFileFormData>
{
    private readonly NextbooruOptions _options;

    public PublishDuringUploadHandler(IOptionsSnapshot<NextbooruOptions> options)
    {
        _options = options.Value;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PublishImageRequirement requirement,
        UploadFileFormData? resource)
    {
        if (resource is null)
        {
            return Task.CompletedTask;
        }
        
        if (context.User.IsInRole(Role.Admin.ToString()) || context.User.IsInRole(Role.Uploader.ToString()))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        if (context.User.IsInRole(Role.User.ToString()) && _options.AllowUserPublish)
        {
            context.Succeed(requirement);
        }
        
        return Task.CompletedTask;
    }
}