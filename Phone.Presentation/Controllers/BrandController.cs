using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phone.Application.Contract.CommandsQueries.Brands;
using Phone.Application.Contract.Common.APIResults;

namespace Phone.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class BrandController(
    IMediator mediator)
    : ControllerBase
{
    [HttpGet("Get/{id}")]
    public async Task<IActionResult> Get(short id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetBrandQuery() { Id = id }, cancellationToken);
        return Ok(APIResult<GetBrandQueryResponse>.Ok(result));
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllBrandQuery(), cancellationToken);
        return Ok(APIResult<GetAllBrandQueryResponse>.Ok(result));
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateBrandCommand input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(input, cancellationToken);
        return Ok(APIResult<CreateBrandCommandResponse>.Ok(result));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateBrandCommand input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(input, cancellationToken);
        return Ok(APIResult<short>.Ok(result.Id));
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(RemoveBrandCommand input, CancellationToken cancellationToken)
    {
        await mediator.Send(input, cancellationToken);
        return Ok();
    }
}