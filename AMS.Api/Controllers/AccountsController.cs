namespace AMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDto applicationUser)
        {
            if (applicationUser is not null)
                await _userService.Register(applicationUser);

            return Ok();
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto authUser)
        {

            var token = await _userService.Login(authUser);
            if (token == null)
                return BadRequest("Invalid Credentials");
            return Ok(token);
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllUser()
        {

            var users = await _userService.GetUsers();
            if (users is null)
                return BadRequest("No User Yet");
            return Ok(users);
        }


    }
}
