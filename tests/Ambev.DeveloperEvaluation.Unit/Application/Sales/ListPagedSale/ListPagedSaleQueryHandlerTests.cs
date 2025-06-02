using Ambev.DeveloperEvaluation.Application.Common.DTOs;
using Ambev.DeveloperEvaluation.Application.Sales.Query.ListPagedSale;
using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using Bogus;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.ListPagedSale;

public sealed class ListPagedSaleQueryHandlerTests
{
    private readonly ISaleRepository _repository;
    private readonly IMapper _mapper;
    private readonly ListPagedSaleQueryHandler _handler;
    private readonly Faker _faker;

    public ListPagedSaleQueryHandlerTests()
    {
        _repository = Substitute.For<ISaleRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new ListPagedSaleQueryHandler(_repository, _mapper);
        _faker = new Faker("pt_BR");
    }

    [Fact(DisplayName = "Should return paginated result successfully")]
    public async Task Handle_ShouldReturnPagedResult()
    {
        // Arrange
        var sale = new Sale(
            _faker.Random.Guid().ToString(),
            _faker.Random.Guid().ToString()
        );

        var sales = new List<Sale> { sale };

        var paginated = new PaginatedList<Sale>(
            sales,
            count: 1,
            pageNumber: 1,
            pageSize: 10
        );

        _repository
            .GetPagedAsync(1, 10, Arg.Any<CancellationToken>())
            .Returns(paginated);

        var saleDto = new SaleOutputDto
        {
            Id = sale.Id,
            CustomerExternalId = sale.CustomerExternalId,
            BranchExternalId = sale.BranchExternalId,
            SaleDate = sale.SaleDate,
            TotalAmount = sale.TotalAmount,
            Cancelled = sale.Cancelled
        };

        _mapper
            .Map<IEnumerable<SaleOutputDto>>(Arg.Any<IEnumerable<Sale>>())
            .Returns(new List<SaleOutputDto> { saleDto });

        var query = new ListPagedSaleQuery(new PagedSaleFilterInput { Page = 1, PageSize = 10 });

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result.Items);
        Assert.Single(result.Items);
        Assert.Equal(1, result.CurrentPage);
        Assert.Equal(1, result.TotalCount);
        Assert.Equal(1, result.TotalPages);
    }
}
