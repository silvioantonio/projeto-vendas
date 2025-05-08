using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - SaleNumber: Cannot be empty and must be between 3 and 50 characters
        /// - SaleDate: Cannot be empty and must be less than or equal to the current date
        /// - CustomerId: Cannot
        /// - BranchId: Cannot by empty
        /// - TotalAmount: Must be greater than or equal to 0
        /// - Items: Cannot be empty
        /// </remarks>
        public CreateSaleCommandValidator()
        {
            RuleFor(sale => sale.SaleNumber).NotEmpty().Length(3, 50);
            RuleFor(sale => sale.SaleDate).NotEmpty().LessThanOrEqualTo(DateTime.UtcNow);
            RuleFor(sale => sale.CustomerId).NotEmpty();
            RuleFor(sale => sale.BranchId).NotEmpty();
            RuleFor(sale => sale.TotalAmount).GreaterThanOrEqualTo(0);
            RuleFor(sale => sale.Items).NotEmpty();
        }
    }
}