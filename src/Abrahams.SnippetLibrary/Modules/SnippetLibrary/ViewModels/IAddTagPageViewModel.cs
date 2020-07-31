using System;
using System.Windows.Input;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels
{
    public interface ITagPickerDialogViewModel
    {
         event EventHandler CloseDialog;
         event EventHandler<string> ShowMsgBox;


        ICommand Cancel { get; }
        ICommand Save { get; }
    }
}
