using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMaster.Application.Products.Commands.CreateProducts;
public record CreateProductCommand : IRequest<int>
{
    public int ProductId { get; init; }
    public required string Name { get; init; }
    public int StatusId { get; init; }
    public decimal Stock { get; init; }
    public string? Description { get; init; }
    public decimal? Price { get; init; }
    public decimal? Discount { get; init; }
    public decimal FinalPrice { get; init; }
}

