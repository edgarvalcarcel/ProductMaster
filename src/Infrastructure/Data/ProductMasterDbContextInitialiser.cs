using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ProductMaster.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ProductMasterDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
    public static async Task DatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var initialiser = scope.ServiceProvider.GetRequiredService<ProductMasterDbContextInitialiser>();
        await initialiser.SeedAsync();
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

    public async Task SeedAsync()
    {
        try
        {
            if (!_context.Product.Any())
            {
                for (int i=1;i<=10;i++)
                {

                    Faker faker = new();
                    Product item = new()
                    {
                        Name = faker.Commerce.Product(),
                        StatusId = faker.Random.Int(0, 1),
                        Stock = faker.Random.Decimal(1, 1000),
                        Description = faker.Lorem.Text(),
                        Price = Convert.ToDecimal(faker.Commerce.Price(10, 100)),
                        Discount = Convert.ToDecimal(faker.Commerce.Price(1, 50))
                    };
                    item.FinalPrice = (decimal)(item.Price - ((item.Discount / 100) * item.Price));
                    _context.Product.Add(item);
                    await _context.SaveChangesAsync();
                }
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }
}
