﻿using Abrahams.SnippetLibrary.DAL;
using Abrahams.SnippetLibrary.DomainModel;
using Abrahams.SnippetLibrary.DomainModel.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

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
        }

        public string Description
        {
            get => this.model.Description;
            set
            {
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

        private List<Language> languages;

        public List<Language> Languages
        {
            get
            {
                if (languages == null)
                    this.languages = this.languageRepository.GetLanguageList();

                return this.languages;
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

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
    }
}