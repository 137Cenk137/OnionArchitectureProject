using FluentValidation;

namespace Youtube.Application.Features.Products.Command.Delete;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommandRequest>
{
    public DeleteProductCommandValidator()
    {
          RuleFor(x => x.DeleteID).GreaterThan(0);  
    }
}