using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleItemRequestValidator : AbstractValidator<UpdateSaleItemRequest>
    {
        public UpdateSaleItemRequestValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product ID is required for each item.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0 for each item.");
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0).WithMessage("Unit Price must be greater than or equal to 0 for each item.");
            RuleFor(x => x.Discount).GreaterThanOrEqualTo(0).WithMessage("Discount must be greater than or equal to 0 for each item.");
        }
    }
}
