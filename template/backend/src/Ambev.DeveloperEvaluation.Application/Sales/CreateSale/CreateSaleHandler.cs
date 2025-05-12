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
    public class CreateSaleHandler(ISaleRepository saleRepository, IUserRepository userRepository, IBranchRepository branchRepository, IProductRepository productRepository, IMapper mapper) : IRequestHandler<CreateSaleCommand, CreateSaleResult>
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

            var existingSale = await saleRepository.GetBySaleNumberAsync(command.SaleNumber, cancellationToken) ?? throw new InvalidOperationException($"SaleNumber {command.SaleNumber} already exists.");

            var existingUser = await userRepository.GetByIdAsync(command.CustomerId, cancellationToken) ?? throw new InvalidOperationException($"User with ID {command.CustomerId} does not exist");
            
            var existingBranch = await branchRepository.GetByIdAsync(command.BranchId, cancellationToken) ?? throw new InvalidOperationException($"Branch with ID {command.BranchId} does not exist");
            
            if (command.Items == null || command.Items.Count == 0)
                throw new InvalidOperationException("Sale must have at least one item.");

            var productIds = command.Items.Select(item => item.ProductId).Distinct().ToList();
            var existingProductIds = await productRepository.GetExistingProductIdsAsync(productIds, cancellationToken);

            var invalidProductIds = productIds.Except(existingProductIds).ToList();

            if (invalidProductIds.Count != 0)
            {
                throw new InvalidOperationException($"The following Product IDs do not exist: {string.Join(", ", invalidProductIds)}");
            }

            foreach (var item in command.Items)
            {
                item.Validate();
                item.ApplyDiscount();
                item.TotalCalculation();
            }

            var calculatedTotal = command.Items.Sum(item => item.Total);
            if (command.TotalAmount != calculatedTotal)
                throw new InvalidOperationException("Total amount is inconsistent with the sum of item totals.");

            var sale = mapper.Map<Sale>(command);
            sale.CustomerName = existingUser.Username;
            sale.BranchName = existingBranch.Name;

            var createdSale = await saleRepository.CreateAsync(sale, cancellationToken);
            var result = mapper.Map<CreateSaleResult>(createdSale);
            return result;
        }
    }
}
