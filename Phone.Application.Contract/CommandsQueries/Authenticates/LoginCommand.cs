using MediatR;

namespace Phone.Application.Contract.CommandsQueries.Authenticates;

public class LoginCommand : IRequest<LoginCommandResponse>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
