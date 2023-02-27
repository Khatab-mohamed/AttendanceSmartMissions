using AMS.Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace AMS.Infrastructure.Contexts;

public class ApplicationContext : DbContext
{

    public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions)
        : base(dbContextOptions)
    {
        try
        {
            // use this creator if DB doesn't exist || DB has not tables .
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            databaseCreator?.Create();
            if (databaseCreator != null && !databaseCreator.HasTables()) databaseCreator.CreateTables();

        }
        catch (Exception ex)
        {

            Console.WriteLine(ex);
        }
    }
    // Entities

    public DbSet<User> Users { get; set; }   
    public DbSet<Location> Locations  { get; set; }   
    public DbSet<Incident> Incidents { get; set; }   

}

