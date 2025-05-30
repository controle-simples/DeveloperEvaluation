using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a product item in a sale, including pricing and discount logic.
/// </summary>
public sealed class SaleItem : BaseEntity
{
    /// <summary>
    /// Gets the external product identifier.
    /// </summary>
    public string ProductExternalId { get; private set; } = string.Empty;

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
    /// <param name="productExternalId">External ID of the product.</param>
    /// <param name="quantity">Quantity being sold.</param>
    /// <param name="unitPrice">Unit price of the product.</param>
    /// <returns>A new instance of SaleItem with applied discounts.</returns>
    public static SaleItem Create(string productExternalId, int quantity, decimal unitPrice)
    {
        if (string.IsNullOrWhiteSpace(productExternalId))
            throw new DomainException("ProductExternalId is required.");

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
            Id = Guid.NewGuid(),
            ProductExternalId = productExternalId,
            Quantity = quantity,
            UnitPrice = unitPrice,
            Discount = discount
        };
    }
}
