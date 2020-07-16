using Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels;
using System.Windows;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.Views
{
    public partial class SnippetEditDialog : Window
    {
        public SnippetEditDialog(SnippetEditDialogViewModel snippetEditDialogViewModel)
        {
            this.InitializeComponent();
            this.DataContext = snippetEditDialogViewModel;        
        }
    }
}