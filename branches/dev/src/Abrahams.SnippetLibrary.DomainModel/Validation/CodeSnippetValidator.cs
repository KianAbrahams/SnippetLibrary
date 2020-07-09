using FluentValidation;

namespace Abrahams.SnippetLibrary.DomainModel.Validation
{
    public class CodeSnippetValidator : ValidatorBase<CodeSnippet>
    {
        public CodeSnippetValidator(LanguageValidator languageValidator)
        {
            this.RuleFor(x => x.Description).NotEmpty().WithMessage(RequiredErrorMessage);
            this.RuleFor(x => x.CodeSample).NotEmpty().WithMessage(RequiredErrorMessage);
            this.RuleFor(x => x.Language).NotNull().WithMessage("Please select a '{PropertyName}'.");
            this.RuleFor(x => x.Language).SetValidator(languageValidator).When(x => x.Language != null, ApplyConditionTo.CurrentValidator);
        }
    }
}