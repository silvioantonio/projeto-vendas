using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// API response model for CreateSale operation
    /// </summary>
    public class CreateSaleResponse
    {
        /// <summary>
        /// Get or Set The unique identifier of the created sale
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Get or Set The sale number of the sale.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;
        /// <summary>
        /// Get or Set The date that sale was created.
        /// </summary>
        public DateTime SaleDate { get; set; }
        /// <summary>
        /// Get or Set Customer ID attached to the sale.
        /// </summary>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Get or Set Branch ID attached to the sale.
        /// </summary>
        public Guid BranchId { get; set; }
        /// <summary>
        /// Get or Set The total amount for the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Get or Set The sale items.
        /// </summary>
        public List<CreateSaleItemResponse> Items { get; set; } = [];
    }
}
