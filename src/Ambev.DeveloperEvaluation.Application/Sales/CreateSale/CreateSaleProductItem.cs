namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Represents a product being sold in a sale.
    /// </summary>
    public class CreateSaleProductItem
    {
        /// <summary>
        /// External identifier of the product.
        /// </summary>
        public string ProductExternalId { get; set; } = string.Empty;

        /// <summary>
        /// Quantity of the product sold.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price per unit of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}
