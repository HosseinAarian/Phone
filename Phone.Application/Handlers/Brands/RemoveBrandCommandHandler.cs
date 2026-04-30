using MediatR;
using Phone.Application.Contract.CommandsQueries.Brands;
using Phone.Domain.Contract.IRepositories;

namespace Phone.Application.Handlers.Brands;

public class RemoveBrandCommandHandler(
    IBrandRepository brandRepository)
    : IRequestHandler<RemoveBrandCommand, RemoveBrandCommandResponse>
{
    public async Task<RemoveBrandCommandResponse> Handle(RemoveBrandCommand request, CancellationToken cancellationToken)
    {
        await brandRepository.DeleteAsync(request.Id, cancellationToken);
        await brandRepository.SaveChangesAsync(cancellationToken);
        return new RemoveBrandCommandResponse();
    }
}
