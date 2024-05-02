using FluentValidation;

namespace Products.Application.Features.Commands.AddProduct
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{Name} must not exceed 100 characters");

            RuleFor(p => p.BrandName)
                .NotEmpty().WithMessage("{BrandName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{BrandName} must not exceed 50 characters");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{Price} is required")
                .NotNull()
                .GreaterThan(1);
        }
    }
}
