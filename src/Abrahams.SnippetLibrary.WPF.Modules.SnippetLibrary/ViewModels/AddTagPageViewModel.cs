using Microsoft.Practices.Prism.Commands;
using System;
using System.Windows.Input;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels
{
    internal class AddTagPageViewModel : ViewModelBase, IAddTagPageViewModel
    {
        public AddTagPageViewModel()
        {
            this.Cancel = new DelegateCommand(() =>
            {
                this.CloseDialog?.Invoke(this, new EventArgs());
            });
        }

        public event EventHandler CloseDialog;

        public ICommand Cancel { get; private set; }

        public string Search
        {
            get => this.Search;
            set
            {
                // TODO: Call refresh validation. Also refresh validation on load
                if (this.Search == value)
                    return;

                this.Search = value;
                this.OnPropertyChanged();
            }
        }


    }
}
