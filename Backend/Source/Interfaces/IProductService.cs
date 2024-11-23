using Source.Dtos;
using Source.Entities;

namespace Source.Interfaces
{
    public interface IProductService
    {
        Task CreateOrUpdateAsync(ProductRequestDto productRequest);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
