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
            var codeSnippet = new CodeSnippet();
            codeSnippet.Decription = "Test code snippet";

            var codeSnippetValidator = new CodeSnippetValidator();

            // Act 
            var result = codeSnippetValidator.Validate(codeSnippet);

            // Assert
            codeSnippet.Should().NotBeNull();
            codeSnippetValidator.Should().NotBeNull();
            result.Should().NotBeNull();
            result.IsValid.Should().BeTrue();
        }

        [Test]
        public void Return_Validation_error_Given_a_code_snippet_with_a_zero_length_description()
        {
            // Arrange 
            var codeSnippet = new CodeSnippet();
            codeSnippet.Decription = string.Empty;

            var codeSnippetValidator = new CodeSnippetValidator();

            // Act 
            var result = codeSnippetValidator.Validate(codeSnippet);

            // Assert
            codeSnippet.Should().NotBeNull();
            codeSnippetValidator.Should().NotBeNull();
            result.Should().NotBeNull();
            result.IsValid.Should().BeFalse();
        }
    }
}