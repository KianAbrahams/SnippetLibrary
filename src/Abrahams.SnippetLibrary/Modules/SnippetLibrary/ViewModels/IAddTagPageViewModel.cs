using System;
using System.Windows.Input;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels
{
    public interface IAddTagPageViewModel
    {
         event EventHandler CloseDialog;

         ICommand Cancel { get; }
    }
}
