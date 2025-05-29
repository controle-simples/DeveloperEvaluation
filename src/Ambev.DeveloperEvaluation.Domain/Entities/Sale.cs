using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sales transaction containing customer, branch, date and item details.
    /// This is the root of the Sale aggregate in the domain.
    /// </summary>
    public sealed class Sale : BaseEntity
    {
        private readonly List<SaleItem> _items = new();

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        public Guid CustomerId { get; private set; }

        /// <summary>
        /// Gets the branch identifier where the sale was made.
        /// </summary>
        public Guid BranchId { get; private set; }

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
        /// Creates a new Sale instance with basic validation.
        /// </summary>
        public static Sale Create(Guid customerId, Guid branchId, DateTime saleDate)
        {
            if (customerId == Guid.Empty)
                throw new DomainException("Customer ID cannot be empty.");

            if (branchId == Guid.Empty)
                throw new DomainException("Branch ID cannot be empty.");

            if (saleDate > DateTime.UtcNow)
                throw new DomainException("Sale date cannot be in the future.");

            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                BranchId = branchId,
                SaleDate = saleDate,
                Cancelled = false
            };

            sale.AddDomainEvent(new SaleCreatedEvent(sale.Id));
            return sale;
        }

       
        /// <summary>
        /// Adds a new item to the sale with quantity-based discount validation.
        /// </summary>
        public void AddItem(Guid productId, int quantity, decimal unitPrice)
        {
            var item = SaleItem.Create(productId, quantity, unitPrice);
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
}
