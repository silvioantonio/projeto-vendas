using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// API request model for updating a sale
    /// </summary>
    public class UpdateSaleRequest
    {
        /// <summary>
        /// The unique identifier of the sale to update.
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// The sale number of the sale.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// The date that sale was created.
        /// </summary>
        public DateTime? SaleDate { get; set; }

        /// <summary>
        /// Customer ID attached to the sale.
        /// </summary>
        public Guid? CustomerId { get; set; }

        /// <summary>
        /// The total amount for the sale.
        /// </summary>
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// The sale items to update.
        /// </summary>
        public List<UpdateSaleItemRequest> Items { get; set; } = [];
    }
}