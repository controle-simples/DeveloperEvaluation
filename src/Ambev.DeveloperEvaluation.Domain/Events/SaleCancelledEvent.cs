using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    /// <summary>
    /// Event triggered when a sale is cancelled.
    /// </summary>
    public sealed class SaleCancelledEvent : IDomainEvent
    {
        /// <summary>
        /// Gets the unique identifier of the cancelled sale.
        /// </summary>
        public Guid SaleId { get; }

        public SaleCancelledEvent(Guid saleId)
        {
            SaleId = saleId;
        }
    }
}
