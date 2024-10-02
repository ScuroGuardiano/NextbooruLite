using System.Security.Claims;

namespace NextbooruLite.Helpers;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        var claim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        return claim is null ? Guid.Empty : Guid.Parse(claim.Value);
    }

    public static Guid GetRequiredUserId(this ClaimsPrincipal principal)
    {
        var claim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (claim is null)
        {
            throw new NullReferenceException("NameIdentifier claim does not exists on user.");
        }
        
        return Guid.Parse(claim.Value);
    }
}