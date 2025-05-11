using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the SaleItemValidator class.
/// Tests cover validation of all SaleItem properties including ProductId, Quantity, and UnitPrice.
/// </summary>
public class SaleItemValidatorTests
{
    private readonly SaleItemValidator _validator;

    public SaleItemValidatorTests()
    {
        _validator = new SaleItemValidator();
    }

    /// <summary>
    /// Tests that validation passes when all SaleItem properties are valid.
    /// </summary>
    [Fact(DisplayName = "Valid SaleItem should pass all validation rules")]
    public void Given_ValidSaleItem_When_Validated_Then_ShouldNotHaveErrors()
    {
        var saleItem = SaleItemTestData.GenerateValidSaleItem();

        var result = _validator.TestValidate(saleItem);

        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails when ProductId is empty.
    /// </summary>
    [Fact(DisplayName = "Empty ProductId should fail validation")]
    public void Given_EmptyProductId_When_Validated_Then_ShouldHaveError()
    {
        var saleItem = SaleItemTestData.GenerateValidSaleItem();
        saleItem.ProductId = Guid.Empty;

        var result = _validator.TestValidate(saleItem);

        result.ShouldHaveValidationErrorFor(x => x.ProductId);
    }

    /// <summary>
    /// Tests that validation fails when Quantity is less than or equal to 0.
    /// </summary>
    /// <param name="quantity">The invalid quantity to test.</param>
    [Theory(DisplayName = "Invalid Quantity should fail validation")]
    [InlineData(0)]
    [InlineData(-1)]
    public void Given_InvalidQuantity_When_Validated_Then_ShouldHaveError(int quantity)
    {
        var saleItem = SaleItemTestData.GenerateValidSaleItem();
        saleItem.Quantity = quantity;

        var result = _validator.TestValidate(saleItem);

        result.ShouldHaveValidationErrorFor(x => x.Quantity);
    }

    /// <summary>
    /// Tests that validation fails when Quantity exceeds the maximum allowed value.
    /// </summary>
    [Fact(DisplayName = "Quantity greater than 20 should fail validation")]
    public void Given_QuantityGreaterThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        var saleItem = SaleItemTestData.GenerateValidSaleItem();
        saleItem.Quantity = 21;

        var result = _validator.TestValidate(saleItem);

        result.ShouldHaveValidationErrorFor(x => x.Quantity);
    }

    /// <summary>
    /// Tests that validation fails when UnitPrice is negative.
    /// </summary>
    [Fact(DisplayName = "Negative UnitPrice should fail validation")]
    public void Given_NegativeUnitPrice_When_Validated_Then_ShouldHaveError()
    {
        var saleItem = SaleItemTestData.GenerateValidSaleItem();
        saleItem.UnitPrice = -1.00m;

        var result = _validator.TestValidate(saleItem);

        result.ShouldHaveValidationErrorFor(x => x.UnitPrice);
    }
}
