using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// Represents an item to be updated within a sale.
    /// </summary>
    public class UpdateSaleItemRequest
    {
        /// <summary>
        /// The unique identifier of the sale item.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Product ID of the item.
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Quantity of the item.
        /// </summary>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Unit price of the item.
        /// </summary>
        [Required]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Discount applied to the item.
        /// </summary>
        public decimal Discount { get; set; }
    }
}
