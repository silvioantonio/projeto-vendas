﻿namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    /// <summary>
    /// Represents the response returned after successfully creating a new product.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of the newly created product,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class CreateProductResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created product.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created product in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the products's full name.
        /// Must not be null or empty.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the description of product.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the price of product.
        /// </summary>
        public decimal Price { get; set; }
    }
}
