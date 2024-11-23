using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Source.Entities;
using Source.Interfaces;
using Source.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenService : ITokenService
{
    private readonly JwtOptions _jwtOptions;
    private readonly int _expirationMinutes;

    public TokenService(IOptions<JwtOptions> jwtOptions, int expirationMinutes = 60)
    {
        _jwtOptions = jwtOptions.Value;
        _expirationMinutes = expirationMinutes;
    }

    public string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TestKey12345678901234567890123456"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Email), 
            new("UserType", user.Role.ToString()),  
        };

        var expiration = DateTime.UtcNow.AddMinutes(_expirationMinutes);

        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}