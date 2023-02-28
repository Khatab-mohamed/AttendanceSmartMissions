namespace AMS.Infrastructure.Repositories;

public class LocationRepository : ILocationRepository
{
    public IEnumerable<Location> GetLocations()
    {
        throw new NotImplementedException();
    }

    public Location GetLocations(Guid locationId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Location> Locations(IEnumerable<Guid> locationsIds)
    {
        throw new NotImplementedException();
    }

    public Task AddLocation(Location locationDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteLocation(Location locationDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateLocation(Location locationDto)
    {
        throw new NotImplementedException();
    }

    public bool LocationExists(Guid locationId)
    {
        throw new NotImplementedException();
    }

    public bool Save()
    {
        throw new NotImplementedException();
    }
}