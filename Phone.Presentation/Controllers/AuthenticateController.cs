using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phone.Application.Contract.CommandsQueries.Authenticates;

namespace Phone.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticateController(
    IMediator mediator)
    : ControllerBase
{
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginCommand input)
    {
        var result = await mediator.Send(input);
        return Ok(result);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterCommand input)
    {
        await mediator.Send(input);
        return Ok();
    }
}
