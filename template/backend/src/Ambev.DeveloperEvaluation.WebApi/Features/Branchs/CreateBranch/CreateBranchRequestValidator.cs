using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch
{
    /// <summary>
    /// Validator for CreateBranchRequest that defines validation rules for branch creation.
    /// </summary>
    public class CreateBranchRequestValidator : AbstractValidator<CreateBranchRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateBranchRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Name: Required, length between 3 and 50 characters
        /// - Cnpj: Required, must match the format XX.XXX.XXX/XXXX-XX
        /// </remarks>
        public CreateBranchRequestValidator()
        {
            RuleFor(branch => branch.Name).NotEmpty().Length(3, 50).Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("The name os branch must be in a valid format");
            RuleFor(branch => branch.Cnpj).Matches(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$").WithMessage("The cnpj must be in format XX.XXX.XXX/XXXX-XX");
        }
    }
}
