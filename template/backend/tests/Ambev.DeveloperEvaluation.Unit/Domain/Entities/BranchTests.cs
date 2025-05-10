using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Branch entity class.
/// Tests cover validation scenarios.
/// </summary>
public class BranchTests
{
    /// <summary>
    /// Tests that validation passes when all branch properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid branch data")]
    public void Given_ValidBranchData_When_Validated_Then_ShouldReturnValid()
    {
        var branch = BranchTestData.GenerateValidBranch();

        var result = branch.Validate();

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when branch properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid branch data")]
    public void Given_InvalidBranchData_When_Validated_Then_ShouldReturnInvalid()
    {
        var branch = BranchTestData.GenerateInvalidBranch();

        var result = branch.Validate();

        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when branch name is invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid branch name")]
    public void Given_InvalidBranchName_When_Validated_Then_ShouldReturnInvalid()
    {
        var branch = BranchTestData.GenerateInvalidBranchName();

        var result = branch.Validate();

        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when branch CNPJ is invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid branch CNPJ")]
    public void Given_InvalidBranchCnpj_When_Validated_Then_ShouldReturnInvalid()
    {
        var branch = BranchTestData.GenerateInvalidBranchCnpj();

        var result = branch.Validate();

        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that validation passes for a parent branch.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for a valid parent branch")]
    public void Given_ValidParentBranch_When_Validated_Then_ShouldReturnValid()
    {
        var branch = BranchTestData.GenerateValidParentBranch();

        var result = branch.Validate();

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }
}
