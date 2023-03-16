namespace AMS.Domain.Entities.Locations;

public class UserLocation
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid LocationId { get; set; }
    public Location Location { get; set; }
}