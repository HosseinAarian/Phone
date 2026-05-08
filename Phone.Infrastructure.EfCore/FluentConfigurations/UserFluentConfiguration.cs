using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phone.Domain.Entities.Authenticates;

namespace Phone.Infrastructure.EfCore.FluentConfigurations;

public class UserFluentConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
        builder.Metadata.SetSchema("User");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserName).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Password).IsRequired().HasMaxLength(256);
    }
}
