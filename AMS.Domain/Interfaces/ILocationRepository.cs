namespace AMS.Domain.Interfaces
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<Location?> GetAsync(Guid locationId);
        Task CreateLocation(Location locationId);
        void UpdateLocation(Location location);
        void DeleteLocation(Guid locationId);
        bool SaveAsync();
        bool IsExist(Guid id);
    }
}
