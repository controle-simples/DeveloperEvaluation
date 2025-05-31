using Ambev.DeveloperEvaluation.Application.Common.DTOs;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Query.ListPagedSale
{
    public sealed class ListPagedSaleQuery : IRequest<PagedResult<SaleOutputDto>>
    {
        public PagedSaleFilterInput Input { get; }

        public ListPagedSaleQuery(PagedSaleFilterInput input)
        {
            Input = input;
        }
    }
}
