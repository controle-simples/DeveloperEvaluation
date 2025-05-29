using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    /// <summary>
    /// Provides methods for generating SaleItem test data using the Bogus library.
    /// </summary>
    public static class SaleItemTestData
    {
        private static readonly Faker faker = new();

        /// <summary>
        /// Generates a valid SaleItem with no discount (quantity < 4).
        /// </summary>
        public static SaleItem CreateItemWithoutDiscount()
        {
            return SaleItem.Create(Guid.NewGuid(), 2, 100);
        }

        /// <summary>
        /// Generates a valid SaleItem with 10% discount (4 ≤ quantity < 10).
        /// </summary>
        public static SaleItem CreateItemWith10PercentDiscount()
        {
            return SaleItem.Create(Guid.NewGuid(), 5, 200);
        }

        /// <summary>
        /// Generates a valid SaleItem with 20% discount (10 ≤ quantity ≤ 20).
        /// </summary>
        public static SaleItem CreateItemWith20PercentDiscount()
        {
            return SaleItem.Create(Guid.NewGuid(), 15, 50);
        }

        /// <summary>
        /// Generates an invalid quantity greater than 20 to trigger a DomainException.
        /// </summary>
        public static int GenerateInvalidQuantity() => faker.Random.Int(21, 100);

        /// <summary>
        /// Generates a valid quantity (between 1 and 20).
        /// </summary>
        public static int GenerateValidQuantity() => faker.Random.Int(1, 20);

        /// <summary>
        /// Generates a valid unit price.
        /// </summary>
        public static decimal GenerateValidUnitPrice() => faker.Random.Decimal(10, 500);

        /// <summary>
        /// Generates an invalid unit price (zero or negative).
        /// </summary>
        public static decimal GenerateInvalidUnitPrice() => faker.Random.Decimal(-100, 0);

        /// <summary>
        /// Generates a valid ProductId.
        /// </summary>
        public static Guid GenerateValidProductId() => Guid.NewGuid();

        /// <summary>
        /// Generates an invalid ProductId (Guid.Empty).
        /// </summary>
        public static Guid GenerateInvalidProductId() => Guid.Empty;
    }
}
