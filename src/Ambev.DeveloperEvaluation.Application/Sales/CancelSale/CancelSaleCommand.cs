using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    /// <summary>
    /// Command to request the cancellation of a sale.
    /// </summary>
    /// <param name="SaleId">The ID of the sale to cancel.</param>
    public sealed record CancelSaleCommand(Guid SaleId) : IRequest<CancelSaleResponse>;
}
