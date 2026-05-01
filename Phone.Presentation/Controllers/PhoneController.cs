using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phone.Application.Contract.CommandsQueries.Phones;

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
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllPhoneQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreatePhoneCommand input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(input, cancellationToken);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdatePhoneCommand input, CancellationToken cancellationToken)
    {
        var id = await mediator.Send(input, cancellationToken);
        return Ok(id);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(RemovePhoneCommand input, CancellationToken cancellationToken)
    {
        await mediator.Send(input, cancellationToken);
        return Ok();
    }
}
