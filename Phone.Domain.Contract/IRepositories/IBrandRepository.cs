using Phone.Domain.Contract.DTOs;
using Phone.Domain.Entities.Brands;

namespace Phone.Domain.Contract.IRepositories;

public interface IBrandRepository
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    Task<List<BrandDTO>> GetAllAsync(CancellationToken cancellationToken);
    ValueTask<BrandDTO> GetAsync(short id, CancellationToken cancellationToken);
    Task<short> AddAsync(Brand brand, CancellationToken cancellationToken);
    Task DeleteAsync(short id, CancellationToken cancellationToken);
    Task<short> UpdateAsync(Brand brand, CancellationToken cancellationToken);
}
