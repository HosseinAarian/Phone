using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Phone.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using Phone.Domain.Contract.IRepositories;
using Phone.Infrastructure.EfCore.Repositories;

namespace Phone.Infrastructure.Configuration;

public partial class PhoneConfiguration
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        var dbConnectionString = configuration.GetConnectionString("Phone");

        ConfigureDatabase(services, dbConnectionString!);
        ConfigureRepositoreis(services);
        ConfigureServices(services);
    }

    public static void ConfigureServices(IServiceCollection services)
    {

    }

    private static void ConfigureRepositoreis(IServiceCollection services)
    {
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IPhoneRepository, PhoneRepository>();
    }

    private static void ConfigureDatabase(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<PhoneContext>(option =>
        {
            option.UseSqlServer(connectionString,
                b => b.MigrationsAssembly("Phone.Infrastructure.EfCore"));
        }, ServiceLifetime.Scoped);
    }
}

public partial class PhoneConfiguration
{
    public static bool Migrate(IServiceProvider app)
    {
        try
        {
            var servicesScop = app.CreateScope();
            var services = servicesScop.ServiceProvider;
            var context = services.GetRequiredService<PhoneContext>();
            context.Database.Migrate();
            servicesScop.Dispose();
            return true;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
