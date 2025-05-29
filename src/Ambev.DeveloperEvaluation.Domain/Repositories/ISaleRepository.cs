using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{

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
    }
}
