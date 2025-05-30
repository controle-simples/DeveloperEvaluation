namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Response returned after successfully cancelling a sale.
    /// </summary>
    public class DeleteSaleResponse
    {
        public Guid Id { get; set; }
        public bool Cancelled { get; set; }
    }
}
