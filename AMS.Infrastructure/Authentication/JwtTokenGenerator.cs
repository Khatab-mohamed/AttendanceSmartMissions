namespace AMS.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    #region Constructor


    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jWtSettings;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,
        IOptions<JwtSettings> jWtOptions, UserManager<User> userManager, 
        RoleManager<Role> roleManager)
    {
        _dateTimeProvider = dateTimeProvider;
        _userManager = userManager;
        _roleManager = roleManager;
        _jWtSettings = jWtOptions.Value;
    }

    #endregion

    public async Task<string> GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jWtSettings.SecretKey)),
            SecurityAlgorithms.HmacSha256);
        var roles = await _userManager.GetRolesAsync(user);

        var options = new IdentityOptions();

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sub, user.FullName),
            new Claim("userId",user.Id.ToString()),
        };
        claims.AddRange(roles.Select(role => new Claim("roles",role)));
        // Get Roles
        var userClaims = await _userManager.GetClaimsAsync(user);

        claims.Union(userClaims);

        var securityToken = new JwtSecurityToken(
            issuer: _jWtSettings.Issuer,
            audience: _jWtSettings.Audience,
            expires: DateTime.UtcNow.AddMonths(1),
            claims: claims,
            signingCredentials: signingCredentials);
        return new JwtSecurityTokenHandler().WriteToken(securityToken);

        
       

    }
}