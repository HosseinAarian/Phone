using Microsoft.EntityFrameworkCore;
using Phone.Domain.Contract.DTOs;
using Phone.Domain.Contract.IRepositories;
using Phone.Domain.Entities.Brands;
using Phone.Infrastructure.EfCore.Context;

namespace Phone.Infrastructure.EfCore.Repositories;

public class BrandRepository(
    PhoneContext context)
    : IBrandRepository
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        => await context.SaveChangesAsync(cancellationToken);

    public async Task<List<BrandDTO>> GetAllAsync(CancellationToken cancellationToken)
        => await context.Brands.Select(x => new BrandDTO
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
        })
        .AsNoTracking()
        .ToListAsync(cancellationToken);

    public async ValueTask<BrandDTO?> GetAsync(short id, CancellationToken cancellationToken)
        => await context.Brands
                        .AsNoTracking()
                        .Where(x => x.Id == id)
                        .Select(x => new BrandDTO
                        {
                            Id = x.Id,
                            Title = x.Title,
                            Description = x.Description,
                        }).FirstOrDefaultAsync(cancellationToken);


    public async Task<short> AddAsync(Brand brand, CancellationToken cancellationToken)
    {
        await context.Brands.AddAsync(brand, cancellationToken);
        await SaveChangesAsync(cancellationToken);
        return brand.Id;
    }
}
