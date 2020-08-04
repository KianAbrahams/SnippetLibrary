using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels
{
    public abstract class PropertyChangedNotificationBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = null;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
