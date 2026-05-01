using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Phone.Infrastructure.EfCore.FluentConfigurations;

public class PhoneFluentConfiguration : IEntityTypeConfiguration<Phone.Domain.Entities.Phones.Phone>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Phones.Phone> builder)
    {
        builder.Metadata.SetSchema("Phone");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(512);

        builder.HasMany(p => p.PhoneDetails)
               .WithOne(d => d.Phone)
               .HasForeignKey(d => d.PhoneId);
    }
}
