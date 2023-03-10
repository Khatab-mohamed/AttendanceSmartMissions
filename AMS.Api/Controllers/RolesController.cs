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
    public async Task<IActionResult> CreateRole(string roleName)
    {
        var roleExist = await _roleManager.RoleExistsAsync(roleName);

        if (roleExist)
            return BadRequest(new { error = "Role already exist" });
        //create the roles and seed them to the database: Question 1

        var roleResult = await _roleManager.CreateAsync(new Role(roleName));

        if (roleResult.Succeeded)
        {
            _logger.LogInformation(1, "Roles Added");
            return Ok(new { result = $"Role {roleName} added successfully" });
        }

        _logger.LogInformation(2, "Error");
        return BadRequest(new { error = $"Issue adding the new {roleName} role" });

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
    public async Task<IActionResult> AddUserToRole(string email, string roleName)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null) 
            return BadRequest(new { error = "Unable to find user" });
        
        var result = await _userManager.AddToRoleAsync(user, roleName);

        if (!result.Succeeded)
        {
            _logger.LogInformation(1, $"Error: Unable to add user {user.Email} to the {roleName} role");
            return BadRequest(new { error = $"Error: Unable to add user {user.Email} to the {roleName} role" });
        }

        else
        {
            _logger.LogInformation(1, $"User {user.Email} added to the {roleName} role");
            return Ok(new { result = $"User {user.Email} added to the {roleName} role" });
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
    public async Task<IActionResult> RemoveUserFromRole(string email, string roleName)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
            return BadRequest(new { error = "Unable to find user" });
        
        var result = await _userManager.RemoveFromRoleAsync(user, roleName);

        if (result.Succeeded)
        {
            _logger.LogInformation(1, $"User {user.Email} removed from the {roleName} role");
            return Ok(new { result = $"User {user.Email} removed from the {roleName} role" });
        }
        else
        {
            _logger.LogInformation(1, $"Error: Unable to removed user {user.Email} from the {roleName} role");
            return BadRequest(new { error = $"Error: Unable to removed user {user.Email} from the {roleName} role" });
        }

        // User doesn't exist
    }
}