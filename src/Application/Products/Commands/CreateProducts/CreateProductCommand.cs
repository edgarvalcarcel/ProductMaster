using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMaster.Application.Products.Commands.CreateProducts;
public record CreateProductCommand : IRequest<int>
{
    public required string Name { get; init; }
    public int StatusId { get; init; }
    public decimal Stock { get; init; }
    public required string Description { get; init; }
    public decimal Price { get; init; }
}

