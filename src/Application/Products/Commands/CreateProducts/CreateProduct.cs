using ProductMaster.Application.Common.Interfaces;
using ProductMaster.Application.Interfaces.Shared;
using ProductMaster.Domain.Entities;
using ProductMaster.Domain.Events;

namespace ProductMaster.Application.Products.Commands.CreateProducts;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductMasterDbContext _context;
    private readonly IAPIExternalServices _externalServices;

    public CreateProductCommandHandler(IProductMasterDbContext context, IAPIExternalServices externalServices)
    {
        _context = context;
        _externalServices = externalServices;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Product
        {            
            Name = request.Name,
            StatusId = request.StatusId,
            Stock = request.Stock,
            Description = request.Description,
            Price = request.Price
        }; 
        _context.Product.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        var discount = _externalServices.ConvertStringDecimal(_externalServices.GetDiscountExternal(entity.ProductId.ToString()));
        entity.Discount = discount;
        entity.FinalPrice = entity.Price - ((discount / 100) * entity.Price);

        _context.Product.Update(entity);
        entity.AddDomainEvent(new ProductCreatedEvent(entity));
        await _context.SaveChangesAsync(cancellationToken);

        return entity.ProductId;
    }
}
