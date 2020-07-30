using Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.Views
{
    /// <summary>
    /// Interaction logic for AddTagPage.xaml
    /// </summary>
    public partial class TagPickerDialog : Window
    {
        public TagPickerDialog(IAddTagPageViewModel addTagPageViewModel)
        {
            this.InitializeComponent();

            this.DataContext = addTagPageViewModel;
        }
    }
}
