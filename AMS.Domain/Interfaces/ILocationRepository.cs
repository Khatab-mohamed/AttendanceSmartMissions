namespace AMS.Domain.Interfaces
{
    public interface ILocationRepository
    {
        PagedList<Location> GetLocations(LocationsResourceParameters locationsResourceParameters);
        Location? GetLocation(Guid locationId);
        Task CreateLocation(Location locationId);
        bool Save();
    }
}
