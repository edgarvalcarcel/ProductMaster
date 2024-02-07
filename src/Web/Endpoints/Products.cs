using ProductMaster.Application.Products.Commands.Create;
using ProductMaster.Application.Products.Commands.Delete;
using ProductMaster.Application.Products.Commands.Update;
using ProductMaster.Application.Products.Queries.Get;
using ProductMaster.Application.Products.Queries.GetById;

namespace ProductMaster.Web.Endpoints;

public class Products : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
        .RequireAuthorization()
        .MapGet(Get)
        .MapGet(GetById, "{id}")
        .MapPost(Create)
        .MapPut(Update, "{id}") 
        .MapDelete(Delete, "{id}");
    }
    public async Task<ProductViewModel> Get(ISender sender, [AsParameters] GetProductsListQuery query)
    {
        return await sender.Send(query);
    }
    public async Task<ProductVmDto> GetById(ISender sender, [AsParameters] GetProductQuery query)
    {
        return await sender.Send(query);
    }
    public async Task<int> Create(ISender sender, CreateProductCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> Update(ISender sender, int id, UpdateProductCommand command)
    {
        if (id <= 0) return Results.BadRequest();
        command.ProductId = id;
        await sender.Send(command);
        return Results.Ok();
    }
    public async Task<IResult> Delete(ISender sender, int id)
    {
        await sender.Send(new DeleteProductCommand(id));
        return Results.Ok();
    }
}
