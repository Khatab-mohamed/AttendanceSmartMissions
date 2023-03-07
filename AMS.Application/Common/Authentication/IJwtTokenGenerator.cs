namespace AMS.Application.Common.Authentication;

public interface IJwtTokenGenerator
{
    Task<string> GenerateToken(User user);
}