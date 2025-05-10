using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides test data for the SaleItem entity.
/// </summary>
internal static class SaleItemTestData
{
    /// <summary>
    /// Generates a valid SaleItem instance for testing.
    /// </summary>
    /// <returns>A valid SaleItem instance.</returns>
    public static SaleItem GenerateValidSaleItem()
    {
        var item = new SaleItem
        {
            ProductId = Guid.NewGuid(),
            Quantity = 5,
            UnitPrice = 100.00m,
        };

        item.ApplyDiscount();
        item.TotalCalculation();

        return item;
    }

    /// <summary>
    /// Generates an invalid SaleItem instance for testing.
    /// </summary>
    /// <returns>An invalid SaleItem instance.</returns>
    public static SaleItem GenerateInvalidSaleItem()
    {
        var item = new SaleItem
        {
            ProductId = Guid.NewGuid(),
            Quantity = -1,
            UnitPrice = 100.00m,
        };

        item.ApplyDiscount();
        item.TotalCalculation();

        return item;
    }

    /// <summary>
    /// Generates a SaleItem instance with a specific quantity for testing discount rules.
    /// </summary>
    /// <param name="quantity">The quantity of the SaleItem.</param>
    /// <returns>A SaleItem instance with the specified quantity.</returns>
    public static SaleItem GenerateSaleItemWithQuantity(int quantity)
    {
        var item = new SaleItem
        {
            ProductId = Guid.NewGuid(),
            Quantity = quantity,
            UnitPrice = 100.00m,
        };

        return item;
    }
}
