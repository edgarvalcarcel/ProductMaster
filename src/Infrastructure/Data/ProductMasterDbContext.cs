using Microsoft.EntityFrameworkCore;
using ProductMaster.Application.Common.Interfaces;
using ProductMaster.Domain.Entities;

namespace ProductMaster.Infrastructure.Data;

public class ProductMasterDbContext : DbContext, IProductMasterDbContext
{
    public ProductMasterDbContext(DbContextOptions<ProductMasterDbContext> options) : base(options) { }
    public DbSet<Product> Product => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
