using AMS.Application.Services.Authentication.Roles;

namespace AMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Super Admin")]
public class AdministrationController : ControllerBase
{
    #region Constructor

    private readonly IRoleService _roleService;
    public AdministrationController(IRoleService roleService)
    {
        _roleService = roleService;
    }


    #endregion

    [HttpGet]
    public ActionResult<List<RoleDto>> GetRoles()
    {
        var roles = _roleService.GetRoles();

        return Ok(roles);
    }

    [HttpPost]
    public async Task<IActionResult> AddRole(CreateRoleDto roleDto)
    {
        await  _roleService.CreateRoleAsync(roleDto);
        return Created("",new {});
    }

    [HttpPut]
    [Route("{roleId:guid}")]
    public async Task<IActionResult> UpdateRole(Guid roleId, UpdateRoleDto updateRoleDto)
    {
        await _roleService.UpdateRole(roleId, updateRoleDto);

        return Ok("Updated Successfully");
    }

    [HttpDelete]
    [Route("{roleId:guid}")]
    public async Task<IActionResult> DeleteRole(Guid roleId)
    {
        var role = await _roleService.GetRole(roleId);
        if (role is null)
            return NotFound(new { Message = "Role doesn't exist" }); 
        await _roleService.DeleteAsync(roleId);

        return NoContent();
    }
}