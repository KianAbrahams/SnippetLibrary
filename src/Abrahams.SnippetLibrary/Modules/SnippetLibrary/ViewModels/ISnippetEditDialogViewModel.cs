using Abrahams.SnippetLibrary.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels
{
    public interface ISnippetEditDialogViewModel : IDataErrorInfo
    {
        event EventHandler CloseDialog;

        ICommand Cancel { get; }
        ICommand Save { get; }

        string Description { get; set; }
        string CodeSample { get; set; }
        Language Language { get; set; }

        List<Language> AvailableLanguages { get; }
    }
}
