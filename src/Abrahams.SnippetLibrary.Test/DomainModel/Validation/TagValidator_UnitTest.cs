using Abrahams.SnippetLibrary.DomainModel;
using Abrahams.SnippetLibrary.DomainModel.Validation;
using FluentAssertions;
using NUnit.Framework;
using Microsoft.Practices.Unity;

namespace Abrahams.SnippetLibrary.Test.DomainModel.Validation
{
    [TestFixture]
    public class TagValidator_Should : UnitTestBase
    {
        [Test]
        public void Return_IsValid_Given_a_valid_tag()
        {
            // Arrange 
            var tag = CreateTag("MVVM");

            // Act 
            var result = Container.Resolve<ITagValidator>().Validate(tag);

            // Assert
            result.Should().NotBeNull();
            result.IsValid.Should().BeTrue();
        }

        [Test]
        public void Return_Validation_error_Given_a_tag_with_a_zero_length_name()
        {
            // Arrange 
            var tag = CreateTag(string.Empty);

            // Act 
            var result = Container.Resolve<ITagValidator>().Validate(tag);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors[0].ErrorMessage.Should().Be("Please enter a 'Tag Name'.");
        }

        public static Tag CreateTag(string name) => new Tag
        {
            Name = name
        };
    }
}
