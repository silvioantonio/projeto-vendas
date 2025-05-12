using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
    {
        public UpdateSaleValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Sale ID is required.");
            RuleFor(x => x.SaleNumber).NotEmpty().MaximumLength(50).WithMessage("Sale Number is required and cannot exceed 50 characters.");
            RuleFor(x => x.SaleDate).NotEmpty().WithMessage("Sale Date is required.");
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer ID is required.");
            RuleFor(x => x.TotalAmount).GreaterThanOrEqualTo(0).WithMessage("Total Amount must be greater than or equal to 0.");
            RuleFor(x => x.Items).NotEmpty().WithMessage("At least one item must be included in the sale.");
            RuleForEach(x => x.Items).SetValidator(new UpdateSaleItemValidator());
        }
    }
}
