using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Handles the creation of a new sale.
    /// </summary>
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSaleHandler"/> class.
        /// </summary>
        /// <param name="saleRepository">Repository to persist the sale.</param>
        public CreateSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        /// <summary>
        /// Handles the creation of a sale by processing the command data.
        /// </summary>
        /// <param name="request">The command containing the sale data.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The result containing the sale ID and total amount.</returns>
        public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = new Sale(request.CustomerExternalId, request.BranchExternalId);

            foreach (var product in request.Products)
            {
                sale.AddItem(product.ProductExternalId, product.Quantity, product.UnitPrice);
            }
                        
            sale.ValidateBusinessRules();

            await _saleRepository.AddAsync(sale, cancellationToken);

            return new CreateSaleResult
            {
                Id = sale.Id,
                TotalAmount = sale.TotalAmount
            };
        }
    }
}
