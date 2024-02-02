using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProductMaster.Domain.Entities;

namespace ProductMaster.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ProductMasterDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        initialiser.Seed();
    }
}

public class ProductMasterDbContextInitialiser
{
    private readonly ILogger<ProductMasterDbContextInitialiser> _logger;
    private readonly ProductMasterDbContext _context;

    public ProductMasterDbContextInitialiser(ILogger<ProductMasterDbContextInitialiser> logger, ProductMasterDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public void Seed()
    {
        try
        {
            TrySeed();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public static void TrySeed()
    {

    }
}
