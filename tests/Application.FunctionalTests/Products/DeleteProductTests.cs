using Ardalis.GuardClauses;
using Bogus;
using Bogus.DataSets;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProductMaster.Application.Products.Commands.CreateProducts;
using ProductMaster.Application.Products.Commands.DeleteProducts;
using ProductMaster.Domain.Entities;
namespace ProductMaster.Application.FunctionalTests.Products;
using static Testing;
public class DeleteProductTests : BaseTestFixture
{
    [Test]
    public async Task ShouldDeleteProduct()
    {
        Faker faker = new();
        var command = new CreateProductCommand
        {
            Name = faker.Commerce.Product(),
            StatusId = faker.Random.Int(0, 1),
            Stock = faker.Random.Decimal(1, 1000),
            Description = faker.Lorem.Text(),
            Price = Convert.ToDecimal(faker.Commerce.Price(10, 100)) 
        };
        var id = await SendAsync(command);

        await SendAsync(new DeleteProductCommand(id));

        var item = await FindAsync<Product>(id);

        item.Should().BeNull();
    }
}
