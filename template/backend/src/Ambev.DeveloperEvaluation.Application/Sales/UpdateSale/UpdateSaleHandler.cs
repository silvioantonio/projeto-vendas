using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IUserRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateSaleCommandHandler(
            ISaleRepository saleRepository,
            IUserRepository customerRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _saleRepository = saleRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var existingSale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);

            if (existingSale == null)
            {
                throw new KeyNotFoundException($"Sale with ID {request.Id} not found");
            }

            if (existingSale.SaleNumber != request.SaleNumber)
            {
                var conflictingSale = await _saleRepository.GetBySaleNumberAsync(request.SaleNumber, cancellationToken);
                if (conflictingSale != null && !conflictingSale.Cancelled && conflictingSale.Id != existingSale.Id)
                {
                    throw new InvalidOperationException($"Sale with SaleNumber '{request.SaleNumber}' already exists and is active.");
                }
            }

            if (existingSale.CustomerId != request.CustomerId)
            {
                var customer = await _customerRepository.GetByIdAsync(request.CustomerId, cancellationToken);
                if (customer == null || customer.Status != Domain.Enums.UserStatus.Active)
                {
                    throw new InvalidOperationException($"Customer with ID '{request.CustomerId}' does not exist or is not active.");
                }
            }

            foreach (var updatedItem in request.Items)
            {
                var product = await _productRepository.GetByIdAsync(updatedItem.ProductId, cancellationToken);
                if (product == null)
                {
                    throw new InvalidOperationException($"Product with ID '{updatedItem.ProductId}' not found.");
                }
            }

            existingSale.SaleNumber = request.SaleNumber;
            existingSale.SaleDate = request.SaleDate;
            existingSale.CustomerId = request.CustomerId;
            existingSale.TotalAmount = request.TotalAmount;

            UpdateSaleItems(existingSale, request.Items, cancellationToken);

            decimal calculatedTotalAmount = existingSale.Items.Sum(item => item.Total);
            if (calculatedTotalAmount != request.TotalAmount)
            {
                throw new InvalidOperationException($"Total Amount '{request.TotalAmount}' does not match the sum of the items '{calculatedTotalAmount}'.");
            }

            await _saleRepository.UpdateAsync(existingSale, cancellationToken);

            return _mapper.Map<UpdateSaleResult>(existingSale);
        }

        private void UpdateSaleItems(Sale existingSale, List<SaleItem> updatedItems, CancellationToken cancellationToken)
        {
            existingSale.Items.RemoveAll(item => !updatedItems.Any(updatedItem => updatedItem.Id == item.Id));

            foreach (var updatedItem in updatedItems)
            {
                var existingItem = existingSale.Items.FirstOrDefault(item => item.Id == updatedItem.Id);

                if (existingItem != null)
                {
                    existingItem.ProductId = updatedItem.ProductId;
                    existingItem.Quantity = updatedItem.Quantity;
                    existingItem.UnitPrice = updatedItem.UnitPrice;

                    existingItem.ApplyDiscount();
                    existingItem.TotalCalculation();
                }
                else
                {
                    var newItem = _mapper.Map<SaleItem>(updatedItem);
                    newItem.SaleId = existingSale.Id;

                    newItem.ApplyDiscount();
                    newItem.TotalCalculation();

                    existingSale.Items.Add(newItem);
                }
            }
        }
    }
}
