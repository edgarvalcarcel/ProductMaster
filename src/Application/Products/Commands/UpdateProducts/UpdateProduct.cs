using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMaster.Application.Common.Interfaces;

namespace ProductMaster.Application.Products.Commands.UpdateProducts;
 
public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductMasterDbContext _context;

    public UpdateProductCommandHandler(IProductMasterDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Product
            .FindAsync(new object[] { request.ProductId }, cancellationToken);

        Guard.Against.NotFound(request.ProductId, entity);

        entity.Name = request.Name;
        entity.Done = request.Done;

        /// Validation for Prices
        //entity.Discount = discount;
        //entity.FinalPrice = entity.Price - ((discount / 100) * entity.Price);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
