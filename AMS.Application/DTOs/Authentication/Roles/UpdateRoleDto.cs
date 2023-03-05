namespace AMS.Application.DTOs.Authentication.Roles;

public class UpdateRoleDto
{
    [Required]
    public string RoleName { get; set; }
}