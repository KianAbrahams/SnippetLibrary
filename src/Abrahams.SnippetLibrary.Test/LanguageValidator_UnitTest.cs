﻿using Abrahams.SnippetLibrary.DomainModel;
using Abrahams.SnippetLibrary.DomainModel.Validation;
using FluentAssertions;
using NUnit.Framework;
using Microsoft.Practices.Unity;

namespace Abrahams.SnippetLibrary.Test
{
    [TestFixture]
    public class LanguageValidator_Should : UnitTestBase
    {
        [Test]
        public void Return_IsValid_Given_a_valid_language()
        {
            // Arrange 
            var language = CreateLanguage(0, "C#");

            // Act 
            var result = Container.Resolve<ILanguageValidator>().Validate(language);

            // Assert
            result.Should().NotBeNull();
            result.IsValid.Should().BeTrue();
        }

        [Test]
        public void Return_Validation_error_Given_a_language_without_a_name()
        {
            // Arrange 
            var language = CreateLanguage(0, string.Empty);

            // Act 
            var result = Container.Resolve<ILanguageValidator>().Validate(language);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors[0].ErrorMessage.Should().Be("Please enter a 'Name'.");
        }

        [Test]
        public void Return_Validation_error_Given_a_language_with_a_negative_id()
        {
            // Arrange 
            var language = CreateLanguage(-1, "C#");

            // Act 
            var result = Container.Resolve<ILanguageValidator>().Validate(language);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors[0].ErrorMessage.Should().Be("'Id' must be greater than or equal to '0'.");
        }

        private static Language CreateLanguage(int id, string name) => new Language
        {
            Id = id,
            Name = name
        };
    }
}