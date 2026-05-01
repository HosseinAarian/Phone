using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Phone.Application.Contract.CommandsQueries.Brands;
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

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(RemovePhoneCommand input, CancellationToken cancellationToken)
    {
        await mediator.Send(input, cancellationToken);
        return Ok();
    }
}
