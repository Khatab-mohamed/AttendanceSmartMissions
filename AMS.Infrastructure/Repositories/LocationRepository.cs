using AMS.Domain.Helpers;
using AMS.Domain.Helpers.Locations;
using AMS.Infrastructure.Persistence;

namespace AMS.Infrastructure.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly ApplicationDbContext _context;
    public LocationRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public PagedList<Location> GetLocations(LocationsResourceParameters locationsResourceParameters)
    {
        var collectionBeforePaging =
            _context.Locations
                .OrderBy(l => l.Name)
                .AsQueryable();
        // paging
        if (string.IsNullOrEmpty(locationsResourceParameters.SearchQuery))
            return PagedList<Location>.Create(collectionBeforePaging,
                locationsResourceParameters.PageNumber,
                locationsResourceParameters.PageSize);
        
        // trim & ignore casing
        var searchQueryForWhereClause = locationsResourceParameters.SearchQuery
            .Trim().ToLowerInvariant();

        collectionBeforePaging = collectionBeforePaging
            .Where(a => a.Name.ToLowerInvariant().Contains(searchQueryForWhereClause));

        return PagedList<Location>.Create(collectionBeforePaging,
            locationsResourceParameters.PageNumber,
            locationsResourceParameters.PageSize);

    }

    public Location? GetLocation(Guid locationId)
    {
        return _context.Locations.FirstOrDefault(a => a.Id == locationId);
    }

    public async Task CreateLocation(Location location)
    {
        await _context.Locations.AddAsync(location);
        return;
    }

    public bool Save()
    {
        return (_context.SaveChanges() >= 0);
    }
}