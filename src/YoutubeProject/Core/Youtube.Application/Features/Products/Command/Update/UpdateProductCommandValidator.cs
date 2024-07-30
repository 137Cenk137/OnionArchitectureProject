using FluentValidation;

namespace Youtube.Application.Features.Products.Command.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0);

        RuleFor(x => x.Title).NotEmpty();

        RuleFor(x => x.Description).NotEmpty();

        RuleFor(x => x.Price).GreaterThan(0);

        RuleFor(x =>x.Discount).GreaterThanOrEqualTo(0);

        RuleFor(x => x.BrandId).GreaterThan(0);

        RuleFor(x => x.CategoryIds).NotEmpty().Must(category => category.Any());
    }
}