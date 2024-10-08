using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NextbooruLite.Auth.Model;

public class Session
{
    public Guid Id { get; set; }
    
    public User? User { get; set; }
    public Guid UserId { get; set; }
    public bool IsValid { get; set; }
    
    /// <summary>
    /// IP Address at session creation.
    /// </summary>
    public string? LoggedInIpAddress { get; set; }
    
    /// <summary>
    /// Last IP Address from which session was accessed.
    /// </summary>
    public string? LastIp { get; set; }
    
    /// <summary>
    /// User Agent at session creation
    /// </summary>
    public string? UserAgent { get; set; }
    
    /// <summary>
    /// Last User Agent from which session was accessed.
    /// </summary>
    public string? LastUserAgent { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime LastAccess { get; set; }
}

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder
            .HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(s => s.UserId)
            .IsRequired();
    }    
}