using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of IBranchRepository using Entity Framework Core
    /// </summary>
    public class BranchRepository : IBranchRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of BranchRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public BranchRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Branch?> GetByIdAsync(Guid branchId, CancellationToken cancellationToken)
        {
            return await _context.Branchs.FirstOrDefaultAsync(o => o.Id == branchId, cancellationToken);
        }
    }
}
