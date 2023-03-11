namespace AMS.Application.DTOs.Location;

public class CreationLocationDto
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
    [Required]
    public bool IsPublic { get; set; }


}