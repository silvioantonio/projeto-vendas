namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    public class CreateProductResponse
    {
        /// <summary>
        /// The unique identifier of the created product
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The products's name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// The description of product.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// The price of product.
        /// </summary>
        public decimal Price { get; set; }
    }
}
