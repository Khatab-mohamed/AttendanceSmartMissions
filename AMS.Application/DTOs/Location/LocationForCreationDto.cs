namespace AMS.Application.DTOs.Location;

public class LocationForCreationDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public double Latitude { get; set; }

    [Required] 
    public double Longitude { get; set; }
    [Required]
    public int AllowedDistance { get; set; }
    public bool IsPublic { get; set; }


}

