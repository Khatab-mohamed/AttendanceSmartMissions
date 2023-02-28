namespace AMS.Domain.Entities;

public class Location :Base
{
   

    [Required]
    public string Name { get; set; }

    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public double Latitude { get; }
    public double Longitude { get; }
    public int AllowedDistance { get; }
    public bool IsPublic { get; }


}