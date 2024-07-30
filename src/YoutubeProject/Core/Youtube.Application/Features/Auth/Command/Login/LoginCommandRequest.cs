using MediatR;

namespace Youtube.Application.Features.Auth.Command.Login;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    public string Password { get; set; }
    public string Email { get; set; }

}