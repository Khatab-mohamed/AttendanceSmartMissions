namespace AMS.Application.DTOs.Incident.Incident;

public class IncidentToReturnDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string LocationName { get; set; }
    public string TypeName { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedOn { get; set; }
}