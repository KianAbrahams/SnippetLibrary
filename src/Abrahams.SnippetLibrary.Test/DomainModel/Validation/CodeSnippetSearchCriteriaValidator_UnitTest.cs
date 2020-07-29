using Abrahams.SnippetLibrary.DomainModel;
using Abrahams.SnippetLibrary.DomainModel.Validation;
using FluentAssertions;
using NUnit.Framework;
using Microsoft.Practices.Unity;

namespace Abrahams.SnippetLibrary.Test.DomainModel.Validation
{
    [TestFixture]
    public class CodeSnippetSearchCriteriaValidator_Should : UnitTestBase
    {
        [Test]
        public void Return_IsValid_Given_a_valid_code_snippet_Search_Criteria()
        {
            // Arrange 
            var codeSnippetSearchCriteria = CreateCodeSnippetSearchCriteria("Test code snippet", "var num = 42");

            // Act 
            var result = Container.Resolve<ICodeSnippetSearchCriteriaValidator>().Validate(codeSnippetSearchCriteria);

            // Assert
            result.Should().NotBeNull();
            result.IsValid.Should().BeTrue();
        }

        [Test]
        public void Return_IsInValid_Given_a_Invalid_code_snippet_Search_Criteria_description()
        {
            // Arrange 
            var codeSnippetSearchCriteria = CreateCodeSnippetSearchCriteria(new string('*', CodeSnippetSearchCriteria.DescriptionMaxLength + 1), "var num = 42");

            // Act 
            var result = Container.Resolve<ICodeSnippetSearchCriteriaValidator>().Validate(codeSnippetSearchCriteria);

            // Assert
            result.Should().NotBeNull();
            result.IsValid.Should().BeFalse();
        }

        private static CodeSnippetSearchCriteria CreateCodeSnippetSearchCriteria(string description, string codesample) => new CodeSnippetSearchCriteria
        {
            Description = description,
            CodeSample = codesample,
            Language = new Language() { Id = 0, Name = "C#" }
        };
    }
}
