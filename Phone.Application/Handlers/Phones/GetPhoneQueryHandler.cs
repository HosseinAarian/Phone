using AutoMapper;
using MediatR;
using Phone.Application.Contract.CommandsQueries.Phones;
using Phone.Domain.Contract.IRepositories;

namespace Phone.Application.Handlers.Phones;

public class GetPhoneQueryHandler(
    IPhoneRepository phoneRepository,
    IMapper mapper)
    : IRequestHandler<GetPhoneQuery, GetPhoneQueryResponse>
{
    public async Task<GetPhoneQueryResponse> Handle(GetPhoneQuery request, CancellationToken cancellationToken)
    {
        var result = await phoneRepository.GetAsync(request.Id, cancellationToken);
        var response = mapper.Map<GetPhoneQueryResponse>(result);
        return response;
    }
}
