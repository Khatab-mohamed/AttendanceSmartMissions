using AMS.Application.DTOs.Location;
using AMS.Domain.Helpers;
using AMS.Domain.Helpers.Locations;

namespace AMS.Application.Services.Location;

public interface ILocationService

{
    PagedList<Domain.Entities.Location> GetLocations(LocationsResourceParameters locationsResourceParameters);
    LocationDto GetLocation(Guid locationId);
    bool LocationExists(Guid locationId);
    Task DeleteLocation(Guid locationId);
    LocationDto AddLocation(LocationForCreationDto location);
    
    bool Save();
}