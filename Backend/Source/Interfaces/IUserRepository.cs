using Source.Dtos;
using Source.Entities;
using System.Linq.Expressions;

namespace Source.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User? GetUser(Expression<Func<User, bool>> predicate);
    }
}
