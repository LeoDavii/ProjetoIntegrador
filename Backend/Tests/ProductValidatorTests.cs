using FluentValidation.TestHelper;
using Source.Entities;
using Source.Validators;

namespace Tests
{
    public class ProductValidatorTests
    {
        private readonly ProductValidator _validator;

        public ProductValidatorTests()
        {
            _validator = new ProductValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            // Arrange
            var product = new Product(
                value: 100,
                name: string.Empty, // Invalid name
                description: "Valid Description",
                imageUrl: "http://example.com/image.jpg"
            );

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.Name)
                  .WithErrorMessage("'Name' must not be empty.");
        }

        [Fact]
        public void Should_Have_Error_When_Value_Is_Zero()
        {
            // Arrange
            var product = new Product(
                value: 0, // Invalid value
                name: "Valid Name",
                description: "Valid Description",
                imageUrl: "http://example.com/image.jpg"
            );

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.Value)
                  .WithErrorMessage("Invalid Value");
        }

        [Fact]
        public void Should_Have_Error_When_Description_Is_Empty()
        {
            // Arrange
            var product = new Product(
                value: 100,
                name: "Valid Name",
                description: string.Empty, // Invalid Description
                imageUrl: "http://example.com/image.jpg"
            );

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.Description)
                  .WithErrorMessage("'Description' must not be empty.");
        }

        [Fact]
        public void Should_Have_Error_When_ImageUrl_Is_Empty()
        {
            // Arrange
            var product = new Product(
                value: 100,
                name: "Valid Name",
                description: "Valid Description",
                imageUrl: string.Empty // Invalid ImageUrl
            );

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.ImageUrl)
                  .WithErrorMessage("'Image Url' must not be empty.");
        }

        [Fact]
        public void Should_Not_Have_Any_Errors_When_Product_Is_Valid()
        {
            // Arrange
            var product = new Product(
                value: 100,
                name: "Valid Name",
                description: "Valid Description",
                imageUrl: "http://example.com/image.jpg"
            );

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
