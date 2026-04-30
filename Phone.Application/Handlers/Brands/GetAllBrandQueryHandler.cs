using MediatR;
using Phone.Application.Contract.CommandsQueries.Brands;
using Phone.Domain.Contract.IRepositories;

namespace Phone.Application.Handlers.Brands;

public class GetAllBrandQueryHandler(
    IBrandRepository brandRepository)
    : IRequestHandler<GetAllBrandQuery, GetAllBrandQueryResponse>
{
    public async Task<GetAllBrandQueryResponse> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
    {
        var result = await brandRepository.GetAllAsync(cancellationToken);
        var response = new GetAllBrandQueryResponse()
        {
            Brands = result
        };
        return response;
    }
}
