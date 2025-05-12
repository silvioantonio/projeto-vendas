namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Represents a request to create a new sale in the system.
    /// </summary>
    public class CreateSaleRequest
    {
        /// <summary>
        /// Gets or sets the sale number of the sale to be created.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the date of the sale. Must be less or equal to the current date.
        /// </summary>
        public DateTime SaleDate { get; set; }
        /// <summary>
        /// Gets or sets the customer ID for the sale.
        /// </summary>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the branch ID for the sale.
        /// </summary>
        public Guid BranchId { get; set; }
        /// <summary>
        /// Gets or sets the total amount for the sale. Must be greater than or equal to 0.
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Gets or sets the items in the sale. Must not be empty.
        /// </summary>
        public List<CreateSaleItemRequest> Items { get; set; } = [];
    }
}
