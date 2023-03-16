namespace AMS.Application.Services.Location;

public interface ILocationService

{
    Task<bool> IsExistsAsync(Guid locationId);
    Task<IEnumerable<LocationDto>> GetLocations();
    Task<LocationDto> GetAsync(Guid id);
    Task<bool> AddAsync(CreationLocationDto creationLocation);

    Task<bool> DeleteAsync(Guid id);
    Task<bool> UpdateLocationAsync(UpdateLocationDto? location);

    Task<IEnumerable<LocationDto>> GetUsersLocation(Guid userId);

    Task<bool> AddUserLocationAsync(UserLocationDto userLocationDto);



}