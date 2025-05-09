using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of IProductRepository using Entity Framework Core
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of ProductRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public ProductRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a product by name
        /// </summary>
        /// <param name="name">The name to search for</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product if found, null otherwise</returns>
        public async Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Name == name, cancellationToken);
        }

        /// <summary>
        /// Retrieves a product by their ids
        /// </summary>
        /// <param name="productIds">The ids to search for</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The id list if found, empty list otherwise</returns>
        public async Task<IEnumerable<Guid>> GetExistingProductIdsAsync(List<Guid> productIds, CancellationToken cancellationToken)
        {
            return await _context.Products.AsNoTracking().Where(p => productIds.Contains(p.Id)).Select(p => p.Id).ToListAsync(cancellationToken);
        }
    }
}
