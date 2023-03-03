namespace AMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterDto applicationUser)
        {
            if (applicationUser is null)
                BadRequest();
            var result = _userService.Register(applicationUser);
            var response = new AuthenticateResponse(result.Result.ApplicationUser.Id, result.Result.ApplicationUser.FullName, result.Result.ApplicationUser.Email, result.Result.Token);

            return Ok(response);
        }


    }
}
