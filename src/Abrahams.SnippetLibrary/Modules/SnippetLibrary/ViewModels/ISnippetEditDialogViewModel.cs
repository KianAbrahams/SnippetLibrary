using Abrahams.SnippetLibrary.DomainModel;
using System.Collections.Generic;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels
{
    public interface ISnippetEditDialogViewModel
    {
        CodeSnippet Model { get; }
        List<Language> Languages { get; }
        bool IsValid { get; }
        void Save();
    }
}
