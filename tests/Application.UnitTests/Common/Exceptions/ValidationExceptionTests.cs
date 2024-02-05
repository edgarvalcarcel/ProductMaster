using ProductMaster.Application.Common.Exceptions;
using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;

namespace ProductMaster.Application.UnitTests.Common.Exceptions;

public class ValidationExceptionTests
{
    [Test]
    public void DefaultConstructorCreatesAnEmptyErrorDictionary()
    {
        var actual = new ValidationException().Errors;

        actual.Keys.Should().BeEquivalentTo(Array.Empty<string>());
    }

    [Test]
    public void SingleValidationFailureCreatesASingleElementErrorDictionary()
    {
        var failures = new List<ValidationFailure>
            {
                new ValidationFailure("1", "Product 1"),
            };

        var actual = new ValidationException(failures).Errors;

        actual.Keys.Should().BeEquivalentTo(new string[] { "1" });
        actual["1"].Should().BeEquivalentTo(new string[] { "Product 1" });
    }

    [Test]
    public void MulitpleValidationFailureForMultiplePropertiesCreatesAMultipleElementErrorDictionaryEachWithMultipleValues()
    {
        var failures = new List<ValidationFailure>
            {
                new ValidationFailure("1", "Product 1"),
                new ValidationFailure("1", "10.35"),
                new ValidationFailure("2", "Product 2"),
                  new ValidationFailure("2", "32.65"),
            };

        var actual = new ValidationException(failures).Errors;

        actual["1"].Should().BeEquivalentTo(new string[]
      {
               "Product 1",
               "10.35",
      });

        actual["2"].Should().BeEquivalentTo(new string[]
        {
               "Product 2",
                 "32.65"
        });
    }
}
