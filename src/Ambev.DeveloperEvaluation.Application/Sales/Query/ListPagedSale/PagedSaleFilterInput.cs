namespace Ambev.DeveloperEvaluation.Application.Sales.Query.ListPagedSale
{
    public sealed class PagedSaleFilterInput
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
