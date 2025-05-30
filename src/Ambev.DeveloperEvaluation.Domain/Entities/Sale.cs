using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sales transaction containing customer, branch, date and item details.
/// This is the root of the Sale aggregate in the domain.
/// </summary>
public sealed class Sale : BaseEntity
{
    private readonly List<SaleItem> _items = new();

    /// <summary>
    /// Gets the external customer identifier.
    /// </summary>
    public string CustomerExternalId { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the external branch identifier.
    /// </summary>
    public string BranchExternalId { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the sale date and time.
    /// </summary>
    public DateTime SaleDate { get; private set; }

    /// <summary>
    /// Gets whether the sale has been cancelled.
    /// </summary>
    public bool Cancelled { get; private set; }

    /// <summary>
    /// Gets the list of sale items.
    /// </summary>
    public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();

    /// <summary>
    /// Gets the total amount of the sale including discounts.
    /// </summary>
    public decimal TotalAmount => _items.Sum(item => item.Total);

    private Sale() { }

    /// <summary>
    /// Constructor used to initialize a new Sale from external IDs.
    /// </summary>
    public Sale(string customerExternalId, string branchExternalId)
    {
        if (string.IsNullOrWhiteSpace(customerExternalId))
            throw new DomainException("CustomerExternalId is required.");

        if (string.IsNullOrWhiteSpace(branchExternalId))
            throw new DomainException("BranchExternalId is required.");

        Id = Guid.NewGuid();
        CustomerExternalId = customerExternalId;
        BranchExternalId = branchExternalId;
        SaleDate = DateTime.UtcNow;
        Cancelled = false;

        AddDomainEvent(new SaleCreatedEvent(Id));
    }

    /// <summary>
    /// Adds a new item to the sale with quantity-based discount validation.
    /// </summary>
    public void AddItem(string productExternalId, int quantity, decimal unitPrice)
    {
        var item = SaleItem.Create(productExternalId, quantity, unitPrice);
        _items.Add(item);
    }

    /// <summary>
    /// Cancels the sale and adds a domain event.
    /// </summary>
    public void Cancel()
    {
        if (Cancelled)
            throw new DomainException("Sale already cancelled.");

        Cancelled = true;
        AddDomainEvent(new SaleCancelledEvent(Id));
    }
}
