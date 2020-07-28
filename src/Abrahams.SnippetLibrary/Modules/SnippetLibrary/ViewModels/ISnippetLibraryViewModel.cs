using Abrahams.SnippetLibrary.DomainModel;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels
{
    public interface ISnippetLibraryViewModel
    {
        IEnumerable<CodeSnippetSearchResult> SearchResults { get; }

        event EventHandler<string> ShowMsgBox;
        event EventHandler ShowAddDialog;

        ICommand Search { get; }
        ICommand AddCodeSnippet { get; }
        ICommand EditCodeSnippet { get; }
    }
}
