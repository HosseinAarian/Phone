using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phone.Domain.Entities.Phones;

namespace Phone.Infrastructure.EfCore.FluentConfigurations;

public class PhoneDetailFluentConfiguration : IEntityTypeConfiguration<PhoneDetail>
{
    public void Configure(EntityTypeBuilder<PhoneDetail> builder)
    {
        builder.Metadata.SetSchema("Phone");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Color).IsRequired().HasMaxLength(256);
        builder.Property(x => x.OS).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Hard).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Ram).IsRequired().HasMaxLength(256);
    }
}
