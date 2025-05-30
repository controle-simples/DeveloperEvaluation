using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.DeleteSale
{
    public class DeleteSaleHandlerTests
    {
        private readonly Mock<ISaleRepository> _saleRepositoryMock;
        private readonly DeleteSaleHandler _handler;

        public DeleteSaleHandlerTests()
        {
            _saleRepositoryMock = new Mock<ISaleRepository>();
            _handler = new DeleteSaleHandler(_saleRepositoryMock.Object);
        }

        [Fact(DisplayName = "Should cancel sale and return confirmation")]
        public async Task Handle_ValidSale_ShouldCancelAndReturn()
        {
            // Arrange
            var sale = new Sale("CUST-001", "BRANCH-001");
            _saleRepositoryMock
                .Setup(repo => repo.GetByIdAsync(sale.Id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(sale);

            var command = new DeleteSaleCommand(sale.Id);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Cancelled);
            Assert.Equal(sale.Id, result.Id);

            _saleRepositoryMock.Verify(r => r.GetByIdAsync(sale.Id, It.IsAny<CancellationToken>()), Times.Once);
            _saleRepositoryMock.Verify(r => r.UpdateAsync(sale, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Should throw KeyNotFoundException when sale does not exist")]
        public async Task Handle_NonExistingSale_ShouldThrowException()
        {
            // Arrange
            var saleId = Guid.NewGuid();

            _saleRepositoryMock
                .Setup(repo => repo.GetByIdAsync(saleId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Sale?)null);

            var command = new DeleteSaleCommand(saleId);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                _handler.Handle(command, CancellationToken.None));

            _saleRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Sale>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
