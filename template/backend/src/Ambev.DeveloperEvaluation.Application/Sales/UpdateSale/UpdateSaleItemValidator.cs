using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleItemValidator : AbstractValidator<SaleItem>
    {
        public UpdateSaleItemValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product ID is required for each item.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0 for each item.");
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0).WithMessage("Unit Price must be greater than or equal to 0 for each item.");
            RuleFor(x => x.Discount).GreaterThanOrEqualTo(0).WithMessage("Discount must be greater than or equal to 0 for each item.");
        }
    }
}
