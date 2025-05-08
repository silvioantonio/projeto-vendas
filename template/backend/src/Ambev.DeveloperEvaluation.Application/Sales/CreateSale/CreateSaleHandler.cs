using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Initializes a new instance of CreateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSaleCommand</param>
    public class CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        private readonly ISaleRepository _repository;

        public CreateSaleHandler(ISaleRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the CreateSaleCommand request
        /// </summary>
        /// <param name="command">The CreateSale command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale details</returns>
        public async Task Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = mapper.Map<Sale>(command);

            var createdSale = await saleRepository.CreateAsync(sale, cancellationToken);
            var result = mapper.Map<CreateSaleResult>(createdSale);
            return result;

            //var sale = new Sale
            //{
            //    Id = Guid.NewGuid(),
            //    SaleNumber = command.SaleNumber,
            //    SaleDate = command.SaleDate,
            //    CustomerId = command.Customer,
            //    TotalAmount = command.TotalAmount,
            //    BranchId = command.Branch,
            //    Items = command.Items.Select(i => new SaleItem
            //    {
            //        Id = Guid.NewGuid(),
            //        ProductId = i.Product,
            //        Quantity = i.Quantity,
            //        UnitPrice = i.UnitPrice,
            //        Discount = i.Discount,
            //        Total = i.Total
            //    }).ToList()
            //};

        }
    }
}
