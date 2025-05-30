using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating SaleItem test data using the Bogus library.
/// </summary>
public static class SaleItemTestData
{
    private static readonly Faker faker = new();

    public static SaleItem CreateItemWithoutDiscount()
    {
        return SaleItem.Create(GenerateValidProductExternalId(), 2, 100);
    }

    public static SaleItem CreateItemWith10PercentDiscount()
    {
        return SaleItem.Create(GenerateValidProductExternalId(), 5, 200);
    }

    public static SaleItem CreateItemWith20PercentDiscount()
    {
        return SaleItem.Create(GenerateValidProductExternalId(), 15, 50);
    }

    public static int GenerateInvalidQuantity() => faker.Random.Int(21, 100);

    public static int GenerateValidQuantity() => faker.Random.Int(1, 20);

    public static decimal GenerateValidUnitPrice() => faker.Random.Decimal(10, 500);

    public static decimal GenerateInvalidUnitPrice() => faker.Random.Decimal(-100, 0);

    /// <summary>
    /// Generates a valid external product identifier.
    /// </summary>
    public static string GenerateValidProductExternalId() => faker.Commerce.Ean13();

    /// <summary>
    /// Generates an invalid product external ID (null or empty).
    /// </summary>
    public static string GenerateInvalidProductExternalId() => string.Empty;
}
