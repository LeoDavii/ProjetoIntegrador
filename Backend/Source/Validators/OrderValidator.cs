using FluentValidation;
using Source.Entities;

namespace Source.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator() 
        {
            RuleFor(x => x.Address).NotEmpty().NotNull().WithMessage("Invalid Name");
            RuleFor(x => x.TotalValue).NotEmpty().NotEqual(double.MinValue).WithMessage("Invalid Value");
            RuleFor(x => x.CreatedAt).NotEmpty().NotNull().WithMessage("Invalid Description");
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage("Invalid URI");
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Invalid URI");
        }
    }
}
