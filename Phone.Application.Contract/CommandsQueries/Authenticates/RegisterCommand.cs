using MediatR;

namespace Phone.Application.Contract.CommandsQueries.Authenticates;

public class RegisterCommand : IRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
