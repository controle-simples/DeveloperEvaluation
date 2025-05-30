using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.DeleteSale
{
    /// <summary>
    /// Provides fake Sale entities for DeleteSaleHandler unit tests.
    /// </summary>
    public static class DeleteSaleHandlerTestData
    {
        private static readonly Faker faker = new();

        /// <summary>
        /// Generates a valid sale with one or more items.
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
