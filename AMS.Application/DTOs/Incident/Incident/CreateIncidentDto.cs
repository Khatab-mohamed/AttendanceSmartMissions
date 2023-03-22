namespace AMS.Application.DTOs.Incident.Incident;
public class CreateIncidentDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    public Guid LocationId { get; set; }
    public Guid TypeId { get; set; }
}