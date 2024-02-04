using ProductMaster.Application.Common.Interfaces;
using ProductMaster.Domain.Entities;

namespace ProductMaster.Application.Products.Commands.DeleteProducts;
public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IAPIExternalServices _externalServices;
    private readonly IProductRepository _repository;

    public DeleteProductCommandHandler(IProductRepository repository, IAPIExternalServices externalServices)
    {
        _repository = repository;
        _externalServices = externalServices;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        Product? prodEntity = await _repository.FindProductByIdAsync(request.Id, cancellationToken);
        if (prodEntity != null)
        {
            await _repository.DeleteProductAsync(prodEntity, cancellationToken); 
        }
    }
}
