using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phone.Application.Contract.CommandsQueries.Phones;
using Phone.Application.Contract.Common.APIResults;

namespace Phone.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class PhoneController(
    IMediator mediator) : ControllerBase
{
    [HttpGet("Get/{id}")]
    public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetPhoneQuery() { Id = id }, cancellationToken);
        return Ok(APIResult<GetPhoneQueryResponse>.Ok(result));
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllPhoneQuery(), cancellationToken);
        return Ok(APIResult<List<GetAllPhoneQueryResponse>>.Ok(result));
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreatePhoneCommand input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(input, cancellationToken);
        return Ok(APIResult<int>.Ok(result));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdatePhoneCommand input, CancellationToken cancellationToken)
    {
        var id = await mediator.Send(input, cancellationToken);
        return Ok(APIResult<int>.Ok(id));
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(RemovePhoneCommand input, CancellationToken cancellationToken)
    {
        await mediator.Send(input, cancellationToken);
        return Ok();
    }
}
