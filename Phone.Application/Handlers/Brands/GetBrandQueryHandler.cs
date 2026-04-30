using MediatR;
using Phone.Application.Contract.CommandsQueries.Brands;
using Phone.Domain.Contract.IRepositories;
using Phone.Infrastructure.EfCore.Repositories;

namespace Phone.Application.Handlers.Brands;

public class GetBrandQueryHandler(
    IBrandRepository brandRepository)
    : IRequestHandler<GetBrandQuery, GetBrandQueryResponse>
{
    public async Task<GetBrandQueryResponse> Handle(GetBrandQuery request, CancellationToken cancellationToken)
    {
        var result = await brandRepository.GetAsync(request.Id, cancellationToken);
        var response = new GetBrandQueryResponse
        {
            Id = result!.Id,
            Title = result.Title,
            Description = result.Description
        };
        return response;
    }
}
