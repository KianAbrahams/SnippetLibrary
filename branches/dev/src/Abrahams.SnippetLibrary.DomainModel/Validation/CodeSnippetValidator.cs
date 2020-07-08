using FluentValidation;

namespace Abrahams.SnippetLibrary.DomainModel.Validation
{
    public class CodeSnippetValidator : AbstractValidator<CodeSnippet>
    {
        public CodeSnippetValidator(LanguageValidator languageValidator)
        {
            const string requirederrormessage = "Please enter a '{PropertyName}'.";
            this.RuleFor(x => x.Decription).NotEmpty().WithMessage(requirederrormessage);
            this.RuleFor(x => x.CodeSample).NotEmpty().WithMessage(requirederrormessage);
            this.RuleFor(x => x.Language).NotNull().WithMessage("Please select a '{PropertyName}'.");
            this.RuleFor(x => x.Language).SetValidator(languageValidator).When(x => x.Language != null, ApplyConditionTo.CurrentValidator);
        }
    }
}