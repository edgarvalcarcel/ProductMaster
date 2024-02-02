using ProductMaster.Domain.Entities;

namespace ProductMaster.Application.Common.Interfaces;

public interface IProductMasterDbContext
{
    DbSet<Product> Product { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
