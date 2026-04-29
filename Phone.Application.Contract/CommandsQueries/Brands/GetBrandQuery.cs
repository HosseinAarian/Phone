using MediatR;

namespace Phone.Application.Contract.CommandsQueries.Brands;

public class GetBrandQuery : IRequest<GetBrandQueryResponse>
{
	public short Id { get; set; }
}
