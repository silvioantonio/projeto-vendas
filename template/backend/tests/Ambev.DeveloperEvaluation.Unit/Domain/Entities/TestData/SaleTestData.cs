using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides test data for the Sale entity.
/// </summary>
internal static class SaleTestData
{
    /// <summary>
    /// Generates a valid Sale instance for testing.
    /// </summary>
    /// <returns>A valid Sale instance.</returns>
    public static Sale GenerateValidSale()
    {
        return new Sale
        {
            SaleNumber = "SALE12345",
            SaleDate = DateTime.UtcNow,
            CustomerId = Guid.NewGuid(),
            CustomerName = "Valid Customer",
            BranchId = Guid.NewGuid(),
            BranchName = "Valid Branch",
            TotalAmount = 500.00m,
            Items = GenerateValidSaleItems(),
            CreatedAt = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Generates an invalid Sale instance for testing.
    /// </summary>
    /// <returns>An invalid Sale instance.</returns>
    public static Sale GenerateInvalidSale()
    {
        return new Sale
        {
            SaleNumber = "",
            SaleDate = DateTime.MinValue,
            CustomerId = Guid.Empty,
            CustomerName = "",
            BranchId = Guid.Empty,
            BranchName = "",
            TotalAmount = -100.00m,
            Items = [],
            CreatedAt = DateTime.MinValue
        };
    }

    /// <summary>
    /// Generates a list of valid SaleItem instances for testing.
    /// </summary>
    /// <returns>A list of valid SaleItem instances.</returns>
    private static List<SaleItem> GenerateValidSaleItems()
    {
        var saleItem1 = new SaleItem
        {
            ProductId = Guid.NewGuid(),
            Quantity = 2,
            UnitPrice = 100.00m
        };
        var saleItem2 = new SaleItem
        {
            ProductId = Guid.NewGuid(),
            Quantity = 1,
            UnitPrice = 300.00m
        };

        saleItem1.ApplyDiscount();
        saleItem1.TotalCalculation();
        saleItem2.ApplyDiscount();
        saleItem2.TotalCalculation();

        return
        [
            saleItem1, saleItem2
        ];
    }
}
