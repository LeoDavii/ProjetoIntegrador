using Source.Context;
using Source.Entities;
using Source.Interfaces;
using System.Linq.Expressions;

namespace Source.Repositories
{
    public class UserRepository(DatabaseContext dbContext) : BaseRepository<User>(dbContext), IUserRepository
    {
        public User? GetUser(Expression<Func<User, bool>> predicate)
        {
            return Query.FirstOrDefault(predicate);
        }
    }
}
