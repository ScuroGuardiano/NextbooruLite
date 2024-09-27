using System.Diagnostics.CodeAnalysis;
using NextbooruLite.Auth;
using NextbooruLite.Auth.Model;

namespace NextbooruLite.Dto.Responses;

//
// Summary:
//  Basic user info Dto, safe to show to everyone
public class BasicUserInfo
{
    public BasicUserInfo()
    {
    }

    [SetsRequiredMembers]
    public BasicUserInfo(User user)
    {
        (Username, DisplayName, IsAdmin) = (user.Username, user.DisplayName, user.Role == Role.Admin);
    }

    public required string Username { get; init; }
    public required string DisplayName { get; init; }

    public required bool IsAdmin { get; init; }
}
