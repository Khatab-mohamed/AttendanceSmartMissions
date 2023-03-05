namespace AMS.Application.Services.Location;

public interface ILocationService

{
    IEnumerable<LocationDto> GetLocations();
    /*LocationDto GetLocation(Guid locationId);
    bool LocationExists(Guid locationId);
    Task DeleteLocation(Guid locationId);
    LocationDto AddLocation(LocationForCreationDto location);
    
    bool Save();*/
}