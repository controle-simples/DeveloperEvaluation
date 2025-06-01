using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of ISaleRepository using Entity Framework Core
    /// </summary>
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of SaleRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task AddAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc />
        public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<List<Sale>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Sales
                .Include(s => s.Items)
                .OrderByDescending(s => s.SaleDate)
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc />
        public async Task UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc />
        public async Task<PaginatedList<Sale>> GetPagedAsync(int page, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = _context.Sales.Include(s => s.Items).OrderByDescending(s => s.SaleDate);
            var totalItems = await query.CountAsync(cancellationToken);

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new PaginatedList<Sale>(items, totalItems, page, pageSize);
        }
    }
}
