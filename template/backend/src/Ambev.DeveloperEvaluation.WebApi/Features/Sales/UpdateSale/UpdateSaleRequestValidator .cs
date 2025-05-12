using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Sale ID is required.");
            RuleFor(x => x.SaleNumber).NotEmpty().MaximumLength(50).WithMessage("Sale Number is required and cannot exceed 50 characters.");
            RuleFor(x => x.SaleDate).NotEmpty().WithMessage("Sale Date is required.");
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer ID is required.");
            RuleFor(x => x.TotalAmount).GreaterThanOrEqualTo(0).WithMessage("Total Amount must be greater than or equal to 0.");
            RuleFor(x => x.Items).NotEmpty().WithMessage("At least one item must be included in the sale.");
            RuleForEach(x => x.Items).SetValidator(new UpdateSaleItemRequestValidator());
        }
    }
}
