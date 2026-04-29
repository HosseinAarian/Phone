using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phone.Application.Contract.CommandsQueries.Brands;

namespace Phone.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class BrandController(
    IMediator mediator)
    : ControllerBase
{
    //[HttpGet(Name = "GetAll")]
    //public async Task<IActionResult> GetAll()
    //{

    //}

    [HttpPost]
    public async Task<IActionResult> Create(CreateBrandCommand input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(input, cancellationToken);
        return Ok(result);
    }
}
