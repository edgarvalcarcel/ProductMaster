using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMaster.Application.Products.Commands.Update;
 
public record UpdateProductCommand : IRequest
{
    public int ProductId { get; set; }
    public required string Name { get; set; }
    public int StatusId { get; set; }
    public decimal Stock { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
}
