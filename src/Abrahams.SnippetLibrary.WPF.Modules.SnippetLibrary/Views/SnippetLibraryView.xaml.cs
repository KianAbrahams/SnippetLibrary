using Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.Views
{
    public partial class SnippetLibraryView : UserControl
    {
        public SnippetLibraryView(SnippetEditDialog snippetEditDialog, ISnippetLibraryViewModel snippetLibraryViewModel)
        {
            InitializeComponent();

            this.DataContext = snippetLibraryViewModel;

            snippetLibraryViewModel.ShowMsgBox += (sender, message) => MessageBox.Show(message);
            snippetLibraryViewModel.ShowAddDialog += (sender, message) => snippetEditDialog.ShowDialog();
        }
    }
}
