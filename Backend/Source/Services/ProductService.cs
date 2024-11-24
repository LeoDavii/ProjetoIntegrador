using FluentValidation;
using Source.Dtos;
using Source.Entities;
using Source.Interfaces;

namespace Source.Services
{
    public class ProductService(IProductRepository productRepository, IValidator<Product> validator) : IProductService
    {
        public async Task CreateOrUpdateAsync(ProductRequestDto productRequest)
        {
            var dbProduct = await productRepository.GetFirstOrDefaultAsync(p => p.Id == productRequest.Id);

            if (dbProduct is null)
            {
                var product = new Product(productRequest.Value,
                                          productRequest.Name ?? string.Empty,
                                          productRequest.Description ?? string.Empty,
                                          productRequest.ImageUrl);

                await ValidateProduct(product);
                productRepository.Create(product);
            }
            else
            {
                dbProduct.Update(productRequest.Value,
                                 productRequest.Name ?? string.Empty,
                                 productRequest.Description ?? string.Empty,
                                 productRequest.ImageUrl);

                await ValidateProduct(dbProduct);
                productRepository.Update(dbProduct);
            }

            await productRepository.CommitAsync();
        }

        private async Task ValidateProduct(Product product)
        {
            await validator.ValidateAndThrowAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await productRepository.GetFirstOrDefaultAsync(p => p.Id == id)
                            ?? throw new KeyNotFoundException("Produto não encontrado!");

            productRepository.Delete(product);
            await productRepository.CommitAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
            => await productRepository.GetAll();
    }
}
