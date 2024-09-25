namespace NextbooruLite.Auth.Services;

public class UserInit
{
    public required string Username { get; set; }
    public string? Email { get; set; }
    public required string Password { get; set; }
    public Role Role { get; set; } = Role.User;
}
