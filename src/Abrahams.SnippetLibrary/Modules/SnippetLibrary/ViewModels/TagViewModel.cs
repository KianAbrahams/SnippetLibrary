using Abrahams.SnippetLibrary.DomainModel;
using System.ComponentModel;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels
{
    public class TagViewModel : PropertyChangedNotificationBase, INotifyPropertyChanged
    {
        public TagViewModel(Tag tag)
        {
            tagId = tag.TagId;
            name = tag.Name;
        }

        private int tagId;
        public int TagId
        {
            get => this.tagId;
            set
            {
                if (this.tagId == value)
                    return;

                this.tagId = value;
                this.OnPropertyChanged();
            }
        }

        private string name;
        public string Name
        {
            get => this.name;
            set
            {
                if (this.name == value)
                    return;

                this.name = value;
                this.OnPropertyChanged();
            }
        }

        private bool isSelected = false;
        public bool IsSelected
        {
            get => this.isSelected;
            set
            {
                if (this.isSelected == value)
                    return;

                this.isSelected = value;
                this.OnPropertyChanged();
            }
        }

        private bool isVisible = true;
        public bool IsVisible
        {
            get => this.isVisible;
            set
            {
                if (this.isVisible == value)
                    return;

                this.isVisible = value;
                this.OnPropertyChanged();
            }
        }
    }
}
