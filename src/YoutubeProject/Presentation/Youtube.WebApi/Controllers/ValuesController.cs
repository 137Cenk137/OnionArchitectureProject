using MediatR;
using Microsoft.AspNetCore.Mvc;
using Youtube.Application.Features.Queries.GetAllProduct;
using Youtube.Application.Interfaces.UnitOfWorks;
using Youtube.Domain.Entities;

namespace Youtube.WebaApi.Controllers;

[Route("Api/[controller]/[action]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public ValuesController(IUnitOfWork unitOfWork, IMediator mediator)
    {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        return Ok(await _mediator.Send(new GetAllProductQueryRequest()));
    }
    [HttpGet("With Mediatr ")]
    public async Task<IActionResult> GetAllProducts()
    {
        var response  = await _mediator.Send(new GetAllProductQueryRequest());
        Console.WriteLine(response);
        return  Ok(response);
    }
}