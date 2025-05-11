using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides test data for the Product entity.
/// </summary>
internal static class ProductTestData
{
    /// <summary>
    /// Generates a valid Product instance for testing.
    /// </summary>
    /// <returns>A valid Product instance.</returns>
    public static Product GenerateValidProduct()
    {
        return new Product
        {
            Name = "TV 50' samsung",
            Description = "TV LCD.",
            Price = 4500.00m
        };
    }

    /// <summary>
    /// Generates an invalid Product instance for testing.
    /// </summary>
    /// <returns>An invalid Product instance.</returns>
    public static Product GenerateInvalidProduct()
    {
        return new Product
        {
            Name = "tv",
            Description = "tv",
            Price = 0.00m
        };
    }

    /// <summary>
    /// Generates an invalid name Product instance for testing.
    /// </summary>
    /// <returns>An invalid Product instance.</returns>
    public static Product GenerateInvalidProductName()
    {
        return new Product
        {
            Name = "tv",
            Description = "TV LCD.",
            Price = 5000.00m
        };
    }

    /// <summary>
    /// Generates an invalid description Product instance for testing.
    /// </summary>
    /// <returns>An invalid Product instance.</returns>
    public static Product GenerateInvalidProductDescription()
    {
        return new Product
        {
            Name = "TV 50' samsung",
            Description = "TV",
            Price = 4500.00m
        };
    }

    /// <summary>
    /// Generates an invalid price Product instance for testing.
    /// </summary>
    /// <returns>An invalid Product instance.</returns>
    public static Product GenerateInvalidProductPrice()
    {
        return new Product
        {
            Name = "TV 50' samsung",
            Description = "TV",
            Price = 0.00m
        };
    }
}
