using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AMS.Infrastructure.Persistence;

public sealed class ApplicationDbContext :
    IdentityDbContext<User, Role, Guid>
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
        var x = Database.CanConnect();
        if (!x)
        {
            Database.Migrate();
        }


    }


    // Entities
    public DbSet<ApplicationUserToken> ApplicationUserToken { get; set; }
    public DbSet<Location> Locations  { get; set; }
    public DbSet<Incident> Incidents { get; set; }
    public DbSet<Attendance> Attendances { get; set; }

    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var hasher = new PasswordHasher<User>();
        var id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35");
        var roleId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450");

        modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = id,
                FullName = "Khatab Mohamed",
                UserName = "Khatab Mohamed",
                Email = "admin@smartmissions.com",
                DeviceSerialNumber = "123",
                IsActive = true,
                IDNumber = "123",
                PhoneNumber = " +966581252650",
                PasswordHash = hasher.HashPassword(null, "AdminPassword"),
            }
        );

        modelBuilder.Entity<Role>().HasData(
           new Role
           {
               Id = roleId,
               Name = "Super Admin",
               NormalizedName = "SUPER ADMIN"
           },
           new Role
           {
               Id = Guid.NewGuid(),
               Name = "Admin",
               NormalizedName = "ADMIN"
           }
           );

        /*modelBuilder.Entity<UserRole>().HasData(
           new UserRole
           {
               RoleId = roleId,
               UserId = id,

           }
           );#1#

        /*modelBuilder.Entity<UserRole>().HasData(
            new UserRole
            {
                UserId = id,
                RoleId = roleId
            });

        modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(p => new UserRole() { });
        #1#


        base.OnModelCreating(modelBuilder);
    }
    */


}

