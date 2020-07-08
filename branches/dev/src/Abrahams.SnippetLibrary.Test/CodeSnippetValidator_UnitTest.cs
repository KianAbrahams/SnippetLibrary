using Abrahams.SnippetLibrary.DomainModel;
using Abrahams.SnippetLibrary.DomainModel.Validation;
using FluentAssertions;
using NUnit.Framework;

namespace Abrahams.SnippetLibrary.Test
{
    [TestFixture]
    public class CodeSnippetValidator_Should
    {
        /*
        * | CodeSnippet  |
          | ------------ |
          | Description  |
          | CodeSample   |
          | Language     |
          | Tags         |
       is valid if it's descripton, codesample, language and tags are not null/empty.
        */

        [Test]
        public void Return_IsValid_Given_a_valid_code_snippet()
        {
            // Arrange 
            var codeSnippet = CreateCodeSnippet("Test code snippet", "var num = 42");

            // Act 
            var result = new CodeSnippetValidator().Validate(codeSnippet);

            // Assert
            result.Should().NotBeNull();
            result.IsValid.Should().BeTrue();
        }

        [Test]
        public void Return_Validation_error_Given_a_code_snippet_with_a_zero_length_description()
        {
            // Arrange 
            var codeSnippet = CreateCodeSnippet(string.Empty, "var num = 42");

            // Act 
            var result = new CodeSnippetValidator().Validate(codeSnippet);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors[0].ErrorMessage.Should().Be("Please enter a 'Decription'.");
        }

        [Test]
        public void Return_Validation_error_Given_a_code_snippet_with_a_zero_length_code_sample()
        {
            // Arrange 
            var codeSnippet = CreateCodeSnippet("Test code snippet", string.Empty);

            // Act 
            var result = new CodeSnippetValidator().Validate(codeSnippet);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors[0].ErrorMessage.Should().Be("Please enter a 'Code Sample'.");
        }

        [Test][Ignore("WIP")]
        public void Return_Validation_error_Given_a_code_snippet_without_a_language()
        {
            // Arrange 
            var codeSnippet = CreateCodeSnippet("Test code snippet", "var num = 42");

            // Act 
            var result = new CodeSnippetValidator().Validate(codeSnippet);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors[0].ErrorMessage.Should().Be("Please select a 'language'.");
        }

        private static CodeSnippet CreateCodeSnippet(string description, string codesample) => new CodeSnippet
        {
            Decription = description,
            CodeSample = codesample,
            Language = new Language()
        };
    }
}