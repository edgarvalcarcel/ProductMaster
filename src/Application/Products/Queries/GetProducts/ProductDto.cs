using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMaster.Domain.Entities;
using ProductMaster.Domain.Enums;

namespace ProductMaster.Application.Products.Queries.GetProducts;
public class ProductDto
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

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
