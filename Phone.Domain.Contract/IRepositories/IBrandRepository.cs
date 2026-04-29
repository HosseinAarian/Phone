using Phone.Domain.Contract.DTOs;
using Phone.Domain.Entities.Brands;

namespace Phone.Domain.Contract.IRepositories;

public interface IBrandRepository
{
    Task<List<BrandDTO>> GetAllAsync(CancellationToken cancellationToken);
    ValueTask<BrandDTO> GetAsync(short id, CancellationToken cancellationToken);
    Task<short> AddAsync(Brand brand, CancellationToken cancellationToken);
}
