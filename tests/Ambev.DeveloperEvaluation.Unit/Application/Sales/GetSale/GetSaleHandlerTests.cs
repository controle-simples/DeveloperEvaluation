using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.GetSale
{
    public class GetSaleHandlerTests
    {
        private readonly Mock<ISaleRepository> _saleRepositoryMock;
        private readonly IMapper _mapper;
        private readonly GetSaleHandler _handler;

        public GetSaleHandlerTests()
        {
            _saleRepositoryMock = new Mock<ISaleRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GetSaleProfile>();
            });

            _mapper = config.CreateMapper();
            _handler = new GetSaleHandler(_saleRepositoryMock.Object, _mapper);
        }

        [Fact(DisplayName = "Should return sale when ID exists")]
        public async Task Handle_ExistingId_ShouldReturnSale()
        {
            // Arrange
            var sale = new Sale("CUST-001", "BRANCH-001");
            sale.AddItem("PROD-01", 5, 100);

            _saleRepositoryMock
                .Setup(repo => repo.GetByIdAsync(sale.Id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(sale);

            var command = new GetSaleCommand(sale.Id);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(sale.Id, result.Id);
            Assert.Equal("CUST-001", result.CustomerExternalId);
            Assert.Single(result.Items);
            _saleRepositoryMock.Verify(x => x.GetByIdAsync(sale.Id, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Should throw KeyNotFoundException when ID does not exist")]
        public async Task Handle_NonExistentId_ShouldThrow()
        {
            // Arrange
            var id = Guid.NewGuid();

            _saleRepositoryMock
                .Setup(repo => repo.GetByIdAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Sale?)null);

            var command = new GetSaleCommand(id);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                _handler.Handle(command, CancellationToken.None)
            );
        }
    }
}
