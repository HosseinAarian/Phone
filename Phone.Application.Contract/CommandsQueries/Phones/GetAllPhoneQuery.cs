using MediatR;

namespace Phone.Application.Contract.CommandsQueries.Phones;

public record GetAllPhoneQuery : IRequest<List<GetAllPhoneQueryResponse>>;

