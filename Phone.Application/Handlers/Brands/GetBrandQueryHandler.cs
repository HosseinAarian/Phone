using AutoMapper;
using MediatR;
using Phone.Application.Contract.CommandsQueries.Brands;
using Phone.Domain.Contract.IRepositories;


namespace Phone.Application.Handlers.Brands;

public class GetBrandQueryHandler(
    IBrandRepository brandRepository,
    IMapper mapper)
    : IRequestHandler<GetBrandQuery, GetBrandQueryResponse>
{
    public async Task<GetBrandQueryResponse> Handle(GetBrandQuery request, CancellationToken cancellationToken)
    {
        var result = await brandRepository.GetAsync(request.Id, cancellationToken);
        if (result is null)
            throw new Exception("Brand not found");

        var response = mapper.Map<GetBrandQueryResponse>(result);
        return response;
    }
}
