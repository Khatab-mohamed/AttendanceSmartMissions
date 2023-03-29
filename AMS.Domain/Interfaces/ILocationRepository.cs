﻿using AMS.Domain.Entities.Locations;

namespace AMS.Domain.Interfaces
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAsync();
        Task<List<Location>> GetUserLocations(Guid userId);
        Task<Location?> GetAsync(Guid locationId);
        void Add(Location location);
        void Update(Location location);
        void Delete(Guid locationId);
        Task<bool> SaveAsync();
        Task<bool> IsExistAsync(Guid id);
        Task AddUserLocationAsync(UserLocation userLocation);
        Task RemoveUserLocationAsync(UserLocation userLocation);
    }
}
