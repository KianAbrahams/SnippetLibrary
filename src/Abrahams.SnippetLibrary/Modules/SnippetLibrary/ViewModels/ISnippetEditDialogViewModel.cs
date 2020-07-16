using Abrahams.SnippetLibrary.DomainModel;
using System.Collections.Generic;
using System.ComponentModel;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels
{
    public interface ISnippetEditDialogViewModel : IDataErrorInfo
    {
        List<Language> Languages { get; }
        void Save();
    }
}
