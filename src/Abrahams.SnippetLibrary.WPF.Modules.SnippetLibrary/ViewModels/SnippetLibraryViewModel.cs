using Abrahams.SnippetLibrary.DAL;
using Abrahams.SnippetLibrary.DomainModel;
using Abrahams.SnippetLibrary.DomainModel.Validation;
using Abrahams.SnippetLibrary.Modules.SnippetLibrary.Services;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels
{
    internal class SnippetLibraryViewModel : ViewModelBase, ISnippetLibraryViewModel
    {
        private readonly ICodeSnippetSearchCriteriaValidator codeSnippetSearchCriteriaValidator;

        private readonly ICodeSnippetRepository codeSnippetRepository;
        private readonly ILanguageRepository languageRepository;

        private readonly ISnippetLibraryStateStore snippetLibraryStateStore;

        private CodeSnippet model = new CodeSnippet();
        private CodeSnippetSearchCriteria searchCriteria = new CodeSnippetSearchCriteria();

        public SnippetLibraryViewModel(
            ICodeSnippetSearchCriteriaValidator codeSnippetSearchCriteriaValidator,
            ICodeSnippetRepository codeSnippetRepository,
            ILanguageRepository languageRepository,
            ISnippetLibraryStateStore snippetLibraryStateStore)
        {
            this.codeSnippetRepository = codeSnippetRepository;
            this.languageRepository = languageRepository;
            this.codeSnippetSearchCriteriaValidator = codeSnippetSearchCriteriaValidator;
            this.snippetLibraryStateStore = snippetLibraryStateStore;

            this.Search = new DelegateCommand(this.OnSearch);
            this.AddCodeSnippet = new DelegateCommand(this.OnAddCodeSnippet);
            this.EditCodeSnippet = new DelegateCommand(this.OnEditCodeSnippet);
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
        public ICommand AddCodeSnippet { get; private set; }
        public ICommand EditCodeSnippet { get; private set; }

        public event EventHandler<string> ShowMsgBox;
        public event EventHandler ShowAddDialog;

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

        private void OnSearch()
        {
            var result = this.codeSnippetSearchCriteriaValidator.Validate(this.searchCriteria);

            if (result.IsValid == false)
            {
                // TODO: bind enabled save button to the validation result so this can never happen, replace with exception.
                this.ShowMsgBox.Invoke(this, "Error searching, please check at least one search term has been filled in.");
                return;
            }

            this.SearchResults = this.codeSnippetRepository.SearchForCodeSnippets(this.searchCriteria);
        }

        private void OnAddCodeSnippet()
        {
            this.snippetLibraryStateStore.OnEditCodeSnippet(new CodeSnippet());
            this.ShowAddDialog?.Invoke(this, new EventArgs());
        }

        private void OnEditCodeSnippet()
        {
            // TODO: Send edit message passing the selected code snippet as the argument.
            //this.snippetLibraryStateStore.OnEditCodeSnippet());
            this.ShowAddDialog?.Invoke(this, new EventArgs());
        }
    }
}
