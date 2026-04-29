using Microsoft.EntityFrameworkCore;
using Phone.Domain.Entities.Brands;
using Phone.Infrastructure.EfCore.FluentConfigurations;

namespace Phone.Infrastructure.EfCore.Context;

public class PhoneContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Brand> Brands => Set<Brand>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BrandFluentConfiguration());
    }
}
