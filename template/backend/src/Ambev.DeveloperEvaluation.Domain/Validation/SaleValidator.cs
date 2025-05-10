using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.SaleNumber)
            .NotEmpty().WithMessage("Sale number cannot be empty.")
            .MinimumLength(3).WithMessage("Sale number must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Sale number cannot be longer than 50 characters.");

        RuleFor(sale => sale.SaleDate)
            .NotEmpty().WithMessage("Sale date cannot be empty.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Sale date cannot be in the future.");

        RuleFor(sale => sale.CustomerId)
            .NotEmpty().WithMessage("Customer ID cannot be empty.");

        RuleFor(sale => sale.CustomerName)
            .NotEmpty().WithMessage("Customer name cannot be empty.")
            .MinimumLength(3).WithMessage("Customer name must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Customer name cannot be longer than 100 characters.")
            .Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("Customer name must contain only letters.");

        RuleFor(sale => sale.BranchId)
            .NotEmpty().WithMessage("Branch ID cannot be empty.");

        RuleFor(sale => sale.BranchName)
            .NotEmpty().WithMessage("Branch name cannot be empty.")
            .MinimumLength(3).WithMessage("Branch name must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Branch name cannot be longer than 100 characters.")
            .Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("Branch name must contain only letters.");

        RuleFor(sale => sale.TotalAmount)
            .GreaterThanOrEqualTo(0).WithMessage("Total amount must be greater than or equal to 0.");

        RuleFor(sale => sale.Items)
            .NotEmpty().WithMessage("Sale must have at least one item.")
            .ForEach(item =>
            {
                item.NotNull().WithMessage("Sale item cannot be null.");
                item.SetValidator(new SaleItemValidator());
            });
    }
}