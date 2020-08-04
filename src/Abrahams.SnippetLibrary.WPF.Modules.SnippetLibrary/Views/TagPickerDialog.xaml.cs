using System.Windows;
using Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.Views
{
    /// <summary>
    /// Interaction logic for AddTagPage.xaml
    /// </summary>
    public partial class TagPickerDialog : Window
    {
        public TagPickerDialog(ITagPickerDialogViewModel addTagPageViewModel)
        {
            this.InitializeComponent();

            this.DataContext = addTagPageViewModel;
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
