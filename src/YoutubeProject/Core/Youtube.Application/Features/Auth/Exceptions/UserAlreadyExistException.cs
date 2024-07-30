using Youtube.Application.Bases;

namespace Youtube.Application.Features.Auth.Exceptions;

public class UserAlreadyExistException : BaseException
{
    public UserAlreadyExistException():base("user has already exist")
    {
         
    }
}