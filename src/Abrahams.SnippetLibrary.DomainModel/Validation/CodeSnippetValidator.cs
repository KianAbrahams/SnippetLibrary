using FluentValidation;

namespace Abrahams.SnippetLibrary.DomainModel.Validation
{
    public class CodeSnippetValidator : ValidatorBase<CodeSnippet>, ICodeSnippetValidator
    {
        public CodeSnippetValidator(ILanguageValidator languageValidator, ITagValidator tagValidator)
        {
            // TODO: add validation logic for the largest size for description (255 characters).
            this.RuleFor(x => x.Description).NotEmpty().WithMessage(RequiredErrorMessage);
            // TODO: decide if we want to add validation logic for the largest size for Code sample (2 GBs).
            this.RuleFor(x => x.CodeSample).NotEmpty().WithMessage(RequiredErrorMessage);
            this.RuleFor(x => x.Language).NotNull().WithMessage("Please select a '{PropertyName}'.");
            this.RuleFor(x => x.Language).SetValidator(languageValidator).When(x => x.Language != null, ApplyConditionTo.CurrentValidator);
            this.RuleForEach(x => x.Tags).SetValidator(tagValidator).When(x => x.Tags != null, ApplyConditionTo.CurrentValidator);
        }
    }
}