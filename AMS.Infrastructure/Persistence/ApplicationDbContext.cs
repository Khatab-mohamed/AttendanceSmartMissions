namespace AMS.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<User>
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    // Entities
  
    public DbSet<User> Users { get; set; }
    public DbSet<Location> Locations  { get; set; }

   public DbSet<Incident> Incidents { get; set; }   
   public DbSet<Attendance> Attendances { get; set; }   

}

