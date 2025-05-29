using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    /// <summary>
    /// Event triggered when a new sale is created.
    /// </summary>
    public sealed class SaleCreatedEvent : IDomainEvent
    {
        /// <summary>
        /// Gets the unique identifier of the created sale.
        /// </summary>
        public Guid SaleId { get; }

        public SaleCreatedEvent(Guid saleId)
        {
            SaleId = saleId;
        }
    }
}
