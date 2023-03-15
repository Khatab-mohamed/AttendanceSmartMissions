namespace AMS.Domain.Interfaces
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAsync();
        Task<Location?> GetAsync(Guid locationId);
        void Add(Location location);
        void Update(Location location);
        void Delete(Guid locationId);
        Task<bool> SaveAsync();
        Task<bool> IsExistAsync(Guid id);
    }
}
