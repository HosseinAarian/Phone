using MediatR;

namespace Phone.Application.Contract.CommandsQueries.Phones;

public record GetPhoneQuery : IRequest<GetPhoneQueryResponse>
{
    public int Id { get; set; }
}
