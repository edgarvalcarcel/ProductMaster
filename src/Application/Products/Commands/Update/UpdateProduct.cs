using ProductMaster.Application.Common.Interfaces;
using ProductMaster.Domain.Entities;

namespace ProductMaster.Application.Products.Commands.Update;
public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IAPIExternalServices _externalServices;
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository, IAPIExternalServices externalServices)
    {
        _repository = repository;
        _externalServices = externalServices;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product? prodEntity = await _repository.FindProductByIdAsync(request.ProductId, cancellationToken);

        Product entity = prodEntity ?? new Product();

        entity.Name = request.Name;
        entity.StatusId = request.StatusId;
        entity.Stock = request.Stock;
        entity.Description = request.Description;
        entity.Price = Convert.ToDecimal(request.Price);
        if (prodEntity != null) {
            var discount = _externalServices.ConvertStringDecimal(_externalServices.GetDiscountExternal(request.ProductId.ToString()));
            entity.Discount = discount;
            entity.FinalPrice = entity.Price - ((discount / 100) * entity.Price);
            await _repository.UpdateProductAsync(entity, cancellationToken);
        }
        else
        {
            int productId = await _repository.CreateProductAsync(entity, cancellationToken);
            var discount = _externalServices.ConvertStringDecimal(_externalServices.GetDiscountExternal(productId.ToString()));
            entity.Discount = discount;
            entity.FinalPrice = entity.Price - ((discount / 100) * entity.Price);
        }
    }
}
