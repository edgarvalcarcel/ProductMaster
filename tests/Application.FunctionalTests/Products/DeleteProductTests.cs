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
        var command = new DeleteProductCommand(8);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteProduct()
    {
        var command = new CreateProductCommand
        {
            Name = "Product for Testing",
            StatusId = 1,
            Stock = 100,
            Description = "Descrption Product for Testing",
            Price = 156
        };
        var id = await SendAsync(command);

        await SendAsync(new DeleteProductCommand(id));

        var item = await FindAsync<Product>(id);

        item.Should().BeNull();
    }
}
