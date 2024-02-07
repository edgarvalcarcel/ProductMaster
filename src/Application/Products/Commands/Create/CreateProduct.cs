using ProductMaster.Application.Common.Interfaces;
using ProductMaster.Domain.Entities;

namespace ProductMaster.Application.Products.Commands.Create;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IAPIExternalServices _externalServices;
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository, IAPIExternalServices externalServices)
    {
        _repository = repository;
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
        int productId  = await _repository.CreateProductAsync(entity, cancellationToken);

        var discount = _externalServices.ConvertStringDecimal(_externalServices.GetDiscountExternal(productId.ToString()));

        entity.Discount = discount;
        entity.FinalPrice = entity.Price - ((discount / 100) * entity.Price);

        await _repository.UpdateProductAsync(entity, cancellationToken);

        return entity.ProductId;
    }
}
