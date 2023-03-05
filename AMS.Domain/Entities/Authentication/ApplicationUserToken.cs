namespace AMS.Domain.Entities.Authentication;

public class ApplicationUserToken : IdentityUserToken<Guid>
{
    public string FullName { get; set; }
    public string Password { get; set; }
    public string RefreshToken { get; set; }

}