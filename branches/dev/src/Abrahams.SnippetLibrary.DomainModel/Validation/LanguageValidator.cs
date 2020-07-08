using FluentValidation;

namespace Abrahams.SnippetLibrary.DomainModel.Validation
{
    public class LanguageValidator : ValidatorBase<Language>
    {
        public LanguageValidator()
        {
            const string requirederrormessage = "Please enter a '{PropertyName}'.";
            this.RuleFor(x => x.Name).NotEmpty().WithMessage(requirederrormessage);
            this.RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
        }
    }
}