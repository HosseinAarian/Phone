using MediatR;
using Phone.Application.Contract.CommandsQueries.Phones;
using Phone.Domain.Contract.IRepositories;

namespace Phone.Application.Handlers.Phones;

public class RemovePhoneCommandHandler(
    IPhoneRepository phoneRepository)
    : IRequestHandler<RemovePhoneCommand, Unit>
{
    public async Task<Unit> Handle(RemovePhoneCommand request, CancellationToken cancellationToken)
    {
        await phoneRepository.DeleteAsync(request.Id, cancellationToken);
        await phoneRepository.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
