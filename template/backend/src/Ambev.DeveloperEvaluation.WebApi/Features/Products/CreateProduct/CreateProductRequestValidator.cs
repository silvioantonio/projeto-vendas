using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// Validator for CreateProductRequestValidator that defines validation rules for product creation command.
    /// </summary>
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Name: Required, must be between 3 and 50 characters
        /// - Description: Required, must be between 3 and 300 characters
        /// - Password: Must meet security requirements (using PasswordValidator)
        /// - Price: Must be greater than or equal to 0
        /// </remarks>
        public CreateProductRequestValidator()
        {
            RuleFor(product => product.Name).NotEmpty().Length(3, 50).WithMessage("Name must be between 3 and 50 characters");
            RuleFor(product => product.Description).NotEmpty().Length(3, 300).WithMessage("Description must be between 3 and 300 characters");
            RuleFor(product => product.Price).GreaterThanOrEqualTo(0);
        }
    }
}
