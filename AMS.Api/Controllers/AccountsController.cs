namespace AMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Super Admin,Admin")]
    public class AccountsController : ControllerBase
    {
        #region Constructor

        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        public AccountsController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
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

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserDto userDto)
        {
         
            var userExist = await _userService.UserExist(userDto.Email);

            if (userExist is null)
                return BadRequest(new ResponseDto { Status = "Failed", Message = "User Not Exists" }); 
            var res =  _userService.UpdateUser(userDto);

            return Ok(res);
        }


    }
}
