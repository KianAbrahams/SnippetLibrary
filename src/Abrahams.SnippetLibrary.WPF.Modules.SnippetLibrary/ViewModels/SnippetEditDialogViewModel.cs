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
    public class SnippetEditDialogViewModel : ViewModelBase, ISnippetEditDialogViewModel
    {
        private readonly ICodeSnippetValidator codeSnippetValidator;

        private readonly ILanguageRepository languageRepository;
        private readonly ICodeSnippetRepository codeSnippetRepository;

        // TODO: this will need to be passed in from the parent screen.
        private CodeSnippet model = new CodeSnippet();
        
        public SnippetEditDialogViewModel(
            ICodeSnippetValidator codeSnippetValidator,
            ILanguageRepository languageRepository,
            ICodeSnippetRepository codeSnippetRepository)
        {
            this.codeSnippetRepository = codeSnippetRepository;
            this.codeSnippetValidator = codeSnippetValidator;
            this.languageRepository = languageRepository;

            this.Cancel = new DelegateCommand(() => 
            {
                this.CloseDialog?.Invoke(this, new EventArgs()); 
            });

            this.Save = new DelegateCommand(() => this.OnSave());
        }

        public event EventHandler CloseDialog;
        public event EventHandler<string> ShowMsgBox;

        public ICommand Cancel { get; private set; }
        public ICommand Save { get; private set; }

        public string Description
        { 
            get => this.model.Description;
            set
            {
                // TODO: Call refresh validation. Also refresh validation on load90-
                if (this.model.Description == value)
                    return;

                this.model.Description = value;
                this.OnPropertyChanged();
            }
        }

        public string CodeSample
        {
            get => this.model.CodeSample; 
            set
            {
                if (this.model.CodeSample == value)
                    return;

                this.model.CodeSample = value;
                this.OnPropertyChanged();
            }
        }

        public Language Language
        {
            get => this.model.Language;
            set
            {
                if (this.model.Language == value)
                    return;

                this.model.Language = value;
                this.OnPropertyChanged();
            }
        }

        private List<Language> availableLanguages;
        public List<Language> AvailableLanguages
        {
            get
            {
                if (availableLanguages == null)
                    this.availableLanguages = this.languageRepository.GetLanguageList();

                return this.availableLanguages;
            }
        }

        #region IDataErrorInfo
        public string this[string columnName]
        {
            get
            {
                var firstOrDefault = this.codeSnippetValidator.Validate(this.model).Errors.FirstOrDefault(x => x.PropertyName == columnName);

                if (firstOrDefault != null)
                    return firstOrDefault.ErrorMessage;

                return string.Empty;
            }
        }

        public string Error
        {
            get
            {
                var results = this.codeSnippetValidator.Validate(this.model);

                if (results != null && results.Errors.Any())
                    return string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());

                return string.Empty;
            }
        }
        #endregion
    
        private void OnSave()
        {
            var result = this.codeSnippetValidator.Validate(this.model);

            if (result.IsValid == false)
            {
                // TODO: bind enabled save button to the validation result so this can never happen, replace with exception.
                this.ShowMsgBox.Invoke(this, "Error saving, please check all boxes have been filled in.");
                return;
            }

            int codeSnippetId = this.codeSnippetRepository.SaveCodeSnippet(this.model);

            if (codeSnippetId != this.model.CodeSnippetId)
                this.model.CodeSnippetId = codeSnippetId;

            this.CloseDialog?.Invoke(this, new EventArgs());
        }
    
    }
}
