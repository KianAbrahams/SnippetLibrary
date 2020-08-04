using Abrahams.SnippetLibrary.DAL;
using Abrahams.SnippetLibrary.DomainModel;
using Abrahams.SnippetLibrary.DomainModel.Validation;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels
{
    internal class TagPickerDialogViewModel : ViewModelBase, ITagPickerDialogViewModel
    {
        private readonly ITagValidator tagValidator;

        private readonly ICodeSnippetRepository codeSnippetRepository;

        Tag tag = new Tag();

        public TagPickerDialogViewModel(ITagValidator tagValidator,
            ICodeSnippetRepository codeSnippetRepository)
        {
            this.codeSnippetRepository = codeSnippetRepository;
            this.tagValidator = tagValidator;

            this.Cancel = new DelegateCommand(() =>
            {
                this.CloseDialog?.Invoke(this, new EventArgs());
            });

            this.Save = new DelegateCommand(() => this.OnSave(this.tag));
        }

        public event EventHandler CloseDialog;
        public event EventHandler<string> ShowMsgBox;

        public ICommand Cancel { get; private set; }
        public ICommand Save { get; private set; }

        private string _search;
        public string Search
        {
            get => _search;
            set
            {
                // TODO: Call refresh validation. Also refresh validation on load
                if (_search == value)
                    return;

                _search = value;
                this.OnPropertyChanged();
            }
        }

        public List<Tag> TheList
        {
            get
            {
                this.OnPropertyChanged();
                return this.tag.theList;
            }
        }
        public List<Tag> AddToTheList
        {
            get
            {
                this.OnPropertyChanged();
                return this.tag.theList;
            }
            set
            {

                bool isContained = this.tag.theList.Any(x => value.Contains(x));

                if (isContained == true)
                {
                    return;
                }
                var listmax = this.TheList.Count;

                this.OnPropertyChanged();
            }
        }   

        private void OnSave(Tag tag)
        {
            var result = this.tagValidator.Validate(tag);

            if (result.IsValid == false)
            {
                // TODO: bind enabled save button to the validation result so this can never happen, replace with exception.
                this.ShowMsgBox.Invoke(this, Constants.SnippetEditDialogViewModel.SaveErrorMessage);
                return;
            }

            int tagId = this.codeSnippetRepository.SaveTag(tag);

            if (tagId != tag.TagId)
                tag.TagId = tagId;

            this.CloseDialog?.Invoke(this, new EventArgs());
        }
    }


}
