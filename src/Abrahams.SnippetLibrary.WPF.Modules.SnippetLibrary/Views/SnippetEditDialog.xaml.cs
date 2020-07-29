using Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels;
using System.Windows;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.Views
{
    public partial class SnippetEditDialog : Window
    {
        public SnippetEditDialog(ISnippetEditDialogViewModel snippetEditDialogViewModel)
        {
            this.InitializeComponent();

            snippetEditDialogViewModel.CloseDialog += (sender, e) => this.Hide();
            this.DataContext = snippetEditDialogViewModel;
            snippetEditDialogViewModel.ShowMsgBox += (sender, message) => 
            {
                MessageBox.Show(message);
            };
        }
    }
}