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
            CustomerExternalId = faker.Random.Guid().ToString(),
            BranchExternalId = faker.Random.Guid().ToString(),
            Products = new List<CreateSaleProductItem>
            {
                new() { ProductExternalId = faker.Commerce.Ean13(), Quantity = 5, UnitPrice = 100 },
                new() { ProductExternalId = faker.Commerce.Ean13(), Quantity = 3, UnitPrice = 50 }
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
