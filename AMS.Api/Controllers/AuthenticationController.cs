using AMS.Domain.Entities.Authentication;
using Microsoft.AspNetCore.Http;

namespace AMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        // [HttpPost("register")]
        // public async Task<IActionResult> Register(User request)
        // {
        //
        //     var command = _mapper.Map<RegisterCommand>(request);
        //
        //     var authResult = await _mediator.Send(command);
        //
        //     return authResult.Match(
        //         authenticateResult => Ok(_mapper.Map<AuthenticateResponse>(authenticateResult)),
        //         Problem);
        // }
        //
        //
        // [HttpPost("login")]
        // public async Task<IActionResult> Login(LoginRequest request)
        // {
        //     var query = _mapper.Map<LoginQuery>(request);
        //
        //     var authResult = await _mediator.Send(query);
        //
        //
        //     return authResult.Match(
        //         authenticateResult => Ok(_mapper.Map<AuthenticateResponse>(authenticateResult)),
        //         Problem);
        // }
    }
}
