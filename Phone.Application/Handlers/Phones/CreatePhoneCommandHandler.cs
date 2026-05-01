using MediatR;
using Phone.Application.Contract.CommandsQueries.Phones;
using Phone.Domain.Contract.IRepositories;
using Phone.Domain.Entities.Phones;

namespace Phone.Application.Handlers.Phones;

public class CreatePhoneCommandHandler(
    IPhoneRepository phoneRepository)
    : IRequestHandler<CreatePhoneCommand, int>
{
    public Task<int> Handle(CreatePhoneCommand request, CancellationToken cancellationToken)
    {
        var phone = new Phone.Domain.Entities.Phones.Phone
        {
            Title = request.Title,
            Description = request.Description,

            PhoneDetails = request.PhoneDetails
            .Select(detail => new PhoneDetail
            {
                Color = detail.Color,
                OS = detail.OS,
                Hard = detail.Hard,
                Ram = detail.Ram
            }).ToList()
        };

        var id = phoneRepository.AddAsync(phone, cancellationToken);
        return id;
    }
}
