

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Youtube.Application.Features.Auth.Command.Register;

namespace Youtube.WebaApi.Controllers;

[Route("Api/[controller]/[action]")]
[ApiController]
public class AuthController  : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator)
    {   
            _mediator = mediator;
    }    
    [HttpPost] 
    public async Task<IActionResult> Register(RegisterCommandRequest request)
    {
        await _mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created);
    }
}