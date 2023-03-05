namespace AMS.Application.DTOs.Authentication;

public record AuthenticateResult(
    User User,
    string Token
);