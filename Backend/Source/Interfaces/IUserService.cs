using Source.Dtos;

namespace Source.Interfaces
{
    public interface IUserService
    {
       UserLoginResponseDto Login(UserRequestDto userRequestDto);
    }
}
