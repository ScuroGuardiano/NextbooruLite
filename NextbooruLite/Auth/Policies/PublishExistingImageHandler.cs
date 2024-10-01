using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using NextbooruLite.Configuration;
using NextbooruLite.Model;

namespace NextbooruLite.Auth.Policies;

public class PublishExistingImageHandler : AuthorizationHandler<PublishImageRequirement, Image>
{
    private readonly NextbooruOptions _options;

    public PublishExistingImageHandler(IOptionsSnapshot<NextbooruOptions> options)
    {
        _options = options.Value;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PublishImageRequirement requirement, Image? resource)
    {
        if (resource is null)
        {
            return Task.CompletedTask;
        }
        
        if (context.User.IsInRole(Role.Admin.ToString()))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
        
        var userId = context.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;

        if (userId is null)
        {
            return Task.CompletedTask;
        }
        
        var userIdGuid = Guid.Parse(userId);
        if (userIdGuid == resource.UploadedById)
        {
            if (context.User.IsInRole(Role.Uploader.ToString()))
            {
                context.Succeed(requirement);
            }
            else if (context.User.IsInRole(Role.User.ToString()) && _options.AllowUserPublish)
            {
                context.Succeed(requirement);
            }
        }
        
        return Task.CompletedTask;
    }
}