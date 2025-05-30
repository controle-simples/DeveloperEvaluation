using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.GetSale
{
    /// <summary>
    /// Generates fake Sale entities for GetSaleHandler unit tests.
    /// </summary>
    public static class GetSaleHandlerTestData
    {
        private static readonly Faker faker = new();

        /// <summary>
        /// Generates a valid Sale with items and random external IDs.
        /// </summary>
        public static Sale GenerateValidSale()
        {
            var sale = new Sale(
                customerExternalId: faker.Random.Guid().ToString(),
                branchExternalId: faker.Random.Guid().ToString()
            );

            int itemCount = faker.Random.Int(1, 3);
            for (int i = 0; i < itemCount; i++)
            {
                sale.AddItem(
                    productExternalId: faker.Commerce.Ean13(),
                    quantity: faker.Random.Int(1, 10),
                    unitPrice: faker.Random.Decimal(10, 200)
                );
            }

            return sale;
        }
    }
}
