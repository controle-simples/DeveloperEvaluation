using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Bogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration.Sales.CreateSale;

public class CreateSaleIntegrationTests
{
    private readonly Faker _faker = new();

    [Fact(DisplayName = "Should persist sale in PostgreSQL database")]
    public async Task Should_Persist_Sale_In_Postgres()
    {
        // Arrange
        var connectionString = "Host=localhost;Port=5433;Database=developer_eval;Username=ambev;Password=dev2025";

        var options = new DbContextOptionsBuilder<DefaultContext>()
            .UseNpgsql(connectionString)
            .Options;

        await using var context = new DefaultContext(options);
        await context.Database.EnsureCreatedAsync(); 

        var repository = new SaleRepository(context);
        var handler = new CreateSaleHandler(repository);

        var command = new CreateSaleCommand
        {
            CustomerExternalId = Guid.NewGuid().ToString(),
            BranchExternalId = Guid.NewGuid().ToString(),
            Products = new List<CreateSaleProductItem>
        {
            new() { ProductExternalId = "prod-01", Quantity = 5, UnitPrice = 10m },
            new() { ProductExternalId = "prod-02", Quantity = 2, UnitPrice = 15m },
            new() { ProductExternalId = "prod-03", Quantity = 1, UnitPrice = 20m }
        }
        };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        var saleInDb = await context.Sales
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.Id == result.Id);

        saleInDb.Should().NotBeNull();
        saleInDb!.Items.Count.Should().Be(3);
        saleInDb.TotalAmount.Should().Be(95m);
    }

}
