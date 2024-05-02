using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Features.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
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
