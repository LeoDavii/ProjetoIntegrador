using Microsoft.EntityFrameworkCore;
using Source.Context;
using Source.Entities;
using Source.Interfaces;

namespace Source.Repositories
{
    public class ProductRepository(DatabaseContext dbContext) : BaseRepository<Product>(dbContext), IProductRepository
    {
    }
}
