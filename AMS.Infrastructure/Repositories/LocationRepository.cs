namespace AMS.Infrastructure.Repositories;

public class LocationRepository : ILocationRepository
{
    #region Constructor
    private readonly ApplicationDbContext _context;
    public LocationRepository(ApplicationDbContext context) => _context = context;

    #endregion

    public async Task<IEnumerable<Location>> GetLocations()
    {
        var locations = await _context.Locations.ToListAsync();
        return locations;
    }

    public async Task<Location?> GetAsync(Guid locationId)
    {
        var entity =  await _context.Locations.FindAsync( locationId);
        return entity;

    }

    public async Task CreateLocation(Location location)
    {
        await _context.Locations.AddAsync(location);
    }

    public void UpdateLocation(Location location)
    {
        _context.Attach(location);
        _context.Entry(location).State = EntityState.Modified;
    }

    public void DeleteLocation(Guid locationId)
    {
        var location = _context.Locations.FirstOrDefault(l=>l.Id == locationId);

        if (location != null) _context.Locations.Remove(location);
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