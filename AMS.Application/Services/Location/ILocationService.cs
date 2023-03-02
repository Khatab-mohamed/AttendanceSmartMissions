using AMS.Domain.Helpers;
using AMS.Domain.Helpers.Locations;

namespace AMS.Application.Services.Location;

public interface ILocationService

{
    PagedList<Domain.Entities.Location> GetLocations(LocationsResourceParameters locationsResourceParameters);
    LocationDto GetLocation(Guid locationId);
    LocationDto AddLocation(LocationForCreationDto location);
    
    bool Save();
}