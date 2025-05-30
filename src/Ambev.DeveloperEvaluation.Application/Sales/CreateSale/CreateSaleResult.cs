namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Result returned after creating a new sale.
    /// </summary>
    /// <remarks>
    /// This result includes the generated sale ID and total amount.
    /// </remarks>
    public class CreateSaleResult
    {
        /// <summary>
        /// Unique identifier of the created sale.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Total amount of the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}
