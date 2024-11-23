using Microsoft.EntityFrameworkCore;
using Source.Context;
using Source.Entities;
using Source.Interfaces;

namespace Source.Repositories
{
    public class OrderRepository(DatabaseContext dbContext) : BaseRepository<Order>(dbContext), IOrderRepository
    {
    }
}
