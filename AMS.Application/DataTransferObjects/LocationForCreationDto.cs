namespace AMS.Application.DataTransferObjects;

public class LocationForCreationDto
{
    [Required] 
    public string Name { get; set; }

    public DateTimeOffset StartDate { get; }
    public DateTimeOffset EndDate { get; }
    [Required]
    public double Latitude { get; }
    [Required]
    public double Longitude { get; }
    [Required]
    public int AllowedDistance { get; }
    [Required]
    public bool IsPublic { get; }
}