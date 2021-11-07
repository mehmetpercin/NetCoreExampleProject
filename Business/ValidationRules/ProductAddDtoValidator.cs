using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(100);
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.Quantity).GreaterThan(0);
        }
    }
}
