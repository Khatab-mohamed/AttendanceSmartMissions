namespace AMS.Application.DTOs.Authentication;

public class RegisterDto
{
    [Required]
    public string FullName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string IDNumber { get; set; }

    public string DeviceSerialNumber { get; set; }
    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public string Password { get; set; }


}