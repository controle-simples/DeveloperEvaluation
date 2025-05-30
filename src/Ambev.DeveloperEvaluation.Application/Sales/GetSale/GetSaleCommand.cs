﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    /// <summary>
    /// Command for retrieving a sale by its ID.
    /// </summary>
    public record GetSaleCommand(Guid Id) : IRequest<GetSaleResult>;
}
