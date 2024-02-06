using LazyCache;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using ProductMaster.Application.Common.Interfaces;
using ProductMaster.Infrastructure.Data;
using ProductMaster.Infrastructure.Persistence.Repositories;
using ProductMaster.Infrastructure.Shared.Services;

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

        services.AddTransient<IAPIExternalServices, APIExternalServices>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IAppCache, CachingService>();
        services.Configure<ExternalServices>(configuration.GetSection("ExternalServices"));
        services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        services.AddAuthorizationBuilder();

 
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        options =>
        {
            options.LoginPath = new PathString("/auth/login");
            options.AccessDeniedPath = new PathString("/auth/denied");
        });

        services.AddSingleton(TimeProvider.System);
        return services;
    }
}
