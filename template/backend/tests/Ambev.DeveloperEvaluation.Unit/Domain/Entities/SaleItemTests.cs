using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the SaleItem entity class.
/// Tests cover validation, total calculation, and discount application.
/// </summary>
public class SaleItemTests
{
    /// <summary>
    /// Tests that validation passes when all SaleItem properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid SaleItem data")]
    public void Given_ValidSaleItemData_When_Validated_Then_ShouldReturnValid()
    {
        var saleItem = SaleItemTestData.GenerateValidSaleItem();

        var result = saleItem.Validate();

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when SaleItem properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid SaleItem data")]
    public void Given_InvalidSaleItemData_When_Validated_Then_ShouldReturnInvalid()
    {
        var saleItem = SaleItemTestData.GenerateInvalidSaleItem();

        var result = saleItem.Validate();

        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that the total calculation is correct for a SaleItem.
    /// </summary>
    [Fact(DisplayName = "Total calculation should be correct for valid SaleItem")]
    public void Given_ValidSaleItem_When_TotalCalculated_Then_ShouldReturnCorrectTotal()
    {
        var saleItem = SaleItemTestData.GenerateValidSaleItem();

        saleItem.TotalCalculation();

        var expectedTotal = (saleItem.Quantity * saleItem.UnitPrice) - saleItem.Discount;
        Assert.Equal(expectedTotal, saleItem.Total);
    }

    /// <summary>
    /// Tests that a discount is applied correctly for a SaleItem with quantity between 5 and 10.
    /// </summary>
    [Fact(DisplayName = "Discount should be applied correctly for quantity between 5 and 10")]
    public void Given_SaleItemWithQuantityBetween5And10_When_DiscountApplied_Then_ShouldApply10PercentDiscount()
    {
        var saleItem = SaleItemTestData.GenerateSaleItemWithQuantity(6);

        saleItem.ApplyDiscount();

        var expectedDiscount = saleItem.Quantity * saleItem.UnitPrice * 0.10m;
        Assert.Equal(expectedDiscount, saleItem.Discount);
    }

    /// <summary>
    /// Tests that a discount is applied correctly for a SaleItem with quantity between 11 and 20.
    /// </summary>
    [Fact(DisplayName = "Discount should be applied correctly for quantity between 11 and 20")]
    public void Given_SaleItemWithQuantityBetween11And20_When_DiscountApplied_Then_ShouldApply20PercentDiscount()
    {
        var saleItem = SaleItemTestData.GenerateSaleItemWithQuantity(15);

        saleItem.ApplyDiscount();

        var expectedDiscount = saleItem.Quantity * saleItem.UnitPrice * 0.20m;
        Assert.Equal(expectedDiscount, saleItem.Discount);
    }

    /// <summary>
    /// Tests that an exception is thrown when trying to apply a discount for a SaleItem with quantity greater than 20.
    /// </summary>
    [Fact(DisplayName = "Exception should be thrown for quantity greater than 20")]
    public void Given_SaleItemWithQuantityGreaterThan20_When_DiscountApplied_Then_ShouldThrowException()
    {
        var saleItem = SaleItemTestData.GenerateSaleItemWithQuantity(25);

        Assert.Throws<InvalidOperationException>(() => saleItem.ApplyDiscount());
    }
}
