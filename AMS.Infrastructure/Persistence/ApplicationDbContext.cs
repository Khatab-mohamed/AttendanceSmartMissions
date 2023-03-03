namespace AMS.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    // Entities
  
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<ApplicationRole> Roles { get; set; }
    public DbSet<Location> Locations  { get; set; }

   public DbSet<Incident> Incidents { get; set; }   
   public DbSet<Attendance> Attendances { get; set; }   

}

