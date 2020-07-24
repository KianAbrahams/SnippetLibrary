using Abrahams.SnippetLibrary.DomainModel;
using Abrahams.SnippetLibrary.DomainModel.Validation;
using FluentAssertions;
using NUnit.Framework;
using Microsoft.Practices.Unity;

namespace Abrahams.SnippetLibrary.Test.DomainModel.Validation
{
    [TestFixture]
    public class CodeSnippetValidator_Should : UnitTestBase
    {
        /*
        * | CodeSnippet  |
          | ------------ |
          | Description  |
          | CodeSample   |
          | Language     |
          | Tags         |
       is valid if it's description, CodeSample, language and tags are not null/empty.
        */

        [Test]
        public void Return_IsValid_Given_a_valid_code_snippet()
        {
            // Arrange 
            var codeSnippet = CreateCodeSnippet("Test code snippet", "var num = 42");

            // Act 
            var result = Container.Resolve<ICodeSnippetValidator>().Validate(codeSnippet);

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
            var result = Container.Resolve<ICodeSnippetValidator>().Validate(codeSnippet);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors[0].ErrorMessage.Should().Be("Please enter a 'Description'.");
        }

        [Test]
        public void Return_Validation_error_Given_a_codes_snippet_that_exceeds_the_maximum_size()
        {
            // Arrange 
            var codeSnippet = CreateCodeSnippet(new string('*', CodeSnippet.DescriptionMaxLength + 1), "var num = 42");

            // Act 
            var result = Container.Resolve<ICodeSnippetValidator>().Validate(codeSnippet);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors[0].ErrorMessage.Should().Be($"The length of 'Description' must be {CodeSnippet.DescriptionMaxLength} characters or fewer. You entered {CodeSnippet.DescriptionMaxLength + 1} characters.");
        }
        
        [Test]
        public void Return_Validation_error_Given_a_code_snippet_with_a_zero_length_code_sample()
        {
            // Arrange 
            var codeSnippet = CreateCodeSnippet("Test code snippet", string.Empty);

            // Act 
            var result = Container.Resolve<ICodeSnippetValidator>().Validate(codeSnippet);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors[0].ErrorMessage.Should().Be("Please enter a 'Code Sample'.");
        }

        [Test]
        public void Return_Validation_error_Given_a_code_snippet_without_a_language()
        {
            // Arrange 
            var codeSnippet = CreateCodeSnippet("Test code snippet", "var num = 42");
            codeSnippet.Language = null;

            // Act 
            var result = Container.Resolve<ICodeSnippetValidator>().Validate(codeSnippet);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors[0].ErrorMessage.Should().Be("Please select a 'Language'.");
        }

        [Test]
        public void Return_Validation_error_Given_a_code_snippet_with_invalid_tags()
        {
            // Arrange 
            var codeSnippet = CreateCodeSnippet("Test code snippet", "var num = 42");
            codeSnippet.Language = null;

            // Act 
            var result = Container.Resolve<ICodeSnippetValidator>().Validate(codeSnippet);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors[0].ErrorMessage.Should().Be("Please select a 'Language'.");
        }


        [Test]
        public void Return_Validation_error_Given_a_code_snippet_with_tags_that_arent_unique()
        {
            // TODO: Add a test to ensure tags are unique.
            // Arrange 
            //var codeSnippet = CreateCodeSnippet("Test code snippet", "var num = 42");

            // Act 
            //var result = Container.Resolve<ICodeSnippetValidator>().Validate(codeSnippet);

            //// Assert
            //result.IsValid.Should().BeFalse();
            //result.Errors.Should().HaveCount(1);
            //result.Errors[0].ErrorMessage.Should().Be("Please select a 'Language'.");
        }

        [Test]
        public void Return_Validation_error_Given_a_code_snippet_with_an_invalid_tag()
        {
            // Arrange 
            var codeSnippet = CreateCodeSnippet("Test code snippet", "var num = 42");
            codeSnippet.Tags.Add(new Tag());

            // Act 
            var result = Container.Resolve<ICodeSnippetValidator>().Validate(codeSnippet);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors[0].ErrorMessage.Should().Be("Please enter a 'Tag Name'.");
        }

        private static CodeSnippet CreateCodeSnippet(string description, string codesample) => new CodeSnippet
        {
            Description = description,
            CodeSample = codesample,
            Language = new Language() { Id = 0, Name="C#"}
        };
    }
}