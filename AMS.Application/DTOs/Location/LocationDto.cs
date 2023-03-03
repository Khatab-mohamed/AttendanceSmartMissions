namespace AMS.Application.DTOs.Location;

public class LocationDto
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int AllowedDistance { get; set; }
    public bool IsPublic { get; set; }

}