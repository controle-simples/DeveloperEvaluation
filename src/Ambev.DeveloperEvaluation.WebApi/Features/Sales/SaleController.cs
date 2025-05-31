using Ambev.DeveloperEvaluation.Application.Sales.Query.ListPagedSale;
using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Controller responsible for sale-related operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SaleController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of SaleController.
    /// </summary>
    public SaleController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Lists sales with pagination.
    /// </summary>
    [HttpGet("list-paged")]
    [ProducesResponseType(typeof(PaginatedResponse<SaleOutputDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListPaged([FromQuery] PagedSaleFilterInput input, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new ListPagedSaleQuery(input), cancellationToken);
        return OkPaginated(result); 
    }
}
