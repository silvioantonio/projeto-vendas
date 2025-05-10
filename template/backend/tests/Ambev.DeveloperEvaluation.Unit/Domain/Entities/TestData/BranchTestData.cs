using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides test data for the Branch entity.
/// </summary>
internal static class BranchTestData
{
    /// <summary>
    /// Generates a valid Branch instance for testing.
    /// </summary>
    /// <returns>A valid Branch instance.</returns>
    public static Branch GenerateValidBranch()
    {
        return new Branch
        {
            Name = "Valid Branch Name",
            Cnpj = "98.765.432/0001-99",
            IsParent = false
        };
    }

    /// <summary>
    /// Generates an invalid Branch instance for testing.
    /// </summary>
    /// <returns>An invalid Branch instance.</returns>
    public static Branch GenerateInvalidBranch()
    {
        return new Branch
        {
            Name = "",
            Cnpj = "",
            IsParent = false
        };
    }

    /// <summary>
    /// Generates a Branch instance with an invalid name for testing.
    /// </summary>
    /// <returns>A Branch instance with an invalid name.</returns>
    public static Branch GenerateInvalidBranchName()
    {
        return new Branch
        {
            Name = "",
            Cnpj = "12345678000195",
            IsParent = false
        };
    }

    /// <summary>
    /// Generates a Branch instance with an invalid CNPJ for testing.
    /// </summary>
    /// <returns>A Branch instance with an invalid CNPJ.</returns>
    public static Branch GenerateInvalidBranchCnpj()
    {
        return new Branch
        {
            Name = "Valid Branch Name",
            Cnpj = "invalid-cnpj",
            IsParent = false
        };
    }

    /// <summary>
    /// Generates a valid parent Branch instance for testing.
    /// </summary>
    /// <returns>A valid parent Branch instance.</returns>
    public static Branch GenerateValidParentBranch()
    {
        return new Branch
        {
            Name = "Parent Branch",
            Cnpj = "98.765.432/0001-99",
            IsParent = true
        };
    }
}
