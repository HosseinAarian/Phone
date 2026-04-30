using MediatR;
using Phone.Application.Contract.CommandsQueries.Brands;
using Phone.Domain.Contract.IRepositories;
using Phone.Domain.Entities.Brands;

namespace Phone.Application.Handlers.Brands;

public class CreateBrandCommandHandler(
    IBrandRepository brandRepository)
    : IRequestHandler<CreateBrandCommand, CreateBrandCommandResponse>
{
    public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = new Brand
        {
            Title = request.Title,
            Description = request.Description!
        };

        await brandRepository.AddAsync(brand, cancellationToken);
        await brandRepository.SaveChangesAsync(cancellationToken);

        var response = new CreateBrandCommandResponse
        {
            BrandId = brand.Id
        };

        return response;
    }
}
