using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Product name must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Product name cannot be longer than 50 characters.")
                .Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("Product name must contain only letters.");

            RuleFor(product => product.Description)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long.")
                .MaximumLength(300).WithMessage("Username cannot be longer than 300 characters.");

            RuleFor(product => product.Price)
                .GreaterThanOrEqualTo(0).WithMessage("The price must be greater than or equal to 0.");
        }
    }
}