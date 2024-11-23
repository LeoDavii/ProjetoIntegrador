using Source.Dtos;
using Source.Exceptions;
using Source.Interfaces;

namespace Source.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        public UserLoginResponseDto Login(UserRequestDto userRequestDto)
        {
            var user = _repository.GetUser(u => u.Email == userRequestDto.Email &&
                                                 u.Password == userRequestDto.Password) ??
                        throw new UserNotFoundException();

            string token = _tokenService.GenerateToken(user);

            return new UserLoginResponseDto
            {
                Token = token,
                Addresses = user.Adresses,
                Name = user.Name,
                Role = user.Role
            };
        }
    }
}
