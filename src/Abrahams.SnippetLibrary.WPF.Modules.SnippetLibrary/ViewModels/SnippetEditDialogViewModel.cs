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

        public SnippetEditDialogViewModel(
            ICodeSnippetValidator codeSnippetValidator, 
            ILanguageValidator languageValidator, 
            ITagValidator tagValidator)
        {
            this.tagValidator = tagValidator;
            this.languageValidator = languageValidator;
            this.codeSnippetValidator = codeSnippetValidator;
        }

        public CodeSnippet Model { get; private set; }
        public List<Language> Languages { get; private set; }
        public bool IsValid 
        {
            get 
            {
                return this.Validate();
            } 
        } 
        
        public void Save()
        {
        }
        private bool Validate()
        {
            throw new NotImplementedException();
        }

    }
}
