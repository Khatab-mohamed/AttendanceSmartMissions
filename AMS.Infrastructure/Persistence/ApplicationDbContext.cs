using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AMS.Infrastructure.Persistence;

public class ApplicationDbContext :
    IdentityDbContext<User, Role, Guid>
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    /*
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // any guid
        var ADMIN_ID = Guid.NewGuid();
        // any guid, but nothing is against to use the same one
        var ROLE_ID = Guid.NewGuid();
        builder.Entity<Role>().HasData(new Role
        {
            Id = ROLE_ID,
            Name = "admin",
            NormalizedName = "admin"
        });

        var hasher = new PasswordHasher<User>();
        builder.Entity<User>().HasData(new User
        {
            Id = ADMIN_ID,
            UserName = "admin",
            NormalizedUserName = "admin",
            Email = "some-admin-email@nonce.fake",
            NormalizedEmail = "some-admin-email@nonce.fake",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "SOME_ADMIN_PLAIN_PASSWORD"),
            SecurityStamp = string.Empty
        });

        builder.Entity<UserRole>().HasData(new UserRole
        {
            RoleId = ROLE_ID,
            UserId = ADMIN_ID
        });
    }
    */

    // Entities
    public DbSet<ApplicationUserToken> ApplicationUserToken { get; set; }
    public DbSet<Location> Locations  { get; set; }
    public DbSet<Incident> Incidents { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    
}

