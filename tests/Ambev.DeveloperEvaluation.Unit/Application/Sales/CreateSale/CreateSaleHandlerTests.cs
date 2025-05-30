using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.CreateSale
{
    public class CreateSaleHandlerTests
    {
        private readonly Mock<ISaleRepository> _saleRepositoryMock;
        private readonly CreateSaleHandler _handler;

        public CreateSaleHandlerTests()
        {
            _saleRepositoryMock = new Mock<ISaleRepository>();
            _handler = new CreateSaleHandler(_saleRepositoryMock.Object);
        }

        [Fact(DisplayName = "Should create sale and return result correctly")]
        public async Task Handle_ValidCommand_ShouldReturnResult()
        {
            // Arrange
            var command = CreateSaleHandlerTestData.GenerateValidCommand();

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotEqual(Guid.Empty, result.Id);
            Assert.True(result.TotalAmount > 0);

            _saleRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Sale>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Should throw exception for product with empty external ID")]
        public async Task Handle_InvalidProduct_ShouldThrowException()
        {
            // Arrange
            var command = CreateSaleHandlerTestData.GenerateInvalidProductCommand();

            // Act & Assert
            await Assert.ThrowsAsync<DomainException>(() =>
                _handler.Handle(command, CancellationToken.None)
            );

            _saleRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Sale>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact(DisplayName = "Should throw exception when product list is empty")]
        public async Task Handle_EmptyProductList_ShouldThrowException()
        {
            // Arrange
            var command = CreateSaleHandlerTestData.GenerateEmptyProductListCommand();

            // Validação já está no FluentValidation
            var validation = command.Validate();

            // Assert
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, e => e.PropertyName == "Products");
        }
    }
}
