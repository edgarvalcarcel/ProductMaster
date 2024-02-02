using ProductMaster.Application.Common.Interfaces;

namespace ProductMaster.Application.Products.Commands.DeleteProducts;
public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductMasterDbContext _context;

    public DeleteProductCommandHandler(IProductMasterDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Product
            .FindAsync(new object[] { request.Id });

        Guard.Against.NotFound(request.Id, entity);

        _context.Product.Remove(entity);

        //entity.AddDomainEvent(new ProductDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
