using System.Runtime.CompilerServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Youtube.Application.Interfaces.AutoMapper;
using Youtube.Application.Interfaces.UnitOfWorks;

namespace Youtube.Application.Bases;

public class BaseHandler
{
    public readonly IMapper _mapper;

    public readonly IUnitOfWork _unitOfWork;
    public readonly IHttpContextAccessor _contextAccessor;
    public readonly string _userId;
    public BaseHandler(IMapper mapper, IUnitOfWork unitOfWork,  IHttpContextAccessor contextAccessor)
    {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.NewGuid().ToString();
    }
}