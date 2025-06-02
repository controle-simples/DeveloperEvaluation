using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Functional.Application.Sales.TestData;

/// <summary>
/// Provides test data for functional tests of SaleAppService.
/// </summary>
public static class SaleAppServiceTestData
{
    private static readonly Faker faker = new();

    /// <summary>
    /// Generates a valid CreateSaleCommand for testing.
    /// </summary>
    public static CreateSaleCommand GenerateValidCommand()
    {
        return new CreateSaleCommand
        {
            CustomerExternalId = faker.Random.Guid().ToString(),
            BranchExternalId = faker.Random.Guid().ToString(),
            Products = new List<CreateSaleProductItem>
            {
                new()
                {
                    ProductExternalId = faker.Commerce.Ean13(),
                    Quantity = 5,
                    UnitPrice = 100
                }
            }
        };
    }
}
