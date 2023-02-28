 namespace AMS.Application.Services.Location;

public interface ILocationService

{
    IEnumerable<LocationDto> GetLocations();
    //PagedList<User> GetUsers(UserResourceParameters authorsResourceParameters);
    LocationDto GetLocations(Guid locationId);
    IEnumerable<LocationDto> Locations(IEnumerable<Guid> locationsIds);
    Task AddLocation(LocationForCreationDto locationDto);
    Task DeleteLocation(LocationDto locationDto);
    Task UpdateLocation(LocationDto locationDto);
    bool LocationExists(Guid locationId);
    bool Save();
}