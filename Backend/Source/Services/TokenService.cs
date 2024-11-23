using Microsoft.IdentityModel.Tokens;
using Source.Entities;
using Source.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenService : ITokenService
{
    private readonly int _expirationMinutes;

    public TokenService(int expirationMinutes = 60)
    {
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