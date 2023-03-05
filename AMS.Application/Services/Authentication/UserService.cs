using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AMS.Application.Services.Authentication;

public class UserService:IUserService
{
    private readonly UserManager<User> _userManager;
    //private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    public UserService(UserManager<User> userManager, 
        IMapper mapper,
        IUserRepository userRepository
    )
    {
        _userManager = userManager;
        _mapper = mapper;
        _userRepository = userRepository;
      //  _signInManager = signInManager;
    }
    public async Task Register(RegisterDto? userDto)
    {
       var user = _mapper.Map<User>(userDto); 
       
         var result = await _userManager.CreateAsync(user,userDto.Password);
        
        
    }

}