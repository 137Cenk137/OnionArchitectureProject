using Microsoft.AspNetCore.Mvc;
using Youtube.Application.Interfaces.UnitOfWorks;
using Youtube.Domain.Entities;

namespace Youtube.WebaApi.Controllers;

[Route("Api/[controller]/[action]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ValuesController(IUnitOfWork unitOfWork)
    {
            _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        return Ok(await _unitOfWork.GetReadRepository<Product>().GetAllAsync());
    }
}