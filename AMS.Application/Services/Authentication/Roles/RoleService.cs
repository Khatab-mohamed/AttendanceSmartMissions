namespace AMS.Application.Services.Authentication.Roles;

public class RoleService : IRoleService
{


    #region Constructor

    private readonly RoleManager<Role> _roleManager;
    private readonly IMapper _mapper;
    private readonly ILogger<RoleService> _logger;
    public RoleService(RoleManager<Role> roleManager, IMapper mapper, ILogger<RoleService> log)
    {
        _roleManager = roleManager;
        _mapper = mapper;
        _logger = log;
    }
    #endregion


    public IEnumerable<RoleDto>  GetRoles()
    {
        var roles = _roleManager.Roles.ToList();

        var rolesDto = _mapper.Map<List<RoleDto>>(roles);
        return rolesDto;
    }

    public async Task CreateRoleAsync(RoleDto roleDto)
    {
        var identityRole = _mapper.Map<Role>(roleDto);
        var result = await _roleManager.CreateAsync(identityRole);

        foreach (var error in result.Errors)
        {
            _logger.LogError(error.Description, error);
        }
        
    }

    public async Task UpdateRole(Guid id, UpdateRoleDto roleDto)
    {
        var role = await this.GetRole(id);
        if (role is not null)
        {
            role.Name = roleDto.RoleName;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
                return;
            foreach (var error in result.Errors)
            {
                _logger.LogError(error.Description, error);
            }
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var role = await _roleManager.FindByIdAsync(id.ToString());

        if (role is not null)
        {
            var result = await _roleManager.DeleteAsync(role);
        }
        
    }

    public async Task<Role?> GetRole(Guid id)
    {
        var role = await _roleManager.FindByIdAsync(
            id.ToString());
        return role;
    }
}