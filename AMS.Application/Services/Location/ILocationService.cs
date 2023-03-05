namespace AMS.Application.Services.Location;

public interface ILocationService

{
    Task<IEnumerable<LocationDto>> GetLocations();
    /*LocationDto GetLocation(Guid locationId);
    bool LocationExists(Guid locationId);*/
    Task DeleteLocation(Guid locationId);
    Task<LocationDto> AddAsync(LocationForCreationDto location);
    
    bool SaveAsync();
}