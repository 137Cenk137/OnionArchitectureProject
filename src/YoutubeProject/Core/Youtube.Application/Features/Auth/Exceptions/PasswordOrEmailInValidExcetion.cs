using Youtube.Application.Bases;

namespace Youtube.Application.Features.Auth.Exceptions;

public class PasswordOrEmailInValidExcetion : BaseException
{
    public PasswordOrEmailInValidExcetion(): base("Password or email is incorrect")
    {
        
    }
}