namespace AMS.Application.Services.Authentication.Roles;
public interface IRoleService
{
    IEnumerable<RoleDto> GetRoles();
    Task CreateRoleAsync(RoleDto roleDto);
    Task UpdateRole(Guid id , UpdateRoleDto roleDto);
    Task DeleteAsync(Guid id);
    Task<Role?> GetRole(Guid id);
}