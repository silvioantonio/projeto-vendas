using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Sale entity class.
/// Tests cover validation scenarios and business logic.
/// </summary>
public class SaleTests
{
    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid sale data")]
    public void Given_ValidSaleData_When_Validated_Then_ShouldReturnValid()
    {
        var sale = SaleTestData.GenerateValidSale();

        var result = sale.Validate();

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when sale properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid sale data")]
    public void Given_InvalidSaleData_When_Validated_Then_ShouldReturnInvalid()
    {
        var sale = SaleTestData.GenerateInvalidSale();

        var result = sale.Validate();

        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that the total calculation is correct for a sale with valid items.
    /// </summary>
    [Fact(DisplayName = "Total calculation should be correct for valid items")]
    public void Given_ValidSaleItems_When_TotalCalculated_Then_ShouldReturnCorrectTotal()
    {
        var sale = SaleTestData.GenerateValidSale();

        sale.TotalCalculation();

        var expectedTotal = sale.Items.Sum(item => item.Total);
        Assert.Equal(expectedTotal, sale.Total);
    }

    /// <summary>
    /// Tests that a sale can be successfully cancelled.
    /// </summary>
    [Fact(DisplayName = "Sale should be marked as cancelled when cancelled")]
    public void Given_Sale_When_Cancelled_Then_ShouldBeMarkedAsCancelled()
    {
        var sale = SaleTestData.GenerateValidSale();

        sale.Cancel();

        Assert.True(sale.Cancelled);
    }
}
