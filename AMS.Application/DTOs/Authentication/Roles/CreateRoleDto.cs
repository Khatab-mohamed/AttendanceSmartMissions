namespace AMS.Application.DTOs.Authentication.Roles;

public class AddUserRoleDto
{
    [Required]
    public string Email { get; set; }
    public string RoleName { get; set; }
}