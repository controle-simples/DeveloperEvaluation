using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    /// <summary>
    /// Event triggered when an individual item in a sale is cancelled.
    /// </summary>
    public sealed class ItemCancelledEvent : IDomainEvent
    {
        /// <summary>
        /// Gets the unique identifier of the product that was cancelled.
        /// </summary>
        public Guid ProductId { get; }

        public ItemCancelledEvent(Guid productId)
        {
            ProductId = productId;
        }
    }
}
