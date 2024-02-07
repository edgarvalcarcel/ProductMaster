namespace ProductMaster.Application.Products.Queries.Get;
public class ProductViewModel
{
    public IReadOnlyCollection<ProductDto> ProductsList { get; init; } = Array.Empty<ProductDto>();
}
