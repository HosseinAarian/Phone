using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phone.Application.Contract.CommandsQueries.Brands;
using System.Threading;

namespace Phone.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class BrandController(
    IMediator mediator)
    : ControllerBase
{
    [HttpPost("Get")]
    public async Task<IActionResult> Get(GetBrandQuery input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(input, cancellationToken);
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        GetAllBrandQuery getAllBrandQuery = new GetAllBrandQuery();
        var result = await mediator.Send(getAllBrandQuery, cancellationToken);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateBrandCommand input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(input, cancellationToken);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateBrandCommand input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(input, cancellationToken);
        return Ok(result.Id);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(RemoveBrandCommand input, CancellationToken cancellationToken)
    {
        await mediator.Send(input, cancellationToken);
        return Ok();
    }
}