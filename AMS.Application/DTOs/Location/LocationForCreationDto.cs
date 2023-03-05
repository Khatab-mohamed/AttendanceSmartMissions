namespace AMS.Application.DTOs.Location;

public class LocationForCreationDto
{
    public string Name { get; set; }

    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int AllowedDistance { get; set; }
    public bool IsPublic { get; set; }


}

