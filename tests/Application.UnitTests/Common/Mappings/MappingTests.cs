using System.Reflection;
using System.Runtime.Serialization;
using AutoMapper;
using NUnit.Framework;
using ProductMaster.Application.Common.Interfaces;
using ProductMaster.Application.Products.Queries.Get;
using ProductMaster.Domain.Entities;

namespace ProductMaster.Application.UnitTests.Common.Mappings;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config => 
            config.AddMaps(Assembly.GetAssembly(typeof(IProductMasterDbContext))));

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    [TestCase(typeof(Product), typeof(ProductDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;
#pragma warning disable SYSLIB0050 // Type or member is obsolete
        return FormatterServices.GetUninitializedObject(type);
#pragma warning restore SYSLIB0050 // Type or member is obsolete
    }
}
