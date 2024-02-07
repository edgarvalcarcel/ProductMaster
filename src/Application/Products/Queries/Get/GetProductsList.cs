using LazyCache;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductMaster.Application.Common.Interfaces;
using ProductMaster.Application.Products.Queries.Get;
using ProductMaster.Domain.Enums;
namespace ProductMaster.Application.Products.Queries.Get;

public record GetProductsListQuery : IRequest<ProductViewModel>;

public class GetProductsQueryHandler : IRequestHandler<GetProductsListQuery, ProductViewModel>
{
    private readonly IProductMasterDbContext _context;
    private readonly IMapper _mapper;
    private readonly IAppCache _cache;

    public GetProductsQueryHandler(IProductMasterDbContext context, IMapper mapper, IAppCache cache)
    {
        _context = context;
        _mapper = mapper;
        _cache = cache;
    }   

    public async Task<ProductViewModel> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
    {
        var prodList =  new ProductViewModel
        { 
            ProductsList = await _context.Product
                .AsNoTracking()
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                 
                .OrderBy(p=>p.ProductId)
                .ToListAsync(cancellationToken)
        };
        List<ProductDto> products  = [.. prodList.ProductsList];
        foreach (var item in products)
        {
            item.StatusName = Enum.GetName(typeof(Status), item.StatusId);                
        }
        return prodList;
    }
}
