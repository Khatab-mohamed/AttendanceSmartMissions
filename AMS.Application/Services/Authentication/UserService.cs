namespace AMS.Application.Services.Authentication;

public class UserService:IUserService
{
    private readonly UserManager<User> _userManager;
    //private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    //private readonly SignInManager<User> _signInManager;

    public UserService(UserManager<User> userManager, 
        IMapper mapper,
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator
        /*,SignInManager<User> signInManager*/)
    {
        _userManager = userManager;
        _mapper = mapper;
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
      //  _signInManager = signInManager;
    }
    public async Task Register(RegisterDto? userDto)
    {
       var user = _mapper.Map<User>(userDto); 
       
         var result = await _userManager.CreateAsync(user,userDto.Password);
        
        
    }

   private async  Task<User?> UserExist(string email)
   {
       var user = await _userManager.FindByEmailAsync(email);
        return user ;

   }

   public async Task<string> Login(LoginDto user)
   {
       var userIdentity = await UserExist(user.Email);

       var activity = userIdentity.IsActive;
       var pass = _userManager.CheckPasswordAsync(userIdentity, user.Password);
       
       if (userIdentity.IsActive 
           &&
           await _userManager.CheckPasswordAsync(userIdentity, user.Password))
       {
           return string.Format("Email not Active yet");
       }
       /*
       var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);
       if (!result.Succeeded) return string.Empty;
       */
       
       var token = _jwtTokenGenerator.GenerateToken(userIdentity);
       
       return token;


   }
}