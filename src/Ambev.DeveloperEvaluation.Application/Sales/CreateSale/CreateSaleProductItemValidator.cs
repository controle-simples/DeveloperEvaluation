using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Validator for each product in the sale.
    /// </summary>
    public class CreateSaleProductItemValidator : AbstractValidator<CreateSaleProductItem>
    {
        public CreateSaleProductItemValidator()
        {
            RuleFor(x => x.ProductExternalId)
                .NotEmpty().WithMessage("ProductExternalId is required.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("UnitPrice must be greater than zero.");
        }
    }
}
