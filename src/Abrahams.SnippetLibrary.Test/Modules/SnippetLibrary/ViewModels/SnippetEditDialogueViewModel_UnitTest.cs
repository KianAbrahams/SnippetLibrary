using FluentAssertions;
using NUnit.Framework;
using Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels;
using Microsoft.Practices.Unity;
using Abrahams.SnippetLibrary.DAL;
using Abrahams.SnippetLibrary.DomainModel;
using Moq;
using System.Collections.Generic;

namespace Abrahams.SnippetLibrary.Test.Modules.SnippetLibrary.ViewModels
{
    [TestFixture]
    public class Given_we_are_adding_a_new_snippet : UnitTestBase
    {
        [Test]
        public void AListOfAvailableLanguages_ShouldBeProvidedToPickFrom()
        {
            // Arrange
            var languageList = new List<Language>() { new Language() { Id = 10, Name = "C#" } };

            var moqLanguageRepository = new Mock<ILanguageRepository>();
            moqLanguageRepository.Setup(x => x.GetLanguageList()).Returns(languageList);

            this.Container.RegisterInstance(moqLanguageRepository.Object);

            // Act
            var result = this.Container.Resolve<ISnippetEditDialogViewModel>().AvailableLanguages;

            // Assert
            result.Should().NotBeEmpty();
            result.Should().BeSameAs(languageList);
        }
    }
}
