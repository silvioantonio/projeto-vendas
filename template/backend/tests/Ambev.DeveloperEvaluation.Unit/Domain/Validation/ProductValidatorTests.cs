using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the ProductValidator class.
/// Tests cover validation of all product properties including name, description, and price.
/// </summary>
public class ProductValidatorTests
{
    private readonly ProductValidator _validator;

    public ProductValidatorTests()
    {
        _validator = new ProductValidator();
    }

    /// <summary>
    /// Tests that validation passes when all product properties are valid.
    /// </summary>
    [Fact(DisplayName = "Valid product should pass all validation rules")]
    public void Given_ValidProduct_When_Validated_Then_ShouldNotHaveErrors()
    {
        var product = ProductTestData.GenerateValidProduct();

        var result = _validator.TestValidate(product);

        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails for invalid product name formats.
    /// </summary>
    /// <param name="name">The invalid product name to test.</param>
    [Theory(DisplayName = "Invalid product name formats should fail validation")]
    [InlineData("")]
    [InlineData("ab")]
    public void Given_InvalidProductName_When_Validated_Then_ShouldHaveError(string name)
    {
        var product = ProductTestData.GenerateValidProduct();
        product.Name = name;

        var result = _validator.TestValidate(product);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    /// <summary>
    /// Tests that validation fails when product name exceeds maximum length.
    /// </summary>
    [Fact(DisplayName = "Product name longer than maximum length should fail validation")]
    public void Given_ProductNameLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        var product = ProductTestData.GenerateValidProduct();
        product.Name = new string('a', 51);

        var result = _validator.TestValidate(product);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    /// <summary>
    /// Tests that validation fails for invalid product description formats.
    /// </summary>
    /// <param name="description">The invalid product description to test.</param>
    [Theory(DisplayName = "Invalid product description formats should fail validation")]
    [InlineData("")]
    [InlineData("ab")]
    public void Given_InvalidProductDescription_When_Validated_Then_ShouldHaveError(string description)
    {
        var product = ProductTestData.GenerateValidProduct();
        product.Description = description;

        var result = _validator.TestValidate(product);

        result.ShouldHaveValidationErrorFor(x => x.Description);
    }

    /// <summary>
    /// Tests that validation fails when product description exceeds maximum length.
    /// </summary>
    [Fact(DisplayName = "Product description longer than maximum length should fail validation")]
    public void Given_ProductDescriptionLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        var product = ProductTestData.GenerateValidProduct();
        product.Description = new string('a', 301);

        var result = _validator.TestValidate(product);

        result.ShouldHaveValidationErrorFor(x => x.Description);
    }

    /// <summary>
    /// Tests that validation fails when product price is negative.
    /// </summary>
    [Fact(DisplayName = "Negative product price should fail validation")]
    public void Given_NegativeProductPrice_When_Validated_Then_ShouldHaveError()
    {
        var product = ProductTestData.GenerateValidProduct();
        product.Price = -1.00m;

        var result = _validator.TestValidate(product);

        result.ShouldHaveValidationErrorFor(x => x.Price);
    }
}