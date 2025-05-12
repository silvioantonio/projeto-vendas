using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a branch.
    /// </summary>
    public class Branch : BaseEntity
    {
        /// <summary>
        /// Gets the branch name.
        /// Must not be null or empty.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets the branch cnpj.
        /// Must not be null or empty.
        /// </summary>
        public string Cnpj { get; set; } = string.Empty;

        /// <summary>
        /// indicates if it is parent branch.
        /// </summary>
        public bool IsParent { get; set; } = false;

        /// <summary>
        /// Performs validation of the Branch entity using the BranchValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        public ValidationResultDetail Validate()
        {
            var validator = new BranchValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}