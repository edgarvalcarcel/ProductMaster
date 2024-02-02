using ProductMaster.Application.Common.Interfaces;
using ProductMaster.Domain.Entities;
using ProductMaster.Domain.Events;

namespace ProductMaster.Application.Products.Commands.CreateProducts;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductMasterDbContext _context;

    public CreateProductCommandHandler(IProductMasterDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Product
        {
            ProductId = request.ProductId,
            Name = request.Name,
            StatusId = request.StatusId,
            Stock = request.Stock,
            Description = request.Description,
            Price = request.Price,
            Discount = request.Discount,
            FinalPrice = request.FinalPrice,
        };
    entity.AddDomainEvent(new ProductCreatedEvent(entity));

        _context.Product.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.ProductId;
    }
}
