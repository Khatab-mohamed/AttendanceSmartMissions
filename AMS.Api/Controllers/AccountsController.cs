namespace AMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            var user = await _userService.GetUserById(id);
            if (user is null)
                return BadRequest(new ResponseDto {Status = "Failed", Message = "User Not Found"});
           
            return Ok(user);
        }
   
       
      
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto userDto)
        {
            if (ModelState.IsValid)
             await _userService.UpdateUser(userDto);
            return Ok();
        }
        
        
        [HttpDelete("{id:guid}")]

        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
                return BadRequest(new ResponseDto { Status = "Failed", Message = "User Not Found" });

            await _userManager.DeleteAsync(user);
            return Ok(new ResponseDto { Status = "Success", Message = "User deleted Successfully" });
        }

    }
}
