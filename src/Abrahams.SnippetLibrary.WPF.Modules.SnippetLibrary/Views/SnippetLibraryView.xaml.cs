using Abrahams.SnippetLibrary.WPF.Modules.SnippetLibrary.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Abrahams.SnippetLibrary.WPF.Modules.SnippetLibrary.Views
{
    /// <summary>
    /// Interaction logic for SnippetLibraryView.xaml
    /// </summary>
    public partial class SnippetLibraryView : UserControl
    {
        private readonly SnippetEditDialog snippetEditDialog;
        private readonly SnippetLibraryViewModel snippetLibraryViewModel;

        public SnippetLibraryView(SnippetEditDialog snippetEditDialog, SnippetLibraryViewModel snippetLibraryViewModel)
        {
            this.snippetEditDialog = snippetEditDialog;
            this.snippetLibraryViewModel = snippetLibraryViewModel;

            InitializeComponent();
            this.DataContext = this.snippetLibraryViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            snippetEditDialog.ShowDialog();
        }
    }
}
