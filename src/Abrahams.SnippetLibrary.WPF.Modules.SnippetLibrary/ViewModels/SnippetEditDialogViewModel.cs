using Abrahams.SnippetLibrary.DAL;
using Abrahams.SnippetLibrary.DomainModel;
using Abrahams.SnippetLibrary.DomainModel.Validation;
using System;
using System.Collections.Generic;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels
{
    public class SnippetEditDialogViewModel : ISnippetEditDialogViewModel
    {
        private readonly ICodeSnippetValidator codeSnippetValidator;
        private readonly ILanguageValidator languageValidator;
        private readonly ITagValidator tagValidator;

        private readonly ILanguageRepository languageRepository;

        public SnippetEditDialogViewModel(
            ICodeSnippetValidator codeSnippetValidator, 
            ILanguageValidator languageValidator, 
            ITagValidator tagValidator,
            ILanguageRepository languageRepository)
        {
            this.tagValidator = tagValidator;
            this.languageValidator = languageValidator;
            this.codeSnippetValidator = codeSnippetValidator;

            this.languageRepository = languageRepository;
        }

        public CodeSnippet Model { get; private set; }

        private List<Language> languages;
        public List<Language> Languages
        {
            get 
            {
                if (languages == null)
                {
                    this.languages = this.languageRepository.GetLanguageList();
                }
                return this.languages;
            }
        }

        public bool IsValid { get; private set; }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool Validate()
        {
            // TODO: Update IsValid based on validation errors from domain validators.
            throw new NotImplementedException();
        }
    }
}
