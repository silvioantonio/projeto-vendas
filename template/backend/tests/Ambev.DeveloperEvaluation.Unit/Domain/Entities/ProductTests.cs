using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Product entity class.
/// Tests cover validation scenarios.
/// </summary>
public class ProductTests
{
    /// <summary>
    /// Tests that validation passes when all product properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid product data")]
    public void Given_ValidProductData_When_Validated_Then_ShouldReturnValid()
    {
        var product = ProductTestData.GenerateValidProduct();

        var result = product.Validate();

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when product properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid product data")]
    public void Given_InvalidProductData_When_Validated_Then_ShouldReturnInvalid()
    {

        var product = ProductTestData.GenerateInvalidProduct();

        var result = product.Validate();

        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when product properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid product name")]
    public void Given_InvalidProductName_When_Validated_Then_ShouldReturnInvalid()
    {
        var product = ProductTestData.GenerateInvalidProductName();

        var result = product.Validate();

        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when product properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid product description")]
    public void Given_InvalidProductDescription_When_Validated_Then_ShouldReturnInvalid()
    {
        var product = ProductTestData.GenerateInvalidProductDescription();

        var result = product.Validate();

        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when product properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid product price")]
    public void Given_InvalidProductPrice_When_Validated_Then_ShouldReturnInvalid()
    {
        var product = ProductTestData.GenerateInvalidProductPrice();

        var result = product.Validate();

        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}
