using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Events
{
    /// <summary>
    /// Represents a message being sent to a simulated queue.
    /// </summary>
    public sealed class QueueMessageEvent : INotification
    {
        /// <summary>
        /// The message content to be published.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// The name of the queue where the message would be published.
        /// </summary>
        public string QueueName { get; }

        /// <summary>
        /// Timestamp of the event creation.
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// Creates a new instance of the QueueMessageEvent.
        /// </summary>
        public QueueMessageEvent(string message, string queueName)
        {
            Message = message;
            QueueName = queueName;
            Timestamp = DateTime.UtcNow;
        }
    }
}
