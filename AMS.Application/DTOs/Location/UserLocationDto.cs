namespace AMS.Application.DTOs.Location;

public class UserLocationDto
{
    [Required]
    public Guid UserId { get; set; }
    
    [Required]
    public Guid LocationId { get; set; }
}