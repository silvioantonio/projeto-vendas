using Ambev.DeveloperEvaluation.Domain.Entities;
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
    public class CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper) : IRequestHandler<CreateSaleCommand, CreateSaleResult>
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

            var sale = mapper.Map<Sale>(command);

            var createdSale = await saleRepository.CreateAsync(sale, cancellationToken);
            var result = mapper.Map<CreateSaleResult>(createdSale);
            return result;
        }
    }
}
