using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMaster.Application.Products.Commands.Delete;
public record DeleteProductCommand(int Id) : IRequest;
