using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    /// <summary>
    /// Handles the cancellation of a sale.
    /// </summary>
    public sealed class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResponse>
    {
        private readonly ISaleRepository _saleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelSaleHandler"/> class.
        /// </summary>
        /// <param name="saleRepository">Repository to retrieve and cancel the sale.</param>
        public CancelSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        /// <summary>
        /// Handles the cancellation of a sale by ID.
        /// </summary>
        /// <param name="request">Command containing the sale ID.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        public async Task<CancelSaleResponse> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Sale? sale = await _saleRepository.GetByIdAsync(request.SaleId, cancellationToken);
            if (sale is null)
                throw new KeyNotFoundException($"Sale with ID {request.SaleId} was not found.");

            sale.Cancel();
            await _saleRepository.UpdateAsync(sale, cancellationToken);

            return new CancelSaleResponse
            {
                Id = sale.Id,
                Cancelled = sale.Cancelled
            };
        }
    }
}
