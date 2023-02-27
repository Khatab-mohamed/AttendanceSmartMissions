namespace AMS.Domain.Entities;

public class Location :Base
{
    public Location(string name, DateTime startDate, DateTime endDate, double latitude, double longitude, int allowedDistance, bool isPublic)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        Latitude = latitude;
        Longitude = longitude;
        AllowedDistance = allowedDistance;
        IsPublic = isPublic;
    }

    [Required]
    public string Name { get; set; }

    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public double Latitude { get; }
    public double Longitude { get; }
    public int AllowedDistance { get; }
    public bool IsPublic { get; }


}