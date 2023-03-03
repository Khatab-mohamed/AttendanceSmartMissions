namespace AMS.Application.Services.Authentication;

public class UserService:IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public UserService(UserManager<ApplicationUser> userManager, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<AuthenticateResult> Register(RegisterDto applicationUser)
    {

        var identityUser = _mapper.Map<ApplicationUser>(applicationUser);
        try
        {
            var result = await _userManager.CreateAsync(identityUser, applicationUser.Password);
            await _userManager.AddToRoleAsync(identityUser, applicationUser.UserRole);
            var token = _jwtTokenGenerator.GenerateToken(identityUser);
            return new AuthenticateResult(
                identityUser,
                token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


    }

}