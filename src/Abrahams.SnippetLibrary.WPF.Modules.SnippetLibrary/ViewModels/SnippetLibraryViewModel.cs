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

        public SnippetLibraryViewModel(ICodeSnippetRepository codeSnippetRepository)
        {
            this.codeSnippetRepository = codeSnippetRepository;

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
    }
}
