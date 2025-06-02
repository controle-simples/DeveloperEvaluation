namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    /// <summary>
    /// Represents the response after cancelling a sale.
    /// </summary>
    public sealed class CancelSaleResponse
    {
        /// <summary>
        /// The ID of the cancelled sale.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Indicates whether the sale was successfully cancelled.
        /// </summary>
        public bool Cancelled { get; init; }
    }
}
