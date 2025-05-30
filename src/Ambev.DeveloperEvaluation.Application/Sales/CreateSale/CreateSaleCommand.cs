using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Command for creating a new sale.
    /// </summary>
    /// <remarks>
    /// This command includes the required information to register a sale,
    /// including customer, branch, and a list of products with their quantities and prices.
    /// </remarks>
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        /// <summary>
        /// External identifier of the customer making the purchase.
        /// </summary>
        public string CustomerExternalId { get; set; } = string.Empty;

        /// <summary>
        /// External identifier of the branch where the sale took place.
        /// </summary>
        public string BranchExternalId { get; set; } = string.Empty;

        /// <summary>
        /// List of products included in the sale.
        /// </summary>
        public List<CreateSaleProductItem> Products { get; set; } = new();

        /// <summary>
        /// Performs validation using FluentValidation.
        /// </summary>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateSaleCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
