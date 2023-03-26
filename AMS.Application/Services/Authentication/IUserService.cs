namespace AMS.Application.Services.Authentication;

public interface IUserService
{

    Task<User?> UserExist(string email);
    Task Register(RegisterDto? userDto);
    Task<string> Login(LoginDto user); 
    Task UpdateUser(UpdateUserDto user);
    Task<UserDto>  GetUserById(Guid id);
    Task Logout();
    Task<IEnumerable<UserDto>> GetUsers();
    Task UpdateUser(UserDto userDto);
    Task ForgetPassword(Guid userId, int code, string newPassword);
    Task ChangePassword(Guid userId, int code, string oldPassword, string newPassword);

}