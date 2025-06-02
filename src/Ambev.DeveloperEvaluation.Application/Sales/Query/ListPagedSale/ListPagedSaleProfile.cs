using Ambev.DeveloperEvaluation.Application.Common.DTOs;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Query.ListPagedSale
{
    public sealed class ListPagedSaleProfile : Profile
    {
        public ListPagedSaleProfile()
        {
            CreateMap<SaleItem, SaleItemResult>();
            CreateMap<Sale, SaleOutputDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
