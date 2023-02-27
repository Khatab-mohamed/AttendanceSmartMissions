using AMS.Domain.Entities.Authentication;

namespace AMS.Domain.Entities;

public class Incident
{
    public Incident(string title, string description, Guid userId, User user, Guid locationId, Location location, DateTime createdOn)
    {
        Title = title;
        Description = description;
        UserId = userId;
        User = user;
        LocationId = locationId;
        Location = location;
        CreatedOn = createdOn;
    }

    public string Title { get; set; }

    public string Description { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid LocationId { get; set; }
    public Location Location { get; set; }
    public DateTime CreatedOn { get; set; }
}