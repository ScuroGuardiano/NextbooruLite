using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextbooruLite.Model;

namespace NextbooruLite.Auth.Model;

[EntityTypeConfiguration(typeof(UserConfiguration))]
public class User : BaseEntity
{
    public Guid Id { get; set; }

    /// <summary>
    /// Username is always in lowercase.
    /// </summary>
    [Required]
    public required string Username { get; set; }

    /// <summary>
    /// DisplayName is not lowercased username.
    /// </summary>
    [Required]
    public required string DisplayName { get; set; }

    // I can't mark password with `required` keyword because JSON will throw an exception on me
    [Required]
    [JsonIgnore]
    public string HashedPassword { get; set; } = null!;

    public bool Disabled { get; set; } = false;

    public string? Email { get; set; }
    
    public Role Role { get; set; } = Role.User;
    
    public bool IsInitial { get; set; } = false;
}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(u => u.Username).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();
    }
}