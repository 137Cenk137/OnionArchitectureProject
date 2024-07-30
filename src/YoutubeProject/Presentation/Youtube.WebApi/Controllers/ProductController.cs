using MediatR;
using Microsoft.AspNetCore.Mvc;
using Youtube.Application.Features.Products.Command.CreateProduct;
using Youtube.Application.Features.Products.Command.Delete;
using Youtube.Application.Features.Products.Command.Update;
using Youtube.Application.Features.Queries.GetAllProduct;

namespace Youtube.WebaApi.Controllers;

[Route("Api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
            _mediator = mediator;
    }   
    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        var response = await _mediator.Send(new GetAllProductQueryRequest());
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> PostProduct(CreateProductCommandRequest request)
    {
        await _mediator.Send(request);
        return Ok (); 
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct([FromQuery]  int id)
    {
        await _mediator.Send(new DeleteProductCommandRequest(){DeleteID = id});
        return Ok();
    }
    [HttpPut]
    public async Task<IActionResult> PutProduct([FromBody] UpdateProductCommandRequest request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}