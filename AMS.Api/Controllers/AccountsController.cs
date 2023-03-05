using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        [HttpPost]
        [Route("login", Name = "Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto authUser)
        {

            var token = await _userService.Login(authUser);
            if (token == null)
                return BadRequest("Invalid Credentials");
            return Ok(token);
        }


    }
}
