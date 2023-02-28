using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace AMS.Infrastructure.Contexts;

public class ApplicationDbContext : IdentityDbContext<User>
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
        // try
        // {
        //     // use this creator if DB doesn't exist || DB has not tables .
        //     var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        //     databaseCreator?.Create();
        //     if (databaseCreator != null && !databaseCreator.HasTables()) databaseCreator.CreateTables();
        //
        // }
        // catch (Exception ex)
        // {
        //
        //     Console.WriteLine(ex);
        // }
    }
    // Entities
    public DbSet<Location> Locations  { get; set; }

   // public DbSet<Incident> Incidents { get; set; }   

}

