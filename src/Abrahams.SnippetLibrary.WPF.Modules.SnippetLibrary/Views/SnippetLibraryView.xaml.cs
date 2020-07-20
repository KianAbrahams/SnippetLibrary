using Abrahams.SnippetLibrary.DAL;
using Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.Views
{
    /// <summary>
    /// Interaction logic for SnippetLibraryView.xaml
    /// </summary>
    public partial class SnippetLibraryView : UserControl
    {
        private readonly SnippetEditDialog snippetEditDialog;
        private readonly ILanguageRepository languageRespository;

        public SnippetLibraryView(
            SnippetEditDialog snippetEditDialog,
            ISnippetLibraryViewModel snippetLibraryViewModel,
            ILanguageRepository languageRespository)
        {
            this.languageRespository = languageRespository;
            InitializeComponent();

            this.snippetEditDialog = snippetEditDialog;

            this.DataContext = snippetLibraryViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            snippetEditDialog.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var result = this.languageRespository.GetLanguageList();

            System.Diagnostics.Debugger.Break();
        }
    }
}
