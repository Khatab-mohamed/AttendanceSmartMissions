namespace AMS.Infrastructure.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly ApplicationDbContext _context;
    public LocationRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Location>> GetLocations()
    {
        var locations = await _context.Locations.ToListAsync();
        return locations;
    }

    public Location? GetLocation(Guid locationId)
    {
        return _context.Locations.FirstOrDefault(a => a.Id == locationId);
    }

    public async Task CreateLocation(Location location)
    {
        await _context.Locations.AddAsync(location);
    }

    public void DeleteLocation(Guid locationId)
    {
        var location = _context.Locations.FirstOrDefault(l=>l.Id == locationId);

        _context.Locations.Remove(location);
    }

    public bool SaveAsync()
    {
        return (_context.SaveChanges() >= 0);
    }

    public bool IsExist(Guid id)
    {
       return _context.Locations.Any(a => a.Id == id);
    }
}