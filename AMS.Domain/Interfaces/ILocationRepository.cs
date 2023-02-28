namespace AMS.Domain.Interfaces
{
    public interface ILocationRepository
    {
        IEnumerable<Domain.Entities.Location> GetLocations();

        //PagedList<User> GetUsers(UserResourceParameters authorsResourceParameters);
        Location GetLocations(Guid locationId);
        IEnumerable<Location> Locations(IEnumerable<Guid> locationsIds);
        Task AddLocation(Location locationDto);
        Task DeleteLocation(Location locationDto);
        Task UpdateLocation(Location locationDto);
        bool LocationExists(Guid locationId);
        bool Save();
    }
}
