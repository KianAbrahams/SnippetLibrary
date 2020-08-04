using Abrahams.SnippetLibrary.DAL;
using Abrahams.SnippetLibrary.DomainModel;
using Abrahams.SnippetLibrary.DomainModel.Validation;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels
{
    internal class TagPickerDialogViewModel : ViewModelBase, ITagPickerDialogViewModel
    {
        private readonly ITagValidator tagValidator;
        private readonly ITagRepository tagRepository;

        public TagPickerDialogViewModel(ITagValidator tagValidator,
            ITagRepository tagRepository)
        {
            this.tagValidator = tagValidator;
            this.tagRepository = tagRepository;

            this.Cancel = new DelegateCommand(() =>
            {
                this.CloseDialog?.Invoke(this, new EventArgs());
            });

            this.Save = new DelegateCommand(() => this.OnSave());

            // TODO: Get parent code snippet from Snippet Library State Store.
            this.tagRepository.GetTags().ForEach(x => this.Tags.Add(new TagViewModel(x)));
            // TODO: Use parent code snippet to mark TagViewModel as IsSelected.
        }

        public event EventHandler CloseDialog;
        public event EventHandler<string> ShowMsgBox;

        public ICommand Cancel { get; }
        public ICommand Save { get; }
        public ICommand Add { get; }

        private string searchTerm;
        public string SearchTerm
        {
            get => this.searchTerm;
            set
            {
                // TODO: Call refresh validation. Also refresh validation on load
                if (this.searchTerm == value)
                    return;

                this.searchTerm = value;
                this.FilterTags(value);
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<TagViewModel> Tags { get; private set; } = new ObservableCollection<TagViewModel>();

        private void OnSave()
        {
            // TODO: Add saving by looping through the tags list and only saving the tags that haven't been saved.
            //var result = this.tagValidator.Validate(tag);

            //if (result.IsValid == false)
            //{
            //    // TODO: bind enabled save button to the validation result so this can never happen, replace with exception.
            //    this.ShowMsgBox.Invoke(this, Constants.SnippetEditDialogViewModel.SaveErrorMessage);
            //    return;
            //}

            //int tagId = this.codeSnippetRepository.SaveTag(tag);

            //if (tagId != tag.TagId)
            //    tag.TagId = tagId;

            this.CloseDialog?.Invoke(this, new EventArgs());
        }

        private void FilterTags(string value)
        {
            foreach (var tag in Tags)
            {
                if (tag.IsSelected)
                {
                    tag.IsVisible = true;
                    continue;
                }

                tag.IsVisible = tag.Name.Contains(value);
            }
        }

        //public List<Tag> TheList
        //{
        //    get
        //    {
        //        this.OnPropertyChanged();
        //        return this.tag.theList;
        //    }
        //}
        //public List<Tag> AddToTheList
        //{
        //    get
        //    {
        //        this.OnPropertyChanged();
        //        return this.tag.theList;
        //    }
        //    set
        //    {

        //        bool isContained = this.tag.theList.Any(x => value.Contains(x));

        //        if (isContained == true)
        //        {
        //            return;
        //        }
        //        var listmax = this.TheList.Count;

        //        this.OnPropertyChanged();
        //    }
        //}   
    }

}
