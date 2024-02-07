using ProductMaster.Domain.Entities;

namespace ProductMaster.Application.Products.Queries.GetById;
public class ProductVmDto
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public int StatusId { get; set; }
    public string? StatusName { get; set; }
    public decimal Stock { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal? Discount { get; set; }
    public decimal FinalPrice { get; set; }

    public static implicit operator ProductVmDto?(Product? v)
    {
        throw new NotImplementedException();
    }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductVmDto>();
        }
    }
}
