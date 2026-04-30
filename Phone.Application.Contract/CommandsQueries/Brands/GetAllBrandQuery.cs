using MediatR;

namespace Phone.Application.Contract.CommandsQueries.Brands;

public record GetAllBrandQuery : IRequest<GetAllBrandQueryResponse>
{
}
