using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.CreateSale;

/// <summary>
/// Generates test data for CreateSaleHandler tests using the Bogus library.
/// </summary>
public static class CreateSaleHandlerTestData
{
    private static readonly Faker faker = new();

    /// <summary>
    /// Generates a valid CreateSaleCommand.
    /// </summary>
    public static CreateSaleCommand GenerateValidCommand()
    {
        return new CreateSaleCommand
        {
            CustomerExternalId = "customer-123",
            BranchExternalId = "branch-123",
            Products = new List<CreateSaleProductItem>
            {
                new() { ProductExternalId = "product-1", Quantity = 5, UnitPrice = 10m }, // 45
                new() { ProductExternalId = "product-2", Quantity = 2, UnitPrice = 15m }, // 30
                new() { ProductExternalId = "product-3", Quantity = 1, UnitPrice = 20m }  // 20
            }
        };
    }

    /// <summary>
    /// Generates a command with invalid product (missing ProductExternalId).
    /// </summary>
    public static CreateSaleCommand GenerateInvalidProductCommand()
    {
        return new CreateSaleCommand
        {
            CustomerExternalId = faker.Random.Guid().ToString(),
            BranchExternalId = faker.Random.Guid().ToString(),
            Products = new List<CreateSaleProductItem>
            {
                new() { ProductExternalId = "", Quantity = 1, UnitPrice = 50 }
            }
        };
    }

    /// <summary>
    /// Generates a command with no products.
    /// </summary>
    public static CreateSaleCommand GenerateEmptyProductListCommand()
    {
        return new CreateSaleCommand
        {
            CustomerExternalId = faker.Random.Guid().ToString(),
            BranchExternalId = faker.Random.Guid().ToString(),
            Products = new List<CreateSaleProductItem>() // nothing 
        };
    }
}
