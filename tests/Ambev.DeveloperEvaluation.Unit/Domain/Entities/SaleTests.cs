using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class SaleTests
{
    private readonly Faker _faker = new();

    [Theory(DisplayName = "Should throw DomainException when quantity is invalid")]
    [InlineData(0)]
    [InlineData(25)]
    public void Should_Throw_DomainException_When_Quantity_Is_Invalid(int quantity)
    {
        // Arrange
        var customerId = _faker.Random.Guid().ToString();
        var branchId = _faker.Random.Guid().ToString();
        var productId = _faker.Commerce.Ean8();

        var act = () =>
        {
            var sale = new Sale(customerId, branchId);
            sale.AddItem(productId, quantity, 10m);
        };

        // Assert
        act.Should().Throw<DomainException>();
    }

    [Fact(DisplayName = "Should throw DomainException when sale has less than three items")]
    public void Should_Return_DomainException_When_Less_Than_Three_Items()
    {
        // Arrange
        var sale = new Sale(_faker.Random.Guid().ToString(), _faker.Random.Guid().ToString());
        sale.AddItem("prod-01", 5, 10m);
        sale.AddItem("prod-02", 3, 15m);

        // Act
        var act = () => sale.ValidateBusinessRules();

        // Assert
        var exception = act.Should().Throw<DomainException>().Which;
        exception.Message.Should().Be("A sale must contain at least 3 items.");
    }

    [Fact(DisplayName = "Should create a valid sale when all business rules are respected")]
    public void Should_Create_Sale_When_Data_Is_Valid()
    {
        // Arrange
        var customerId = _faker.Random.Guid().ToString();
        var branchId = _faker.Random.Guid().ToString();
        var sale = new Sale(customerId, branchId);

        sale.AddItem("prod-01", 5, 10m);   // 45 (10% desconto)
        sale.AddItem("prod-02", 2, 15m);   // 30
        sale.AddItem("prod-03", 1, 20m);   // 20

        // Act
        var act = () => sale.ValidateBusinessRules();

        // Assert
        act.Should().NotThrow();
        sale.Items.Count.Should().Be(3);
        sale.TotalAmount.Should().Be(95.00m);
    }

}
