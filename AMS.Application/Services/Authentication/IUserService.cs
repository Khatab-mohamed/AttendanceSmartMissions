namespace AMS.Application.Services.Authentication;

public interface IUserService
{

    Task<User?> UserExist(string email);
    Task Register(RegisterDto? userDto);
    Task<string> Login(LoginDto user);
    Task Logout();
    Task<IEnumerable<UserDto>> GetUsers();
    Task UpdateUser(UserDto userDto);
}