using MediatR;
using Phone.Application.Contract.Common.Attributes;

namespace Phone.Application.Contract.CommandsQueries.Phones;

[InvalidateCache("phones:all")]
public record RemovePhoneCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
