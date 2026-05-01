using Azure;
using MediatR;
using Phone.Application.Contract.CommandsQueries.Phones;
using Phone.Domain.Contract.IRepositories;
using Phone.Domain.Entities.Phones;

namespace Phone.Application.Handlers.Phones;

public class UpdatePhoneCommandHandler(
    IPhoneRepository phoneRepository)
    : IRequestHandler<UpdatePhoneCommand, int>
{
    public async Task<int> Handle(UpdatePhoneCommand request, CancellationToken cancellationToken)
    {
        var phone = new Phone.Domain.Entities.Phones.Phone()
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,

            PhoneDetails = request.PhoneDetails.Select(pd => new PhoneDetail
            {
                Color = pd.Color,
                OS = pd.OS,
                Hard = pd.Hard,
                Ram = pd.Ram
            }).ToList()
        };

        var phoneId = await phoneRepository.UpdateAsync(phone, cancellationToken);
        await phoneRepository.SaveChangesAsync(cancellationToken);

        return phoneId;
    }
}
