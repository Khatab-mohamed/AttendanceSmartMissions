namespace AMS.Application.DataTransferObjects;

public class LocationForCreationDto
{
    [Required] 
    public string Name { get; set; }

    public DateTimeOffset StartDate { get; }
    public DateTimeOffset EndDate { get; }
    public double Latitude { get; }
    public double Longitude { get; }
    public int AllowedDistance { get; }
    public bool IsPublic { get; }
}