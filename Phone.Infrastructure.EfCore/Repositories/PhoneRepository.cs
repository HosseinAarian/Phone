using Microsoft.EntityFrameworkCore;
using Phone.Domain.Contract.DTOs;
using Phone.Domain.Contract.IRepositories;
using Phone.Domain.Entities.Phones;
using Phone.Infrastructure.EfCore.Context;

namespace Phone.Infrastructure.EfCore.Repositories;

public class PhoneRepository(
    PhoneContext context)
    : IPhoneRepository
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<PhoneDTO>> GetAllAsync(CancellationToken cancellationToken = default)
                => await context.Phones
                           .Include(p => p.PhoneDetails)
                           .AsNoTracking()
                           .Select(x => new PhoneDTO
                           {
                               Id = x.Id,
                               Title = x.Title,
                               Description = x.Description,

                               PhoneDetails = x.PhoneDetails.Select(y => new PhoneDetailDTO
                               {
                                   Id = y.Id,
                                   Color = y.Color,
                                   Hard = y.Hard,
                                   OS = y.OS,
                                   Ram = y.Ram
                               }).ToList()
                           }).ToListAsync(cancellationToken);

    public async ValueTask<PhoneDTO> GetAsync(int id, CancellationToken cancellationToken)
    {
        var result = await context.Phones
        .Where(x => x.Id == id)
        .Select(x => new PhoneDTO
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,

            PhoneDetails = x.PhoneDetails.Select(y => new PhoneDetailDTO
            {
                Id = y.Id,
                Color = y.Color,
                Hard = y.Hard,
                OS = y.OS,
                Ram = y.Ram
            }).ToList()
        })
        .FirstOrDefaultAsync(cancellationToken);

        return result;
    }

    public async Task<int> AddAsync(Domain.Entities.Phones.Phone phone, CancellationToken cancellationToken)
    {
        await context.Phones.AddAsync(phone, cancellationToken);
        await SaveChangesAsync(cancellationToken);
        return phone.Id;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var result = await context.Phones
            .Where(p => p.Id == id)
            .Include(p => p.PhoneDetails)
            .FirstOrDefaultAsync(cancellationToken);
        context.Phones.Remove(result!);
    }

    public async Task<int> UpdateAsync(Domain.Entities.Phones.Phone phone, CancellationToken cancellationToken)
    {
        var existingPhone = await context.Phones
                            .Include(p => p.PhoneDetails)
                            .FirstOrDefaultAsync(p => p.Id == phone.Id);

        if (existingPhone is null)
            return 0;

        existingPhone.Title = phone.Title;
        existingPhone.Description = phone.Description;

        foreach (var existingPhoneDetail in existingPhone.PhoneDetails.ToList())
        {
            if (!phone.PhoneDetails.Any(pd => pd.Id == existingPhoneDetail.Id))
            {
                context.PhoneDetails.Remove(existingPhoneDetail);
            }
        }

        foreach (var updatedPhoneDetail in phone.PhoneDetails)
        {
            var existingPhoneDetail = existingPhone.PhoneDetails
                .FirstOrDefault(d => d.Id == updatedPhoneDetail.Id && d.Id != 0);

            if (existingPhoneDetail is not null)
            {
                existingPhoneDetail.Color = updatedPhoneDetail.Color;
                existingPhoneDetail.OS = updatedPhoneDetail.OS;
                existingPhoneDetail.Hard = updatedPhoneDetail.Hard;
                existingPhoneDetail.Ram = updatedPhoneDetail.Ram;
            }
            else
            {
                existingPhone.PhoneDetails.Add(new PhoneDetail
                {
                    Color = updatedPhoneDetail.Color,
                    OS = updatedPhoneDetail.OS,
                    Hard = updatedPhoneDetail.Hard,
                    Ram = updatedPhoneDetail.Ram
                });
            }
        }
        return existingPhone.Id;
    }
}
