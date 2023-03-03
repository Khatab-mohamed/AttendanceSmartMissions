namespace AMS.Application.Common.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(ApplicationUser applicationUser);
}