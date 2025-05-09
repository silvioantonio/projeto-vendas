
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Branch entity operations
    /// </summary>
    public interface IBranchRepository
    {
        /// <summary>
        /// Creates a new branch in the repository
        /// </summary>
        /// <param name="user">The branch to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created branch</returns>
        Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a branch by their cnpj
        /// </summary>
        /// <param name="cnpj">The document identifier of the branch</param>
        /// <returns>The branch if found, null otherwise</returns>
        Task<Branch?> GetByCnpjAsync(string cnpj, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a branch by their unique identifier
        /// </summary>
        /// <param name="branchId">The unique identifier of the branch</param>
        /// <returns>The branch if found, null otherwise</returns>
        Task<Branch?> GetByIdAsync(Guid branchId, CancellationToken cancellationToken);
    }
}
