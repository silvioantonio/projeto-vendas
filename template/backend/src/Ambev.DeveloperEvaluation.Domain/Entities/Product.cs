using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents an product.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets the products's full name.
        /// Must not be null or empty.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Gets the description of product.
        /// Must not be null or empty.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Gets the price of product.
        /// </summary>
        public decimal Price { get; set; }

        public Product() { }

        /// <summary>
        /// Performs validation of the product entity using the ProductValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}