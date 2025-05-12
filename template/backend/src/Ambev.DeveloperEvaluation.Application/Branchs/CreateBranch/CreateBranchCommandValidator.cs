using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch
{
    /// <summary>
    /// Validator for CreateBranchCommand that defines validation rules for branch creation command.
    /// </summary>
    public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateBranchCommandValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Name: Required, must be between 3 and 50 characters
        /// - Cnpj: Required, must be valid CNPJ format (XX.XXX.XXX/XXXX-XX)
        /// </remarks>
        public CreateBranchCommandValidator()
        {
            RuleFor(branch => branch.Name).NotEmpty().Length(3, 50);
            RuleFor(branch => branch.Cnpj)
                .Matches(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$");
        }
    }
}
