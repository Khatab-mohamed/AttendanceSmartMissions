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
       await _context.UserLocations.AddAsync(userLocation);
    }


    public async Task<IEnumerable<Location>> GetAsync()
    {
        var locations = await _context.Locations.ToListAsync();
        return locations;
    }


    public async Task<IEnumerable<Location>> GetUserLocations(Guid userId)
    {
        var locations = await  _context.UserLocations.
            Where(u => u.UserId == userId)
            .Select(l => l.Location)
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