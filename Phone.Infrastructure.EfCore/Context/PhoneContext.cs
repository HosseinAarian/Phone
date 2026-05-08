using Microsoft.EntityFrameworkCore;
using Phone.Domain.Entities.Authenticates;
using Phone.Domain.Entities.Brands;
using Phone.Domain.Entities.Phones;
using Phone.Infrastructure.EfCore.FluentConfigurations;

namespace Phone.Infrastructure.EfCore.Context;

public class PhoneContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Phone.Domain.Entities.Phones.Phone> Phones => Set<Phone.Domain.Entities.Phones.Phone>();
    public DbSet<PhoneDetail> PhoneDetails => Set<PhoneDetail>();
    public DbSet<User> Users => Set<User>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BrandFluentConfiguration());
    }
}
