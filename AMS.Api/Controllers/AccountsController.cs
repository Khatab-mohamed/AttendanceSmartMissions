using System.Security.Claims;

namespace AMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize(Roles = "Super Admin,Admin")]
    public class AccountsController : ControllerBase
    {
        #region Constructor

        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        protected readonly ILogger<AccountsController> _logger;
        public AccountsController(IUserService userService,
            UserManager<User> userManager,
            ILogger<AccountsController> logger)
        {
            _userService = userService;
            _userManager = userManager;
            _logger = logger;
        }


        #endregion


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDto userDto)
        {
            var  userExist = await _userService.UserExist(userDto.Email);
            
            if (userExist != null)
                return BadRequest(new ResponseDto { Status = "Failed", Message = "User Already Exists" });

            await _userService.Register(userDto);

            return Ok(new ResponseDto { Status = "Success", Message = "User created successfully" });
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var userFromDb = await _userManager.FindByEmailAsync(loginDto.Email);

            if (userFromDb is null)
                return BadRequest("Invalid Credentials Check Your Email Or password");


            var token = await _userService.Login(loginDto);
            if (token == null) BadRequest("Invalid Credentials Check Your Email Or password");

            var tokenResponse = new LoginResponse()
            {
                Token = token
            };

            return Ok(tokenResponse);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {

            var users = await _userService.GetUsers();
            if (users is null)
                return BadRequest("No User Yet");
            return Ok(users);
        }
        
        [HttpGet("{id:guid}")]

        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
                return BadRequest(new ResponseDto {Status = "Failed", Message = "User Not Found"});
           
            return Ok(user);
        }
        [HttpDelete("{id:guid}")]

        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
                return BadRequest(new ResponseDto {Status = "Failed", Message = "User Not Found"});
           
            await _userManager.DeleteAsync(user);
            return Ok(new ResponseDto { Status = "Success", Message = "User deleted Successfully" });
        }

        /*
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto userDto)
        {
         
            var userExist = await _userManager.Users.fin

            if (userExist is null)
                return BadRequest(new ResponseDto { Status = "Failed", Message = "User Not Exists" }); 
            var res =  _userService.UpdateUser(userDto);

            return Ok(res);
        } */
        /*[HttpPut]
        public async Task<IActionResult> ActiveUser(UpdateUserDto userDto)
        {
         
            

            if (userExist is null)
                return BadRequest(new ResponseDto { Status = "Failed", Message = "User Not Exists" }); 
            var res =  _userService.UpdateUser(userDto);

            return Ok(res);
        }
        */
        // Add User to role
        [HttpPost]
        [Route("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(string email, string roleName)
        {
         
            var user = await _userManager.FindByEmailAsync(email);

            // User doesn't exist
            if (user is null) return BadRequest(new { error = "Unable to find user" });
            
            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
                return Ok(new { result = $"User {user.Email} added to the {roleName} role" });
                
            else
                
                return BadRequest(new { error = $"Error: Unable to add user {user.Email} to the {roleName} role" });

        }

        [HttpGet]
        [Route("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string email)
        {
            // Resolve the user via their email
            var user = await _userManager.FindByEmailAsync(email);
            // Get the roles for the user
            if (user is null) return Ok();
            
            
            var roles = await _userManager.GetRolesAsync(user);
            
            return Ok(new{userRoles = roles});

        }
        [HttpPost]
        [Route("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null) 
                return BadRequest(new { error = "Unable to find user" });
            var result = await _userManager.RemoveFromRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                _logger.LogInformation(1, $"User {user.Email} removed from the {roleName} role");
                return Ok(new { result = $"User {user.Email} removed from the {roleName} role" });
            }

            _logger.LogInformation(1, $"Error: Unable to removed user {user.Email} from the {roleName} role");
            return BadRequest(new { error = $"Error: Unable to removed user {user.Email} from the {roleName} role" });

            // User doesn't exist
        }
        private Guid GetCurrentUserId()
        {
            return Guid.Parse(HttpContext.User.FindFirstValue("userId") ?? string.Empty);
        }


    }
}
