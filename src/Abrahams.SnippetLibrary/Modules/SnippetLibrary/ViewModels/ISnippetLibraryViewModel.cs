using Abrahams.SnippetLibrary.DomainModel;
using System.Collections.Generic;
using System.Windows.Input;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels
{
    public interface ISnippetLibraryViewModel
    {
        IEnumerable<CodeSnippetSearchResult> SearchResults { get; }

        ICommand Search { get; }
    }
}
