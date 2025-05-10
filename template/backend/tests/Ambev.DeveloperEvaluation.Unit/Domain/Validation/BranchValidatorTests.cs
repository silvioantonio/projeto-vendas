using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the BranchValidator class.
/// Tests cover validation of all branch properties including name and CNPJ requirements.
/// </summary>
public class BranchValidatorTests
{
    private readonly BranchValidator _validator;

    public BranchValidatorTests()
    {
        _validator = new BranchValidator();
    }

    /// <summary>
    /// Tests that validation passes when all branch properties are valid.
    /// </summary>
    [Fact(DisplayName = "Valid branch should pass all validation rules")]
    public void Given_ValidBranch_When_Validated_Then_ShouldNotHaveErrors()
    {
        var branch = BranchTestData.GenerateValidBranch();

        var result = _validator.TestValidate(branch);

        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails for invalid branch name formats.
    /// This test verifies that names that are:
    /// - Empty strings
    /// - Less than 3 characters
    /// fail validation with appropriate error messages.
    /// </summary>
    /// <param name="name">The invalid branch name to test.</param>
    [Theory(DisplayName = "Invalid branch name formats should fail validation")]
    [InlineData("")]
    [InlineData("ab")]
    public void Given_InvalidBranchName_When_Validated_Then_ShouldHaveError(string name)
    {
        var branch = BranchTestData.GenerateValidBranch();
        branch.Name = name;

        var result = _validator.TestValidate(branch);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    /// <summary>
    /// Tests that validation fails when branch name exceeds maximum length.
    /// </summary>
    [Fact(DisplayName = "Branch name longer than maximum length should fail validation")]
    public void Given_BranchNameLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        var branch = BranchTestData.GenerateValidBranch();
        branch.Name = new string('a', 51);

        var result = _validator.TestValidate(branch);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    /// <summary>
    /// Tests that validation fails for invalid CNPJ formats.
    /// This test verifies that CNPJs that:
    /// - Don't follow the standard format (XX.XXX.XXX/XXXX-XX)
    /// - Are empty
    /// fail validation with appropriate error messages.
    /// </summary>
    /// <param name="cnpj">The invalid CNPJ to test.</param>
    [Theory(DisplayName = "Invalid CNPJ formats should fail validation")]
    [InlineData("")]
    [InlineData("12345678901234")]
    [InlineData("120.345.678/9012-34")]
    [InlineData("1a.345.678/9012-34")]
    public void Given_InvalidCnpj_When_Validated_Then_ShouldHaveError(string cnpj)
    {
        var branch = BranchTestData.GenerateValidBranch();
        branch.Cnpj = cnpj;

        var result = _validator.TestValidate(branch);

        result.ShouldHaveValidationErrorFor(x => x.Cnpj);
    }
}
