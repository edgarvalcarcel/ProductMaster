
using ProductMaster.Application.Products.Commands.CreateProducts;
using ProductMaster.Application.Products.Commands.DeleteProducts;
using ProductMaster.Application.Products.Commands.UpdateProducts;
using ProductMaster.Domain.Entities;

namespace ProductMaster.Web.Endpoints;

public class Products : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
        .RequireAuthorization()
        .MapPost(CreateProduct)
        .MapPut(UpdateProduct, "{id}") 
        .MapDelete(DeleteProduct, "{id}");
    }

    public async Task<int> CreateProduct(ISender sender, CreateProductCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateProduct(ISender sender, int id, UpdateProductCommand command)
    {
        if (id <= 0) return Results.BadRequest();
        command.ProductId = id;
        await sender.Send(command);
        return Results.Ok();
    }
    public async Task<IResult> DeleteProduct(ISender sender, int id)
    {
        await sender.Send(new DeleteProductCommand(id));
        return Results.Ok();
    }
}
