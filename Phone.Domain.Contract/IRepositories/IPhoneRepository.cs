using Phone.Domain.Contract.DTOs;
using Phone.Domain.Entities.Phones;

namespace Phone.Domain.Contract.IRepositories;

public interface IPhoneRepository
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    Task<List<PhoneDTO>> GetAllAsync(CancellationToken cancellationToken);
    ValueTask<PhoneDTO> GetAsync(int id, CancellationToken cancellationToken);
    Task<int> AddAsync(Phone.Domain.Entities.Phones.Phone phone, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    Task<int> UpdateAsync(Phone.Domain.Entities.Phones.Phone phone, CancellationToken cancellationToken);
}
