using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;

/// <summary>
/// Represents an sale item.
/// </summary>
public class SaleItem : BaseEntity
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }

    public SaleItem() { }

    public decimal TotalCalculation()
    {
        var totalWithoutDiscount = Quantity * UnitPrice;
        return totalWithoutDiscount - Discount;
    }

    public void ApplyDiscount()
    {
        if (Quantity > 4 && Quantity <= 10)
            Discount = Quantity * UnitPrice * 0.10m;
        else if (Quantity > 10 && Quantity <= 20)
            Discount = Quantity * UnitPrice * 0.20m;
        else if (Quantity > 20)
            throw new InvalidOperationException("It's not possible to sell more than 20 identical itens.");
    }

    /// <summary>
    /// Performs validation of the saleItem entity using the SaleItemValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleItemValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
