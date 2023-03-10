using AMS.Application.Common;
using AMS.Domain.Entities.Authentication;

namespace AMS.Application.Services.Authentication;

public class UserService : IUserService
{
    #region Constructor


    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public UserService(UserManager<User> userManager,
        IMapper mapper,
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _mapper = mapper;
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    #endregion

    public async Task Register(RegisterDto? userDto)
    {
        var user = _mapper.Map<User>(userDto);

        var result = await _userManager.CreateAsync(user, userDto.Password);


    }

    public async Task<User?> UserExist(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user;

    }

    public async Task<string> Login(LoginDto user)
    {

        var userFromDb = await _userManager.FindByEmailAsync(user.Email);

        if (userFromDb is null)
            return "Invalid Credentials";

        var password = await _userManager.CheckPasswordAsync(userFromDb, user.Password);

        var userRoles = await _userManager.GetRolesAsync(userFromDb);

        if (!password)
            return "Check Your email or Your Password";

        if (!userRoles.Contains("Super Admin") && !userRoles.Contains("Admin"))
        {
            if (user.DeviceSerialNumber != userFromDb.DeviceSerialNumber)
                return "Please Use Your Registered Smart Phone... Or check The Admin";
        }
        
        if (!userFromDb.IsActive)
            return "Your Account is not Active yet... Please Check The Admin";
        
        var token = await _jwtTokenGenerator.GenerateToken(userFromDb);

            return token ;
        }

    public async Task UpdateUser(UpdateUserDto userDto)
    {
        var user = await _userManager.FindByIdAsync(userDto.Id.ToString());
        if (user == null) return;
        user.Email = userDto.Email;
        user.IsActive = userDto.IsActive;
        user.FullName = userDto.FullName;
        await _userManager.UpdateAsync(user);
    }

    public async  Task<UserDto> GetUserById(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
            return null;

        var userToReturn = _mapper.Map<UserDto>(user);
        return userToReturn;
    }

    public Task Logout()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        // Getting All  Users

        var users = _userManager.Users.ToList();
        // Mapping
        var userToReturn = _mapper.Map<IEnumerable<UserDto>>(users);

        // Getting Users Roles
        if (users is not null)
        {
            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var userToAddRoles = userToReturn.First(u => u.Id == user.Id);
                if (userRoles.Count != 0)
                {
                   
                        userToAddRoles.Roles =  _userManager.GetRolesAsync(user).Result.ToList();

                }

            }
        }
        return userToReturn;
    }

    public async Task UpdateUser(UserDto userDto)
    {
        var user = _userManager.FindByEmailAsync(userDto.Email);
        
        var updatedUser = _mapper.Map<User>(user);
        await _userManager.UpdateAsync(updatedUser);
    }

    public Task ForgetPassword(Guid userId, int code, string newPassword)
    {
        throw new NotImplementedException();
    }

    public Task ChangePassword(Guid userId, int code, string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }
}
