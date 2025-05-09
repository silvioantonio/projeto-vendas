
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Product entity operations
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Creates a new product in the repository
        /// </summary>
        /// <param name="product">The product to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created product</returns>
        Task<Product> CreateAsync(Product product, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a product by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product if found, null otherwise</returns>
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a product by their name
        /// </summary>
        /// <param name="name">The identifier of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product if found, null otherwise</returns>
        Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a list of products by their unique identifier
        /// </summary>
        /// <param name="productIds">The list of unique productId</param>
        /// <returns>The list of ids if found, empty list otherwise</returns>
        Task<IEnumerable<Guid>> GetExistingProductIdsAsync(List<Guid> productIds, CancellationToken cancellationToken);
    }
}
