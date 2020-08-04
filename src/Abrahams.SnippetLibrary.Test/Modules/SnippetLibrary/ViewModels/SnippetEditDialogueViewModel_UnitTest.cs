using FluentAssertions;
using NUnit.Framework;
using Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels;
using Microsoft.Practices.Unity;
using Abrahams.SnippetLibrary.DAL;
using Abrahams.SnippetLibrary.DomainModel;
using Moq;
using System.Collections.Generic;
using Abrahams.SnippetLibrary.Modules.SnippetLibrary.Services;

namespace Abrahams.SnippetLibrary.Test.Modules.SnippetLibrary.ViewModels
{
    /* Given we are editing an existing code snippet, its data should appear when the form loads
     * 
     * For each field the data should be validated on a field by field basis and validation messages shown.
     */
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

    [TestFixture]
    public class Given_an_invalid_code_snippet : UnitTestBase
    {
        [Test]
        public void A_validation_message_should_be_shown_when_save_is_clicked()
        {
            // Arrange
            var isCloseDialogFired = false;
            var messageRecieved = string.Empty;

            var mockCodeSnippetRepository = new Mock<ICodeSnippetRepository>();
            this.Container.RegisterInstance(mockCodeSnippetRepository.Object);

            var snippetEditDialogViewModel = this.Container.Resolve<ISnippetEditDialogViewModel>();
            snippetEditDialogViewModel.ShowMsgBox += (sender, message) => messageRecieved = message;
            snippetEditDialogViewModel.CloseDialog += (sender, e) => isCloseDialogFired = true;

            // Act
            snippetEditDialogViewModel.Save.Execute(null);

            // Assert
            messageRecieved.Should().Be(Constants.SnippetEditDialogViewModel.SaveErrorMessage);
            isCloseDialogFired.Should().BeFalse();
            mockCodeSnippetRepository.Verify(x => x.SaveCodeSnippet(It.IsAny<CodeSnippet>()), Times.Never);
        }
    }

[TestFixture]
    public class Given_a_newly_created_valid_code_snippet : UnitTestBase
    {
        [Test]
        public void The_code_snippet_should_be_saved_and_the_screen_closes_when_save_is_clicked()
        {
            // Arrange
            var isCloseDialogFired = false;
            var messageRecieved = string.Empty;

            var csharp = new Language() { Id = 10, Name = "C#" };
            var languageList = new List<Language>() { csharp };

            var codeSnippet = new CodeSnippet();

            var moqLanguageRepository = new Mock<ILanguageRepository>();
            moqLanguageRepository.Setup(x => x.GetLanguageList()).Returns(languageList);
            this.Container.RegisterInstance(moqLanguageRepository.Object);

            var mockCodeSnippetRepository = new Mock<ICodeSnippetRepository>();
            this.Container.RegisterInstance(mockCodeSnippetRepository.Object);

            var snippetEditDialogViewModel = this.Container.Resolve<ISnippetEditDialogViewModel>();
            snippetEditDialogViewModel.ShowMsgBox += (sender, message) => messageRecieved = message;
            snippetEditDialogViewModel.CloseDialog += (sender, e) => isCloseDialogFired = true;

            this.Container.Resolve<ISnippetLibraryStateStore>().OnEditCodeSnippet(codeSnippet);

            // Act
            snippetEditDialogViewModel.Description = "Test code snippet";
            snippetEditDialogViewModel.CodeSample = "var num = 42";
            snippetEditDialogViewModel.Language = csharp;
            snippetEditDialogViewModel.Save.Execute(null);

            // Assert
            messageRecieved.Should().BeEmpty();
            isCloseDialogFired.Should().BeTrue();
            mockCodeSnippetRepository.Verify(x => x.SaveCodeSnippet(codeSnippet), Times.Once);
        }
    }

    [TestFixture]
    public class Given_an_existing_valid_code_snippet : UnitTestBase
    {
        [Test]
        public void The_code_snippet_should_be_saved_and_the_screen_closes_when_save_is_clicked()
        {
            // Arrange
            var isCloseDialogFired = false;
            var messageRecieved = string.Empty;

            var csharp = new Language() { Id = 10, Name = "C#" };
            var bob = new Language() { Id = 20, Name = "bob" };
            var languageList = new List<Language>() { csharp, bob };

            var codeSnippet = new CodeSnippet
            {
                CodeSnippetId = 10,
                Description = "Test code snippet",
                CodeSample = "var num = 42",
                Language = bob
            };

            var moqLanguageRepository = new Mock<ILanguageRepository>();
            moqLanguageRepository.Setup(x => x.GetLanguageList()).Returns(languageList);
            this.Container.RegisterInstance(moqLanguageRepository.Object);

            var mockCodeSnippetRepository = new Mock<ICodeSnippetRepository>();
            this.Container.RegisterInstance(mockCodeSnippetRepository.Object);

            var snippetEditDialogViewModel = this.Container.Resolve<ISnippetEditDialogViewModel>();
            snippetEditDialogViewModel.ShowMsgBox += (sender, message) => messageRecieved = message;
            snippetEditDialogViewModel.CloseDialog += (sender, e) => isCloseDialogFired = true;

            this.Container.Resolve<ISnippetLibraryStateStore>().OnEditCodeSnippet(codeSnippet);

            // Act
            snippetEditDialogViewModel.Language = csharp;
            snippetEditDialogViewModel.Save.Execute(null);

            // Assert
            messageRecieved.Should().BeEmpty();
            isCloseDialogFired.Should().BeTrue();
            mockCodeSnippetRepository.Verify(x => x.SaveCodeSnippet(codeSnippet), Times.Once);
        }
    }

    [TestFixture]
    public class Given_an_user_clicks_the_cancel_button : UnitTestBase
    {
        [Test]
        public void the_screen_show_close()
        {
            // Arrange
            var isCloseDialogFired = false;

            var snippetEditDialogViewModel = this.Container.Resolve<ISnippetEditDialogViewModel>();
            snippetEditDialogViewModel.CloseDialog += (sender, e) => isCloseDialogFired = true;

            // Act
            snippetEditDialogViewModel.Cancel.Execute(null);

            // Assert
            isCloseDialogFired.Should().BeTrue();
        }
    }
}