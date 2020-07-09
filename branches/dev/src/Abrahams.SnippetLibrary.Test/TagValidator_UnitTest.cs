using Abrahams.SnippetLibrary.DomainModel;
using Abrahams.SnippetLibrary.DomainModel.Validation;
using FluentAssertions;
using NUnit.Framework;

namespace Abrahams.SnippetLibrary.Test
{
    public class TagValidator_Should
    {
        [Test]
        public void Return_IsValid_Given_a_valid_tag()
        {
            // Arrange 
            var tag = CreateTag("MVVM");

            // Act 
            var result = new TagValidator(new LanguageValidator()).Validate(tag);

            // Assert
            result.Should().NotBeNull();
            result.IsValid.Should().BeTrue();
        }

        public static Tag CreateTag(string Name) => new Tag
        {
            name = Name,
            Language = new Language() { Id = 0, Name = "C#" }
        };
    }
}
