namespace AMS.Application.DTOs.Incident.Incident;

public class IncidentDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }

    public string Description { get; set; }
    [Required]
    public Guid UserId { get; set; } 
    [Required]
    public Guid LocationId { get; set; }
    [Required]
    public Guid TypeId { get; set; }

}