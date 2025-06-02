using Ambev.DeveloperEvaluation.Application.Events;
using Ambev.DeveloperEvaluation.Application.Events.Handlers;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Events.Handlers
{
    public class QueueMessageEventHandlerTests
    {
        [Fact]
        public async Task Handle_Should_LogQueueMessageCorrectly()
        {
            // Arrange
            var logger = Substitute.For<ILogger<QueueMessageEventHandler>>();
            var handler = new QueueMessageEventHandler(logger);

            var evt = new QueueMessageEvent(
                message: "Unit test message",
                queueName: "sales.unit.test"
            );

            // Act
            await handler.Handle(evt, CancellationToken.None);

            // Assert
            logger.Received().Log(
                LogLevel.Information,
                Arg.Any<EventId>(),
                Arg.Is<object>(state =>
                    state.ToString()!.Contains("Queue: sales.unit.test") &&
                    state.ToString()!.Contains("Message: Unit test message")
                ),
                null,
                Arg.Any<Func<object, Exception?, string>>()
            );
        }
    }
}
