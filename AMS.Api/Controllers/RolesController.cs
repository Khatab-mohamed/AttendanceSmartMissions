namespace AMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
//[Authorize(Roles = "Super Admin,Admin")]
public class RolesController : ControllerBase
{
    #region Constructor

    private readonly RoleManager<Role> _roleManager;
    protected readonly ILogger<RolesController> _logger;
    private readonly UserManager<User> _userManager;

    public RolesController(RoleManager<Role> roleManager,
        ILogger<RolesController> logger,
        UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _logger = logger;
        _userManager = userManager;
    }

    #endregion


    [HttpPost]
    public async Task<IActionResult> CreateRole(RoleDto roleDto)
    {
        var roleExist = roleDto.RoleName != null && await _roleManager.RoleExistsAsync(roleDto.RoleName);

        if (roleExist)
            return BadRequest(new { error = "Role already exist" });
        //create the roles and seed them to the database: Question 1

        if (roleDto.RoleName != null)
        {
            var roleResult = await _roleManager.CreateAsync(new Role(roleDto.RoleName));

            if (roleResult.Succeeded)
            {
                _logger.LogInformation(1, "Roles Added");
                return Ok(new { result = $"Role {roleDto} added successfully" });
            }
        }

        _logger.LogInformation(2, "Error");
        return BadRequest(new { error = $"Issue adding the new {roleDto} role" });

    }


    [HttpGet]
    public IActionResult GetAllRoles()
    {
        var roles = _roleManager.Roles.ToList();
        return Ok(roles);
    }

    [HttpGet]
    [Route("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userManager.Users.ToListAsync();
        return Ok(users);
    }


    [HttpPost]
    [Route("AddUserToRole")]
    public async Task<IActionResult> AddUserToRole(AddUserRoleDto roleDto)
    {
        var user = await _userManager.FindByEmailAsync(roleDto.Email);

        if (user == null)
            return BadRequest(new { error = "Unable to find user" });

        var result = await _userManager.AddToRoleAsync(user, roleDto.RoleName);

        if (!result.Succeeded)
        {
            _logger.LogInformation(1, $"Error: Unable to add user {user.Email} to the {roleDto.RoleName} role");
            return BadRequest(new { error = $"Error: Unable to add user {user.Email} to the {roleDto.RoleName} role" });
        }

        else
        {
            _logger.LogInformation(1, $"User {user.Email} added to the {roleDto.RoleName} role");
            return Ok(new { result = $"User {user.Email} added to the {roleDto.RoleName} role" });
        }


    }

    [HttpGet]
    [Route("GetUserRoles")]
    public async Task<IActionResult> GetUserRoles(string email)
    {
        // Resolve the user via their email
        var user = await _userManager.FindByEmailAsync(email);
        // Get the roles for the user
        if (user is null)
            return BadRequest(new { error = "Unable to find user" });

        var roles = await _userManager.GetRolesAsync(user);
        return Ok(roles);

    }

    [HttpPost]
    [Route("RemoveUserFromRole")]
    public async Task<IActionResult> RemoveUserFromRole(AddUserRoleDto roleDto)
    {
        var user = await _userManager.FindByEmailAsync(roleDto.Email);

        if (user == null)
            return BadRequest(new { error = "Unable to find user" });

        var result = await _userManager.RemoveFromRoleAsync(user, roleDto.RoleName);

        if (result.Succeeded)
        {
            _logger.LogInformation(1, $"User {user.Email} removed from the {roleDto.RoleName} role");
            return Ok(new { result = $"User {user.Email} removed from the {roleDto.RoleName} role" });
        }
        else
        {
            _logger.LogInformation(1, $"Error: Unable to removed user {user.Email} from the {roleDto.RoleName} role");
            return BadRequest(new
                { error = $"Error: Unable to removed user {user.Email} from the {roleDto.RoleName} role" });
        }

        // User doesn't exist
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveRole(string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role != null)
        {
            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                _logger.LogInformation(1, $"Role {roleName} Deleted");
                return Ok(new ResponseDto { Status = "Success", Message = "Role Deleted Successfully" });
            }

            _logger.LogInformation(1, $"Role  {roleName}  Deleted");
            return BadRequest(new { error = $"Error: Unable to removed user {roleName} from roles" });
        }
        _logger.LogInformation(1, $"Role  {roleName}  Not Found");
        return BadRequest(new { error = $"Error: Unable to removed user {roleName} from roles" });

        // User doesn't exist
    }

}