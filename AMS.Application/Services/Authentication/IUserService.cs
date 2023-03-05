namespace AMS.Application.Services.Authentication;

public interface IUserService
{

    //UserDTO GetById(Guid id);
    Task Register(RegisterDto? userDto);
    Task<string> Login(LoginDto user);

}