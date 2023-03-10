namespace AMS.Application.DTOs.Authentication;

public class RegisterDto
{
    [Required]
    public string FullName { get; set; }


    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    public string IdNumber { get; set; }

    public string DeviceSerialNumber { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    [Required]
    [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
    public string Password { get; set; }



}