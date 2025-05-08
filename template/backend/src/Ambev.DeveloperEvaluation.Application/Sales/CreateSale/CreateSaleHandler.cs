using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Initializes a new instance of CreateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSaleCommand</param>
    public class CreateSaleHandler(ISaleRepository saleRepository, IUserRepository userRepository, IMapper mapper) : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {

        /// <summary>
        /// Handles the CreateSaleCommand request
        /// </summary>
        /// <param name="command">The CreateSale command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale details</returns>
        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingUser = await userRepository.GetByIdAsync(command.CustomerId, cancellationToken) ?? throw new InvalidOperationException($"User with ID {command.CustomerId} does not exist");
            
            var existingBranch = await userRepository.GetByIdAsync(command.BranchId, cancellationToken) ?? throw new InvalidOperationException($"Branch with ID {command.BranchId} does not exist");
            
            if (command.Items == null || command.Items.Count == 0)
                throw new InvalidOperationException("Sale must have at least one item.");

            foreach (var item in command.Items)
            {
                //TODO: Validar se id do produto existe no banco de dados.
                if (item.ProductId == Guid.Empty)
                    throw new InvalidOperationException("Product ID cannot be empty.");
                if (item.Quantity <= 0 || item.Quantity > 20)
                    throw new InvalidOperationException("Quantity must be between 1 and 20.");
                if (item.UnitPrice < 0)
                    throw new InvalidOperationException("Unit price must be greater than or equal to 0.");

                item.ApplyDiscount();
                item.Total = item.TotalCalculation();
            }

            var calculatedTotal = command.Items.Sum(item => item.Total);
            if (command.TotalAmount != calculatedTotal)
                throw new InvalidOperationException("Total amount is inconsistent with the sum of item totals.");

            var sale = mapper.Map<Sale>(command);

            var createdSale = await saleRepository.CreateAsync(sale, cancellationToken);
            var result = mapper.Map<CreateSaleResult>(createdSale);
            return result;
        }
    }
}
