using MediatR;

namespace Phone.Application.Contract.CommandsQueries.Phones;

public record RemovePhoneCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
