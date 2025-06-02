using Ambev.DeveloperEvaluation.Application.Events;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Services.Messaging;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales;

/// <summary>
/// Application-level service for handling sales.
/// </summary>
public class SaleAppService
{
    private readonly ISaleRepository _repository;
    private readonly ISaleEventPublisher _publisher;
    private readonly IMediator _mediator;

    public SaleAppService(
        ISaleRepository repository,
        ISaleEventPublisher publisher,
        IMediator mediator)
    {
        _repository = repository;
        _publisher = publisher;
        _mediator = mediator;
    }

    public async Task<Guid> CreateAsync(CreateSaleCommand command)
    {
        var sale = new Sale(command.CustomerExternalId, command.BranchExternalId);

        foreach (var item in command.Products)
        {
            sale.AddItem(item.ProductExternalId, item.Quantity, item.UnitPrice);
        }

        await _repository.AddAsync(sale);
        await _publisher.PublishSaleCreatedAsync(sale.Id);
        await _mediator.Publish(new QueueMessageEvent($"Sale created: {sale.Id}", "sales.created"));

        return sale.Id;
    }
}
