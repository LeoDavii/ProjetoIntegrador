using Source.Entities;

namespace Source.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
