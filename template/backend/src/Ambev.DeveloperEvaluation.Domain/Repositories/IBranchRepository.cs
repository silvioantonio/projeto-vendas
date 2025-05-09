
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Branch entity operations
    /// </summary>
    public interface IBranchRepository
    {
        /// <summary>
        /// Retrieves a bramch by their unique identifier
        /// </summary>
        /// <param name="branchId">The unique identifier of the branch</param>
        /// <returns>The branch if found, null otherwise</returns>
        Task<Branch?> GetByIdAsync(Guid branchId, CancellationToken cancellationToken);
    }
}
