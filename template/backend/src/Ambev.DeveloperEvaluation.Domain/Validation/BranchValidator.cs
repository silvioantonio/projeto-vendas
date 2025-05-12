using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class BranchValidator : AbstractValidator<Branch>
    {
        public BranchValidator()
        {
            RuleFor(branch => branch.Name)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Branch name must be at least 3 characters long.")
                .Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("Branch name must contain only letters.")
                .MaximumLength(50).WithMessage("Branch name cannot be longer than 50 characters.");

            RuleFor(branch => branch.Cnpj)
                .NotEmpty()
                .Matches(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$").WithMessage("CNPJ must be in the format XX.XXX.XXX/XXXX-XX.");
        }
    }
}