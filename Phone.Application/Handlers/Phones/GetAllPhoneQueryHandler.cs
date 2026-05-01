using AutoMapper;
using MediatR;
using Phone.Application.Contract.CommandsQueries.Phones;
using Phone.Domain.Contract.IRepositories;

namespace Phone.Application.Handlers.Phones;

public class GetAllPhoneQueryHandler(
    IPhoneRepository phoneRepository,
    IMapper mapper)
    : IRequestHandler<GetAllPhoneQuery, List<GetAllPhoneQueryResponse>>
{
    public async Task<List<GetAllPhoneQueryResponse>> Handle(GetAllPhoneQuery request, CancellationToken cancellationToken)
    {
        var result = await phoneRepository.GetAllAsync(cancellationToken);
        var response = mapper.Map<List<GetAllPhoneQueryResponse>>(result);
        return response;
    }
}
