﻿using Abrahams.SnippetLibrary.DAL;
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

        // TODO: this will need to be passed in from the parent screen.
        private CodeSnippet model = new CodeSnippet();
        
        public SnippetEditDialogViewModel(
            ICodeSnippetValidator codeSnippetValidator,
            ILanguageRepository languageRepository)
        {
            this.codeSnippetValidator = codeSnippetValidator;
            this.languageRepository = languageRepository;

            this.Cancel = new DelegateCommand(() => 
            {
                this.CloseDialog?.Invoke(this, new EventArgs()); 
            });
            
            this.Save = new DelegateCommand(() => 
            {
                var result = codeSnippetValidator.Validate(model);

                if (result.IsValid == false)
                {
                    this.ShowMsgBox.Invoke(this, "Error saving, please check all boxes have been filled in.");
                    return;
                }
                // TODO: Save to the dbo.
            });
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
    
        private void RefreshValidation()
        {
            
        }
    
    }
}
