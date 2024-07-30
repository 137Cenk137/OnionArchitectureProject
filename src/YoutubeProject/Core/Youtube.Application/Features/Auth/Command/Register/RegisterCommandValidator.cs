using FluentValidation;

namespace Youtube.Application.Features.Auth.Command.Register;


public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
{
    public RegisterCommandValidator()
    {
        RuleFor(x=>x.FullName).NotEmpty().MinimumLength(2).MaximumLength(50);

        RuleFor(x=>x.Email).NotEmpty().MinimumLength(8).MaximumLength(60).EmailAddress();

        RuleFor(x=>x.Password).NotEmpty().MinimumLength(6);
        
        RuleFor(x=>x.ConfimPassword).NotEmpty().MinimumLength(6).Equal(x => x.Password);
    }
}