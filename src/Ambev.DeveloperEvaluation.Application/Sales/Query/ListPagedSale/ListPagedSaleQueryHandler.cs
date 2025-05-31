using Ambev.DeveloperEvaluation.Application.Common.DTOs;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Query.ListPagedSale
{
    public sealed class ListPagedSaleQueryHandler : IRequestHandler<ListPagedSaleQuery, PagedResult<SaleOutputDto>>
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;

        public ListPagedSaleQueryHandler(ISaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SaleOutputDto>> Handle(ListPagedSaleQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetPagedAsync(request.Input.Page, request.Input.PageSize, cancellationToken);
            var items = _mapper.Map<IEnumerable<SaleOutputDto>>(result);

            return new PagedResult<SaleOutputDto>
            {
                Items = items,
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalCount = result.TotalCount
            };
        }
    }
}
