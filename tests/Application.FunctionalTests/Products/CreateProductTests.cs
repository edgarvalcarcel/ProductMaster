using FluentAssertions;
using NUnit.Framework;
using ProductMaster.Application.Common.Exceptions;
using ProductMaster.Application.Products.Commands.CreateProducts;
using ProductMaster.Domain.Entities;
namespace ProductMaster.Application.FunctionalTests.Products;
using static Testing;
public class CreateProductTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateProductCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }
    [Test]
    public async Task ShouldRequireSomeValidations()
    {
        var command = new CreateProductCommand
        {
            Name = "",
            StatusId=0,
            Stock=10,
            Description="",
            Price=1
        };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateProduct()
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
        var fakeProduct = await FindAsync<Product>(id);

        fakeProduct.Should().NotBeNull();
        fakeProduct!.Description.Should().Be(command.Description);
        fakeProduct!.Name.Should().Be(command.Name);
    }
}
