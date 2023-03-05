namespace AMS.Infrastructure.Persistence;

public class ApplicationDbContext :
    IdentityDbContext<User, Role, Guid>
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    // Entities

  //  public DbSet<ApplicationUserToken> ApplicationUserToken { get; set; }
    public DbSet<Location> Locations  { get; set; }
    public DbSet<Incident> Incidents { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    
}

