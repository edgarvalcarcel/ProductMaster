using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMaster.Application.Products.Commands.Create;
public class UpdateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(v => v.Name).NotEmpty().NotNull().WithMessage("'{PropertyName}' Must not be Empty.");
        RuleFor(v => v.StatusId).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1).WithMessage("'{PropertyName}' Must be 0 or 1");
        RuleFor(v => v.Stock).NotEmpty().NotNull().GreaterThan(0).WithMessage("'{PropertyName}' Must be greater than 0.");
        RuleFor(v => v.Description).NotEmpty().NotNull().WithMessage("'{PropertyName}' Must not be Empty.");
        RuleFor(v => v.Price).NotEmpty().NotNull().GreaterThan(0).WithMessage("'{PropertyName}' Must be greater than 0.");
    }
}
