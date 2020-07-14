using FluentValidation;

namespace Abrahams.SnippetLibrary.DomainModel.Validation
{
    public class LanguageValidator : ValidatorBase<Language>, ILanguageValidator
    {
        public LanguageValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty().WithMessage(RequiredErrorMessage);
            this.RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
        }
    }
}