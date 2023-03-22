namespace AMS.Application.DTOs.Incident.IncidentTypes;

public class CreationIncidentTypeDto
{
    [Required]
    [MaxLength(32)]
    public string Name { get; set; }
}