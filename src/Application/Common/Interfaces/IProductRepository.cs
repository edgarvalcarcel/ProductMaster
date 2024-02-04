using ProductMaster.Domain.Entities;

namespace ProductMaster.Application.Common.Interfaces;
public interface IProductRepository
{
    IQueryable<Product> GetAll();
    Task<int> CreateProductAsync(Product product, CancellationToken cancellationToken);
    Task<Product?> FindProductByIdAsync(int id, CancellationToken cancellationToken);
    Task<bool> UpdateProductAsync(Product product, CancellationToken cancellationToken);
    Task<bool> DeleteProductAsync(Product product, CancellationToken cancellationToken);
}
