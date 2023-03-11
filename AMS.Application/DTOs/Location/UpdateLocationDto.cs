namespace AMS.Application.DTOs.Location;

public class UpdateLocationDto : CreationLocationDto
{
    [Required]
    public Guid Id { get; set; }
}