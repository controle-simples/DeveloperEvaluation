using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Query.ListPagedSale
{
    public sealed class ListPagedSaleProfile : Profile
    {
        public ListPagedSaleProfile()
        {
            CreateMap<Sale, SaleOutputDto>();
        }
    }
}
