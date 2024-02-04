using Microsoft.EntityFrameworkCore;
using ProductMaster.Application.Common.Interfaces;
using ProductMaster.Domain.Events;
using ProductMaster.Infrastructure.Data;

namespace ProductMaster.Infrastructure.Persistence.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly ProductMasterDbContext _context;
    public ProductRepository(ProductMasterDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IQueryable<Product> GetAll() => _context.Product;
    public async Task<int> CreateProductAsync(Product product, CancellationToken cancellationToken)
    {
        product.AddDomainEvent(new ProductCreatedEvent(product));
        await _context.Product.AddAsync(product, cancellationToken);       
        await _context.SaveChangesAsync(cancellationToken);
        return product.ProductId;
    }

    public async Task<Product?> FindProductByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Product.FirstOrDefaultAsync(
            t => t.ProductId == id, cancellationToken);
    }

    public async Task UpdateProductAsync(Product product, CancellationToken cancellationToken)
    {
        _context.Product.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
