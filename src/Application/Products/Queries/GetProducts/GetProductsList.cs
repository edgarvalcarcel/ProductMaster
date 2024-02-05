using ProductMaster.Application.Common.Interfaces;
using ProductMaster.Application.Products.Queries.GetProducts;
using ProductMaster.Domain.Enums;
namespace ProductMaster.Application.Products.Queries.GetProductsWithPagination;

public record GetProductsListQuery : IRequest<ProductViewModel>;

public class GetProductsQueryHandler : IRequestHandler<GetProductsListQuery, ProductViewModel>
{
    private readonly IProductMasterDbContext _context;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IProductMasterDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
