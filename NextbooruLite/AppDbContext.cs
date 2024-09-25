using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using NextbooruLite.Auth.Model;
using NextbooruLite.Configuration;
using NextbooruLite.Model;

namespace NextbooruLite;

public sealed class AppDbContext : DbContext
{
   public DbSet<User> Users { get; set; } 
   public DbSet<Session> Sessions { get; set; }
   
   private readonly DatabaseOptions _databaseOptions;

   public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<DatabaseOptions> configuration) : base(options)
   {
      _databaseOptions = configuration.Value;
      ChangeTracker.StateChanged += OnEntityStateChanged;
   }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      base.OnConfiguring(optionsBuilder);

      optionsBuilder
         .UseNpgsql(GetDbConnectionString())
         .UseSnakeCaseNamingConvention();
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
      
      ConfigureBaseEntities(modelBuilder);
   }

   private void OnEntityStateChanged(object? sender, EntityStateChangedEventArgs e)
   {
      if (e is { NewState: EntityState.Modified, Entry.Entity: BaseEntity entity })
      {
         entity.UpdatedAt = DateTime.UtcNow;
      }
   }

   private void ConfigureBaseEntities(ModelBuilder modelBuilder)
   {
      var entitiesWithDate = modelBuilder.Model.GetEntityTypes()
         .Where(et => et.ClrType.IsSubclassOf(typeof(BaseEntity)));

      foreach (var entity in entitiesWithDate)
      {
         modelBuilder.Entity(entity.ClrType)
            .Property(nameof(BaseEntity.CreatedAt))
            .HasDefaultValueSql("now()");
          
         modelBuilder.Entity(entity.ClrType)
            .Property(nameof(BaseEntity.UpdatedAt))
            .HasDefaultValueSql("now()");
      }
   }

   private string GetDbConnectionString()
   {
      string connectionString = "";
      
      var host = _databaseOptions.Host;
      var port = _databaseOptions.Port ?? "5432";
      var username = _databaseOptions.Username;
      var password = _databaseOptions.Password;
      var database = _databaseOptions.Database;
      
      connectionString = $"Host={host};Port={port};Username={username}";

      if (password is not null)
      {
         connectionString += $";Password={password}";
      }

      if (database is not null)
      {
         connectionString += $";Database={database}";
      }
      
      return connectionString;
   }
}