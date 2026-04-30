using MediatR;

namespace Phone.Application.Contract.CommandsQueries.Brands;

public record GetBrandQuery : IRequest<GetBrandQueryResponse>
{
	public short Id { get; set; }
}
