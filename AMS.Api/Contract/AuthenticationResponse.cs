namespace AMS.Api.Contract
{
    public record AuthenticateResponse(
        Guid Id,
        string FullName,
        string Email,
        string Token
    );

}
