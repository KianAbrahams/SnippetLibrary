using Abrahams.SnippetLibrary.DomainModel;
using Abrahams.SnippetLibrary.DomainModel.Validation;
using FluentAssertions;
using NUnit.Framework;
using Microsoft.Practices.Unity;

namespace Abrahams.SnippetLibrary.Test
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

        // TODO: Add additional tests for failing validation due to null tag name
        public static Tag CreateTag(string name) => new Tag
        {
            Name = name
        };
    }
}
