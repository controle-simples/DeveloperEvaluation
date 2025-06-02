using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Services.Messaging
{
    /// <summary>
    /// Simulates publishing sale-related events to a messaging system via application logs.
    /// </summary>
    public sealed class FakeSaleEventPublisher : ISaleEventPublisher
    {
        private readonly ILogger<FakeSaleEventPublisher> _logger;

        /// <summary>
        /// Initializes a new instance of the FakeSaleEventPublisher.
        /// </summary>
        public FakeSaleEventPublisher(ILogger<FakeSaleEventPublisher> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        public Task PublishSaleCreatedAsync(Guid saleId)
        {
            _logger.LogInformation("[Queue Simulated] - Event: SaleCreated, SaleId: {SaleId}", saleId);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task PublishSaleCancelledAsync(Guid saleId)
        {
            _logger.LogInformation("[Queue Simulated] - Event: SaleCancelled, SaleId: {SaleId}", saleId);
            return Task.CompletedTask;
        }
    }
}
