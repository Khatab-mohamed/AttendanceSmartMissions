namespace AMS.Application.Services.Authentication;

public interface IUserService
{

    //UserDTO GetById(Guid id);
    Task<AuthenticateResult> Register(RegisterDto applicationUser);

}