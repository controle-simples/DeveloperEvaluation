using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Contract for sale persistence and retrieval operations.
/// Implements the repository pattern for the Sale aggregate.
/// </summary>
public interface ISaleRepository
{
    /// <summary>
    /// Adds a new sale to the repository.
    /// </summary>
    Task AddAsync(Sale sale, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a sale by its unique identifier.
    /// </summary>
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all sales in the system.
    /// </summary>
    Task<List<Sale>> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing sale in the repository.
    /// Used for operations such as cancelling a sale.
    /// </summary>
    Task UpdateAsync(Sale sale, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a paginated list of sales from the data source.
    /// </summary>
    /// <param name="page">The page number to retrieve (1-based).</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<PaginatedList<Sale>> GetPagedAsync(int page, int pageSize, CancellationToken cancellationToken = default);

}
