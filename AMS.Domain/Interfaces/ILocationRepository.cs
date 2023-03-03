namespace AMS.Domain.Interfaces
{
    public interface ILocationRepository
    {
        PagedList<Location> GetLocations(LocationsResourceParameters locationsResourceParameters);
        Location? GetLocation(Guid locationId);
        Task CreateLocation(Location locationId);
        void DeleteLocation(Guid locationId);
        bool Save();
        bool IsExist(Guid id);
    }
}
