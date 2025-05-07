using FluentValidation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
	public SaleItemValidator()
	{
        RuleFor(item => item.ProductId)
            .NotEmpty().WithMessage("Product ID cannot be empty.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
            .LessThanOrEqualTo(20).WithMessage("Quantity cannot exceed 20.");

        RuleFor(item => item.UnitPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Unit price must be greater than or equal to 0.");

        RuleFor(item => item.Discount)
            .GreaterThanOrEqualTo(0).WithMessage("Discount must be greater than or equal to 0.")
            .LessThanOrEqualTo(1).WithMessage("Discount cannot exceed 100% (1.0).");

        RuleFor(item => item.Total)
            .GreaterThanOrEqualTo(0).WithMessage("Total must be greater than or equal to 0.")
            .Equal(item => (item.UnitPrice * item.Quantity) - (item.UnitPrice * item.Quantity * item.Discount))
            .WithMessage("Total must match the calculated value: (UnitPrice * Quantity) - Discount.");
    }
}
