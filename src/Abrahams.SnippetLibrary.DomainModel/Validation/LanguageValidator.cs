using FluentValidation;

namespace Abrahams.SnippetLibrary.DomainModel.Validation
{
    internal class LanguageValidator : ValidatorBase<Language>, ILanguageValidator
    {
        public LanguageValidator()
        {
            this.RuleFor(x => x.Name).MaximumLength(Language.LanguageMaxLength).WithMessage($"The length of 'Language' must be {Language.LanguageMaxLength} characters or fewer. You entered {Language.LanguageMaxLength + 1} characters.");
            this.RuleFor(x => x.Name).NotEmpty().WithMessage(RequiredErrorMessage);
            this.RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
        }
    }
}