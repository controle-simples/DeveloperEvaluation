namespace Ambev.DeveloperEvaluation.Application.Common.DTOs
{
    public class SaleOutputDto
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
