namespace AMS.Application.DTOs.Authentication;

public class UpdateUserDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }

    public string Email { get; set; }

    public string IDNumber { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsActive { get; set; }
}