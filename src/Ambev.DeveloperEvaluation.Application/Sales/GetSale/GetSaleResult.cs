namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    /// <summary>
    /// Result model returned when retrieving a sale.
    /// Includes basic sale information and its items.
    /// </summary>
    public class GetSaleResult
    {
        public Guid Id { get; set; }
        public string CustomerExternalId { get; set; } = string.Empty;
        public string BranchExternalId { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool Cancelled { get; set; }
        public List<SaleItemResult> Items { get; set; } = new();
    }
}
