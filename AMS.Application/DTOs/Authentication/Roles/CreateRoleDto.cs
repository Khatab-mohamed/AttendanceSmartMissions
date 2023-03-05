namespace AMS.Application.DTOs.Authentication.Roles;

public class CreateRoleDto
{
    [Required]
    public string RoleName { get; set; }
}