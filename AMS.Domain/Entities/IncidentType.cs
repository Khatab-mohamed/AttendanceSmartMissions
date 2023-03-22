namespace AMS.Domain.Entities;

public class IncidentType
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    public  IEnumerable<Incident> Incidents { get; set; }
}