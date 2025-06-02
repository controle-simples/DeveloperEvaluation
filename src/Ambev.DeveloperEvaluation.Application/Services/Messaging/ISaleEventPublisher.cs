namespace Ambev.DeveloperEvaluation.Application.Services.Messaging
{
    /// <summary>
    /// Defines contract for publishing sale-related events (e.g., SaleCreated, SaleCancelled).
    /// Allows for abstraction of the messaging mechanism.
    /// </summary>
    public interface ISaleEventPublisher
    {
        /// <summary>
        /// Publishes a simulated SaleCreated event.
        /// </summary>
        Task PublishSaleCreatedAsync(Guid saleId);

        /// <summary>
        /// Publishes a simulated SaleCancelled event.
        /// </summary>
        Task PublishSaleCancelledAsync(Guid saleId);
    }
}
