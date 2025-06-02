using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Events.Handlers
{
    /// <summary>
    /// Handles queue message events by logging the information to simulate a messaging system.
    /// </summary>
    public sealed class QueueMessageEventHandler : INotificationHandler<QueueMessageEvent>
    {
        private readonly ILogger<QueueMessageEventHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the QueueMessageEventHandler.
        /// </summary>
        public QueueMessageEventHandler(ILogger<QueueMessageEventHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles the simulated queue message event.
        /// </summary>
        public Task Handle(QueueMessageEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "[Queue Simulated] -> Queue: {Queue}, Message: {Message}, Timestamp: {Timestamp}",
                notification.QueueName,
                notification.Message,
                notification.Timestamp);

            return Task.CompletedTask;
        }
    }
}
