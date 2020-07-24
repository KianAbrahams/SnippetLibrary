using Abrahams.SnippetLibrary.DAL;
using Abrahams.SnippetLibrary.DomainModel;
using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels
{
    public class SnippetLibraryViewModel : ViewModelBase, ISnippetLibraryViewModel
    {
        private readonly ICodeSnippetRepository codeSnippetRepository;
        private readonly ILanguageRepository languageRepository;

        private CodeSnippet model = new CodeSnippet();

        public SnippetLibraryViewModel(ICodeSnippetRepository codeSnippetRepository,
            ILanguageRepository languageRepository)
        {
            this.codeSnippetRepository = codeSnippetRepository;
            this.languageRepository = languageRepository;

            this.Search = new DelegateCommand(() => SearchResults = this.codeSnippetRepository.SearchForCodeSnippets());
        }

        private IEnumerable<CodeSnippetSearchResult> searchResults = new List<CodeSnippetSearchResult>();
        public IEnumerable<CodeSnippetSearchResult> SearchResults
        {
            get => this.searchResults;
            set
            {
                this.searchResults = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand Search { get; private set; }


        public Language Language
        {
            get => this.model.Language;
            set
            {
                if (this.model.Language == value)
                    return;

                this.model.Language = value;
                this.OnPropertyChanged();
            }
        }

        private List<Language> availableLanguages;
        public List<Language> AvailableLanguages
        {
            get
            {
                if (availableLanguages == null)
                    this.availableLanguages = this.languageRepository.GetLanguageList();

                return this.availableLanguages;
            }
        }
    }
}
