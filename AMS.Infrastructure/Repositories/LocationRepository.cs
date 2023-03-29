using System.Linq;

namespace AMS.Infrastructure.Repositories;

public class LocationRepository : ILocationRepository
{
    #region Constructor
    private readonly ApplicationDbContext _context;
    public LocationRepository(ApplicationDbContext context) => _context = context;

    #endregion
   
    
    public async Task<bool> IsExistAsync(Guid id)
    {
        return await _context.Locations.AnyAsync(a => a.Id == id);
    }

    public async Task AddUserLocationAsync(UserLocation userLocation)
    {
        var user = await _context.Users.FindAsync(userLocation.UserId);
        var location = await _context.Locations.FindAsync(userLocation.LocationId);
        var userLocationToAdd = new UserLocation
        {
            Location = location,
            User = user,
            LocationId = userLocation.LocationId,
            UserId = userLocation.UserId

        };
        if (location != null && user is not null)
            _context.LocationUser.Add(userLocationToAdd);
    }

    public async  Task RemoveUserLocationAsync(UserLocation userLocation)
    {
        var user = await _context.Users.FindAsync(userLocation.UserId);
        var location = await _context.Locations.FindAsync(userLocation.LocationId);
       if (location != null) _context.LocationUser.Remove(userLocation);
    }


    public async Task<IEnumerable<Location>> GetAsync()
    {
        var locations = await _context.Locations.ToListAsync();
        return locations;
    }


    public async Task<List<Location>> GetUserLocations(Guid userId)
    {

        var locations = await _context.LocationUser
            .Where(ul => ul.UserId == userId)
            .Select(ul => ul.Location)
            .ToListAsync();
        return locations;
    }


    public async Task<Location?> GetAsync(Guid locationId)
    {
        var entity =  await _context.Locations.FindAsync( locationId);
        return entity;

    }

    public void  Add(Location location)
    {
         _context.Locations.Add(location);
    }

    public void Update(Location location)
    {
        _context.Locations.Attach(location);

    }

    public void Delete(Guid locationId)
    {
        var location = _context.Locations.FirstOrDefault(l=>l.Id == locationId);

        if (location != null) _context.Locations.Remove(location);
    }

    public async Task<bool> SaveAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }

    
}