using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the SaleValidator class.
/// Tests cover validation of all sale properties including sale number, date, customer, branch, total amount, and items.
/// </summary>
public class SaleValidatorTests
{
    private readonly SaleValidator _validator;

    public SaleValidatorTests()
    {
        _validator = new SaleValidator();
    }

    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// </summary>
    [Fact(DisplayName = "Valid sale should pass all validation rules")]
    public void Given_ValidSale_When_Validated_Then_ShouldNotHaveErrors()
    {
        var sale = SaleTestData.GenerateValidSale();

        var result = _validator.TestValidate(sale);

        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails for invalid sale number formats.
    /// </summary>
    /// <param name="saleNumber">The invalid sale number to test.</param>
    [Theory(DisplayName = "Invalid sale number formats should fail validation")]
    [InlineData("")]
    [InlineData("ab")]
    public void Given_InvalidSaleNumber_When_Validated_Then_ShouldHaveError(string saleNumber)
    {
        var sale = SaleTestData.GenerateValidSale();
        sale.SaleNumber = saleNumber;

        var result = _validator.TestValidate(sale);

        result.ShouldHaveValidationErrorFor(x => x.SaleNumber);
    }

    /// <summary>
    /// Tests that validation fails when sale date is in the future.
    /// </summary>
    [Fact(DisplayName = "Sale date in the future should fail validation")]
    public void Given_SaleDateInFuture_When_Validated_Then_ShouldHaveError()
    {
        var sale = SaleTestData.GenerateValidSale();
        sale.SaleDate = DateTime.UtcNow.AddDays(1);

        var result = _validator.TestValidate(sale);

        result.ShouldHaveValidationErrorFor(x => x.SaleDate);
    }

    /// <summary>
    /// Tests that validation fails when customer ID is empty.
    /// </summary>
    [Fact(DisplayName = "Empty customer ID should fail validation")]
    public void Given_EmptyCustomerId_When_Validated_Then_ShouldHaveError()
    {
        var sale = SaleTestData.GenerateValidSale();
        sale.CustomerId = Guid.Empty;

        var result = _validator.TestValidate(sale);

        result.ShouldHaveValidationErrorFor(x => x.CustomerId);
    }

    /// <summary>
    /// Tests that validation fails for invalid customer name formats.
    /// </summary>
    /// <param name="customerName">The invalid customer name to test.</param>
    [Theory(DisplayName = "Invalid customer name formats should fail validation")]
    [InlineData("")]
    [InlineData("ab")]
    [InlineData("12345")]
    public void Given_InvalidCustomerName_When_Validated_Then_ShouldHaveError(string customerName)
    {
        var sale = SaleTestData.GenerateValidSale();
        sale.CustomerName = customerName;

        var result = _validator.TestValidate(sale);

        result.ShouldHaveValidationErrorFor(x => x.CustomerName);
    }

    /// <summary>
    /// Tests that validation fails when branch ID is empty.
    /// </summary>
    [Fact(DisplayName = "Empty branch ID should fail validation")]
    public void Given_EmptyBranchId_When_Validated_Then_ShouldHaveError()
    {
        var sale = SaleTestData.GenerateValidSale();
        sale.BranchId = Guid.Empty;

        var result = _validator.TestValidate(sale);

        result.ShouldHaveValidationErrorFor(x => x.BranchId);
    }

    /// <summary>
    /// Tests that validation fails for invalid branch name formats.
    /// </summary>
    /// <param name="branchName">The invalid branch name to test.</param>
    [Theory(DisplayName = "Invalid branch name formats should fail validation")]
    [InlineData("")]
    [InlineData("ab")]
    [InlineData("12345")]
    public void Given_InvalidBranchName_When_Validated_Then_ShouldHaveError(string branchName)
    {
        var sale = SaleTestData.GenerateValidSale();
        sale.BranchName = branchName;

        var result = _validator.TestValidate(sale);

        result.ShouldHaveValidationErrorFor(x => x.BranchName);
    }

    /// <summary>
    /// Tests that validation fails when total amount is negative.
    /// </summary>
    [Fact(DisplayName = "Negative total amount should fail validation")]
    public void Given_NegativeTotalAmount_When_Validated_Then_ShouldHaveError()
    {
        var sale = SaleTestData.GenerateValidSale();
        sale.TotalAmount = -1.00m;

        var result = _validator.TestValidate(sale);

        result.ShouldHaveValidationErrorFor(x => x.TotalAmount);
    }

    /// <summary>
    /// Tests that validation fails when sale has no items.
    /// </summary>
    [Fact(DisplayName = "Sale with no items should fail validation")]
    public void Given_SaleWithNoItems_When_Validated_Then_ShouldHaveError()
    {
        var sale = SaleTestData.GenerateValidSale();
        sale.Items = [];

        var result = _validator.TestValidate(sale);

        result.ShouldHaveValidationErrorFor(x => x.Items);
    }
}
