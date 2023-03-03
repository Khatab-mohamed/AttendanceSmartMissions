namespace AMS.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jWtSettings;
    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,
        IOptions<JwtSettings> jWtOptions)
    {
          _dateTimeProvider = dateTimeProvider;
        _jWtSettings = jWtOptions.Value;
    }

    public string GenerateToken(ApplicationUser applicationUser)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jWtSettings.SecretKey)),
            SecurityAlgorithms.HmacSha256);


        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,applicationUser.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName,applicationUser.FullName),
            new Claim(JwtRegisteredClaimNames.FamilyName,applicationUser.FullName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jWtSettings.Issuer,
            audience: _jWtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddDays(_jWtSettings.ExpireInHours),
            claims: claims,
            signingCredentials: signingCredentials);
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}