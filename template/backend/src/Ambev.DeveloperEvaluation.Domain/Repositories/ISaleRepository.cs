using Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Repository interface for Sale entity operations
/// </summary>
public interface ISaleRepository
{
    /// <summary>
    /// Retrieves a sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <returns>The sale if found, null otherwise</returns>
    Task<Sale> GetByIdAsync(Guid id);
    /// <summary>
    /// Retrieves a list of sale.
    /// </summary>
    /// <param name="page">The of page to get a list os sales</param>
    /// <param name="itensPage">The of itens per page to get a list os sales</param>
    /// <returns>The list of sale if found, empty otherwise</returns>
    Task<IEnumerable<Sale>> GetAllAsync(int page, int itensPage);
    /// <summary>
    /// Creates a new sale in the repository
    /// </summary>
    /// <param name="sale">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);
    /// <summary>
    /// Update a sale from repository
    /// </summary>
    /// <param name="sale">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated sale</returns>
    Task UpdateAsync(Sale sale, CancellationToken cancellationToken = default);
    /// <summary>
    /// Delete a sale from repository
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
