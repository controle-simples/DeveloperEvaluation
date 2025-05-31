namespace Ambev.DeveloperEvaluation.Application.Sales.Query.ListPagedSale
{
    /// <summary>
    /// Output DTO for paginated sale listing.
    /// </summary>
    public sealed class SaleOutputDto
    {
        public Guid Id { get; set; }
        public string CustomerExternalId { get; set; } = string.Empty;
        public string BranchExternalId { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public bool Cancelled { get; set; }
    }
}
