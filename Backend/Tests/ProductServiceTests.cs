using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Source.Dtos;
using Source.Entities;
using Source.Interfaces;
using Source.Services;
using System.Linq.Expressions;

namespace Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IValidator<Product>> _validatorMock;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _validatorMock = new Mock<IValidator<Product>>();
            _productService = new ProductService(_productRepositoryMock.Object, _validatorMock.Object);
        }

        [Fact]
        public async Task CreateOrUpdateAsync_ShouldCreateNewProduct_WhenProductDoesNotExist()
        {
            // Arrange
            var productRequest = new ProductRequestDto
            {
                Id = Guid.NewGuid(),
                Name = "New Product",
                Description = "Product Description",
                Value = 99.99,
                ImageUrl = "http://example.com/image.png"
            };

            _productRepositoryMock
                .Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Product, bool>>>()))
                .ReturnsAsync((Product)null);

            _validatorMock
                .Setup(v => v.ValidateAsync(It.IsAny<Product>(), default))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult());

            // Act
            await _productService.CreateOrUpdateAsync(productRequest);

            // Assert
            _productRepositoryMock.Verify(repo => repo.Create(It.Is<Product>(p =>
                p.Name == productRequest.Name &&
                p.Description == productRequest.Description &&
                p.Value == productRequest.Value &&
                p.ImageUrl == productRequest.ImageUrl
            )), Times.Once);

            _productRepositoryMock.Verify(repo => repo.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateOrUpdateAsync_ShouldUpdateExistingProduct_WhenProductExists()
        {
            // Arrange
            var existingProduct = new Product(49.99, "Existing Product", "Old Description", "http://example.com/old.png");
            var productRequest = new ProductRequestDto
            {
                Id = Guid.NewGuid(),
                Name = "Updated Product",
                Description = "Updated Description",
                Value = 99.99,
                ImageUrl = "http://example.com/new.png"
            };

            _productRepositoryMock
                .Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Product, bool>>>()))
                .ReturnsAsync(existingProduct);

            _validatorMock
                .Setup(v => v.ValidateAsync(It.IsAny<Product>(), default))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult());

            // Act
            await _productService.CreateOrUpdateAsync(productRequest);

            // Assert
            _productRepositoryMock.Verify(repo => repo.Update(It.Is<Product>(p =>
                p.Name == productRequest.Name &&
                p.Description == productRequest.Description &&
                p.Value == productRequest.Value &&
                p.ImageUrl == productRequest.ImageUrl
            )), Times.Once);

            _productRepositoryMock.Verify(repo => repo.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteProduct_WhenProductExists()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var existingProduct = new Product(49.99, "Existing Product", "Description", "http://example.com/image.png");

            _productRepositoryMock
                .Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Product, bool>>>()))
                .ReturnsAsync(existingProduct);

            // Act
            await _productService.DeleteAsync(productId);

            // Assert
            _productRepositoryMock.Verify(repo => repo.Delete(existingProduct), Times.Once);
            _productRepositoryMock.Verify(repo => repo.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowKeyNotFoundException_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = Guid.NewGuid();

            _productRepositoryMock
                .Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Product, bool>>>()))
                .ReturnsAsync((Product)null);

            // Act
            Func<Task> act = async () => await _productService.DeleteAsync(productId);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>()
                .WithMessage("Produto não encontrado!");
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnAllProducts()
        {
            // Arrange
            var products = new List<Product>
        {
            new Product(49.99, "Product 1", "Description 1", "http://example.com/image1.png"),
            new Product(99.99, "Product 2", "Description 2", "http://example.com/image2.png")
        };

            _productRepositoryMock
                .Setup(repo => repo.GetAll())
                .ReturnsAsync(products);

            // Act
            var result = await _productService.GetAllProducts();

            // Assert
            result.Should().BeEquivalentTo(products);
        }
    }
}
