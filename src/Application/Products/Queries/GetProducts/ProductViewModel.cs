namespace ProductMaster.Application.Products.Queries.GetProducts;
public class ProductViewModel
{
    public IReadOnlyCollection<ProductDto> ProductsList { get; init; } = Array.Empty<ProductDto>();
}
