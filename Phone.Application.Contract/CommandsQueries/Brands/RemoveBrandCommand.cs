using MediatR;

namespace Phone.Application.Contract.CommandsQueries.Brands;

public record RemoveBrandCommand : IRequest<RemoveBrandCommandResponse>
{
	public short Id { get; set; }
}
