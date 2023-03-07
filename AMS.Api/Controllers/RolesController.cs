using AMS.Application.Common;
using AMS.Application.DTOs.Authentication.Roles;
using AMS.Application.Services.Authentication.Roles;
using AMS.Domain.Entities.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class RolesController : ControllerBase
{
    #region Constructor

    private readonly IRoleService _roleService;
    private readonly RoleManager<Role> _roleManager;
    public RolesController(IRoleService roleService, RoleManager<Role> roleManager)
    {
        _roleService = roleService;
        _roleManager = roleManager;
    }


    #endregion

    [HttpGet]
    public ActionResult<List<RoleDto>> GetRoles()
    {
        var roles = _roleService.GetRoles();
        if (roles is null)
            return NotFound("No Roles Yet");
        return Ok(roles);
    }
    
    
    
    /*
    [HttpGet("{roleId:guid}")]
    [Route("GetRole")]
    public async Task<IActionResult> GetRole(Guid roleId)
    {
        var role = await _roleManager.FindByIdAsync(roleId.ToString());
        if (role is null)
            return BadRequest(new ResponseDto { Status = "Bad Request", Message = "Role is not exists" });

        return Ok(role);
    }*/

    [HttpPost]
    public async Task<IActionResult> AddRole(CreateRoleDto roleDto)
    {
        if (roleDto.RoleName == null) return BadRequest("Role Name Is Required");
        
        var exist = await _roleManager.RoleExistsAsync(roleDto.RoleName);
        if (exist)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Role Already Exists" });
            
        await _roleService.CreateRoleAsync(roleDto);
        var createdRole = await _roleManager.FindByNameAsync(roleDto.RoleName);
        if (createdRole != null)
            return CreatedAtRoute("GetRole", createdRole);
        return BadRequest("Role Name Is Required");

        
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRole(Guid roleId, UpdateRoleDto updateRoleDto)
    {
        await _roleService.UpdateRole(roleId, updateRoleDto);

        return Ok("Updated Successfully");
    }

    [HttpDelete]
    [Route("{roleId:guid}")]
    public async Task<IActionResult> DeleteRole(Guid roleId)
    {
        var role = await _roleManager.FindByIdAsync(roleId.ToString());
        if (role is null)
            return BadRequest(new ResponseDto { Status = "Bad Request", Message = "Role is not exists" });

        _roleManager.DeleteAsync(role);
        return NoContent();
    }
}