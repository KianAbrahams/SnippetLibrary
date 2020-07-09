using Abrahams.SnippetLibrary.DomainModel.Validation;
using FluentValidation;

namespace Abrahams.SnippetLibrary.Test
{
    public class TagValidator : ValidatorBase<Tag>
    {
        private LanguageValidator languageValidators;

        public TagValidator()
        {
            this.RuleFor(x => x.name).NotEmpty().WithMessage(RequiredErrorMessage);
        }

        public TagValidator(LanguageValidator languageValidators)
        {
            this.languageValidators = languageValidators;
        }
    }
}