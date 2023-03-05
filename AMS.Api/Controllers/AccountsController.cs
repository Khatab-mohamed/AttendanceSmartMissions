using Microsoft.EntityFrameworkCore;

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
            if (applicationUser is not null) await _userService.Register(applicationUser);

            return Ok();
        }


    }
}
