using Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels;
using System.Windows;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.Views
{
    public partial class SnippetEditDialog : Window
    {
        public SnippetEditDialog(ISnippetEditDialogViewModel snippetEditDialogViewModel)
        {
            this.InitializeComponent();

            snippetEditDialogViewModel.CloseDialog += (sender, e) => this.Close();
            this.DataContext = snippetEditDialogViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}