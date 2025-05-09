using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// API response model for CreateSale operation
    /// </summary>
    public class CreateSaleResponse
    {
        /// <summary>
        /// The unique identifier of the created sale
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// The sale number of the sale.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;
        /// <summary>
        /// The date that sale was created.
        /// </summary>
        public DateTime SaleDate { get; set; }
        /// <summary>
        /// Customer ID attached to the sale.
        /// </summary>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Branch ID attached to the sale.
        /// </summary>
        public Guid BranchId { get; set; }
        /// <summary>
        /// The total amount for the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// The sale items.
        /// </summary>
        public List<SaleItem> Items { get; set; } = [];
    }
}
