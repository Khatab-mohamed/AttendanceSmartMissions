using AMS.Domain.Entities.Locations;

namespace AMS.Domain.Entities;

public class Location :Base
{
   

    [Required]
    public string Name { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int AllowedDistance { get; set; }
    public bool IsPublic { get; set; }
    public  List<UserLocation> UserLocations { get; set; }

}