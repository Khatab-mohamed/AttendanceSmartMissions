namespace AMS.Application.DTOs.Authentication;

public record AuthenticateResult(
    ApplicationUser ApplicationUser,
    string Token
);