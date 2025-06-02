namespace Ambev.DeveloperEvaluation.Application.Common.DTOs
{
    public class SaleItemResult
    {
        public Guid Id { get; set; }
        public string ProductExternalId { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
