using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Validator for CreateSaleCommand.
    /// </summary>
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleCommandValidator()
        {
            RuleFor(x => x.CustomerExternalId)
                .NotEmpty().WithMessage("CustomerExternalId is required.");

            RuleFor(x => x.BranchExternalId)
                .NotEmpty().WithMessage("BranchExternalId is required.");

            RuleFor(x => x.Products)
                .NotEmpty().WithMessage("At least one product must be included in the sale.");

            RuleForEach(x => x.Products).SetValidator(new CreateSaleProductItemValidator());
        }
    }
}
