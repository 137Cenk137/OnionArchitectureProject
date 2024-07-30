using Youtube.Application.Bases;
using Youtube.Application.Features.Auth.Exceptions;
using Youtube.Domain.Entities;

namespace Youtube.Application.Features.Auth.Rules;

public class AuthRules : BaseRules
{
    public Task UserShouldNotBeExist(User? user)
    {
        if (user is not null)
        {
            throw new UserAlreadyExistException();
        }
        return Task.CompletedTask;
    }
}