using ProductMaster.Application.Common.Interfaces;

namespace ProductMaster.Application.Products.Queries.GetById;
public record GetProductQuery(int Id) : IRequest<ProductVmDto>;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductVmDto>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;
    public GetProductQueryHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductVmDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var prodEntity = await _repository.FindProductByIdAsync(request.Id, cancellationToken);
        ProductVmDto item = _mapper.Map<ProductVmDto>(prodEntity);
        return item;
    }
}
