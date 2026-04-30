using MediatR;
using Phone.Application.Contract.CommandsQueries.Brands;
using Phone.Domain.Contract.IRepositories;
using Phone.Domain.Entities.Brands;

namespace Phone.Application.Handlers.Brands;

public class UpdateBrandCommandHandler(
    IBrandRepository brandRepository) : IRequestHandler<UpdateBrandCommand, UpdateBrandCommandResponse>
{
    public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        Brand brand = new Brand()
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description
        };
        var brandId = await brandRepository.UpdateAsync(brand, cancellationToken);
        await brandRepository.SaveChangesAsync(cancellationToken);

        var response = new UpdateBrandCommandResponse()
        {
            Id = brandId
        };

        return response;
    }
}

