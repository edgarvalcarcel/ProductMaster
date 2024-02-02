using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using ProductMaster.Application.Common.Interfaces;
using ProductMaster.Infrastructure.Data;
using ProductMaster.Infrastructure.Data.Interceptors;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ProductMasterDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IProductMasterDbContext>(provider => provider.GetRequiredService<ProductMasterDbContext>());
        services.AddScoped<ProductMasterDbContextInitialiser>();
        services.AddSingleton(TimeProvider.System);
        return services;
    }
}
