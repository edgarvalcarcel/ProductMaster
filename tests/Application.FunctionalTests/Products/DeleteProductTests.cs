namespace ProductMaster.Application.FunctionalTests.Products;

using Ardalis.GuardClauses;
using FluentAssertions;
using NUnit.Framework;
using ProductMaster.Application.Products.Commands.CreateProducts;
using ProductMaster.Application.Products.Commands.DeleteProducts;
using ProductMaster.Domain.Entities;
using static Testing;

public class DeleteProductTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidProductId()
    {
        var command = new DeleteProductCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteProduct()
    {
        var command = new CreateProductCommand
        {
            Name = "",
            StatusId = 0,
            Stock = 10,
            Description = "",
            Price = 1
        };
        var id = await SendAsync(command);

        await SendAsync(new DeleteProductCommand(id));

        var item = await FindAsync<Product>(id);

        item.Should().BeNull();
    }
}
