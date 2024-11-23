using FluentAssertions;
using Moq;
using Source.Dtos;
using Source.Entities;
using Source.Enum;
using Source.Exceptions;
using Source.Interfaces;
using Source.Services;
using System.Linq.Expressions;

namespace Tests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _repositoryMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _repositoryMock = new Mock<IUserRepository>();
            _tokenServiceMock = new Mock<ITokenService>();
            _userService = new UserService(_repositoryMock.Object, _tokenServiceMock.Object);
        }

        [Fact]
        public void Login_ShouldReturnUserLoginResponseDto_WhenUserIsValid()
        {
            // Arrange
            var userRequestDto = new UserRequestDto
            {
                Email = "test@example.com",
                Password = "TestPassword123"
            };

            var user = new User(
                name: "Test User",
                email: "test@example.com",
                password: "TestPassword123",
                adresses: new List<AddressDto>(),
                role: UserRole.Manager
            );

            _repositoryMock
                .Setup(repo => repo.GetUser(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(user);

            var token = "fake-token";
            _tokenServiceMock
                .Setup(tokenService => tokenService.GenerateToken(It.IsAny<User>()))
                .Returns(token);

            // Act
            var result = _userService.Login(userRequestDto);

            // Assert
            result.Should().NotBeNull();
            result.Token.Should().Be(token);
            result.Name.Should().Be(user.Name);
            result.Role.Should().Be(user.Role);
            result.Addresses.Should().BeEquivalentTo(user.Adresses);
        }

        [Fact]
        public void Login_ShouldThrowUserNotFoundException_WhenUserIsInvalid()
        {
            // Arrange
            var userRequestDto = new UserRequestDto
            {
                Email = "invalid@example.com",
                Password = "InvalidPassword123"
            };

            _repositoryMock
                .Setup(repo => repo.GetUser(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns((User)null);

            // Act
            Func<UserLoginResponseDto> act = () => _userService.Login(userRequestDto);

            // Assert
            act.Should().Throw<UserNotFoundException>();
        }
    }
}
