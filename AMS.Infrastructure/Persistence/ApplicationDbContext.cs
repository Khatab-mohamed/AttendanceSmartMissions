namespace AMS.Infrastructure.Persistence;

public sealed class ApplicationDbContext :
    IdentityDbContext<User,
        Role,
        Guid
        , IdentityUserClaim<Guid>
        , UserRole
        , IdentityUserLogin<Guid>
        , IdentityRoleClaim<Guid>
        , IdentityUserToken<Guid>>
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
    public DbSet<Location> Locations  { get; set; }
    public DbSet<Incident> Incidents { get; set; }
    public DbSet<IncidentType> IncidentTypes { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<UserLocation> LocationUser { get; set; }


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
                EmailConfirmed = true,
                IDNumber = "123",
                PhoneNumber = " +966581252650",
                PasswordHash = hasher.HashPassword(new User(), "AdminPassword"),
                NormalizedEmail = "admin@smartmissions.com".ToUpper(),
                NormalizedUserName = "Khatab Mohamed".ToUpper(),
                PhoneNumberConfirmed = true,
                SecurityStamp = id.ToString(),
                
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
               Name = "User",
               NormalizedName = "USER"
           }
           );

        modelBuilder.Entity<UserRole>().HasData(
           new UserRole
           {
               RoleId = roleId,
               UserId = id,

           });

      //  modelBuilder.Entity<UserRole>().HasKey(src=> new{src.RoleId,src.UserId });
        modelBuilder.Entity<UserLocation>().HasKey(sc => new { sc.LocationId, sc.UserId });
        base.OnModelCreating(modelBuilder);
       
    }
    


}

