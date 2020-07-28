using FluentValidation;

namespace Abrahams.SnippetLibrary.DomainModel.Validation
{
    internal class CodeSnippetValidator : ValidatorBase<CodeSnippet>, ICodeSnippetValidator
    {
        public CodeSnippetValidator(ILanguageValidator languageValidator, ITagValidator tagValidator)
        {
            this.RuleFor(x => x.Description).MaximumLength(CodeSnippet.DescriptionMaxLength);
            this.RuleFor(x => x.Description).NotEmpty().WithMessage(RequiredErrorMessage);
            this.RuleFor(x => x.CodeSample).NotEmpty().WithMessage(RequiredErrorMessage);
            this.RuleFor(x => x.Language).NotNull().WithMessage("Please select a '{PropertyName}'.");
            this.RuleFor(x => x.Language).SetValidator(languageValidator).When(x => x.Language != null, ApplyConditionTo.CurrentValidator);
            this.RuleForEach(x => x.Tags).SetValidator(tagValidator).When(x => x.Tags != null, ApplyConditionTo.CurrentValidator);
        }
    }
}