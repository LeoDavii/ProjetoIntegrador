using FluentValidation;
using Source.Entities;

namespace Source.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Invalid Name");
            RuleFor(x => x.Value).NotEmpty().NotEqual(double.MinValue).WithMessage("Invalid Value");
            RuleFor(x => x.Id).NotEmpty().NotEqual(Guid.Empty).WithMessage("Invalid Id");
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Invalid Description");
            RuleFor(x => x.ImageUrl).NotEmpty().NotNull().WithMessage(" Invalid ImageData");
        }
    }
}
