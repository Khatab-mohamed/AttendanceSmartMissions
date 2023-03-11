namespace AMS.Application.Services.Location;

public interface ILocationService

{
    Task<IEnumerable<LocationDto>> GetLocations();
    Task<LocationDto> GetLocationAsync(Guid id);
    bool IsExists(Guid locationId);
    Task DeleteLocation(Guid locationId);
    Task<LocationDto> AddAsync(CreationLocationDto creationLocation);
    
    bool SaveAsync();
}