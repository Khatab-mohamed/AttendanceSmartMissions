namespace AMS.Domain.Entities;

public class Incident  : Base
{
    [Required]
    public string Title { get; set; }

    public string Description { get; set; }
    public Guid UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public Guid LocationId { get; set; }
    public Location Location { get; set; }

   
}