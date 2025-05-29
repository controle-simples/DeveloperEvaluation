namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a product item in a sale, including pricing and discount logic.
    /// </summary>
    public sealed class SaleItem
    {
        /// <summary>
        /// Gets the product ID.
        /// </summary>
        public Guid ProductId { get; private set; }

        /// <summary>
        /// Gets the quantity sold.
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Gets the unit price.
        /// </summary>
        public decimal UnitPrice { get; private set; }

        /// <summary>
        /// Gets the discount applied to the item.
        /// </summary>
        public decimal Discount { get; private set; }

        /// <summary>
        /// Gets the total amount after discount.
        /// </summary>
        public decimal Total => (UnitPrice * Quantity) - Discount;

        private SaleItem() { }

        /// <summary>
        /// Creates a new SaleItem with discount rules applied.
        /// </summary>
        public static SaleItem Create(Guid productId, int quantity, decimal unitPrice)
        {
            if (productId == Guid.Empty)
                throw new DomainException("Product ID is required.");

            if (quantity <= 0)
                throw new DomainException("Quantity must be greater than zero.");

            if (quantity > 20)
                throw new DomainException("Cannot sell more than 20 identical items.");

            if (unitPrice <= 0)
                throw new DomainException("Unit price must be greater than zero.");

            decimal discount = 0;

            if (quantity >= 10 && quantity <= 20)
                discount = unitPrice * quantity * 0.20m;
            else if (quantity >= 4)
                discount = unitPrice * quantity * 0.10m;

            return new SaleItem
            {
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = unitPrice,
                Discount = discount
            };
        }
    }
}
