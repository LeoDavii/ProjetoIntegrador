using FluentAssertions;
using Source.Dtos;
using Source.Entities;
using Source.Enum;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Tests
{
    public class TokenServiceTests
    {
        private readonly TokenService _tokenService;

        public TokenServiceTests()
        {
            _tokenService = new TokenService(expirationMinutes: 60);
        }

        [Fact]
        public void GenerateToken_ShouldGenerateValidJwtToken_WithCorrectClaims()
        {
            var user = new User(
                name: "Test User",
                email: "test@example.com",
                password: "TestPassword123",
                adresses: new List<AddressDto>(),
                role: UserRole.Manager
            );

            var token = _tokenService.GenerateToken(user);

            token.Should().NotBeNullOrEmpty();

            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);

            var nameIdentifierClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var userTypeClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserType");

            nameIdentifierClaim.Should().NotBeNull();
            userTypeClaim.Should().NotBeNull();

            nameIdentifierClaim.Value.Should().Be(user.Email);
            userTypeClaim.Value.Should().Be(user.Role.ToString());
        }

        [Fact]
        public void GenerateToken_ShouldSetExpirationTimeCorrectly()
        {
            var user = new User(
                name: "Test User",
                email: "test@example.com",
                password: "TestPassword123",
                adresses: new List<AddressDto>(),
                role: UserRole.Customer
            );

            var token = _tokenService.GenerateToken(user);

            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);

            var expiration = jwtToken.ValidTo;

            expiration.Should().BeCloseTo(DateTime.UtcNow.AddMinutes(60), TimeSpan.FromMinutes(1));
        }
    }
}