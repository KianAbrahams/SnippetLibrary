using FluentValidation;

namespace Abrahams.SnippetLibrary.DomainModel.Validation
{
    public class CodeSnippetValidator : FluentValidation.AbstractValidator<CodeSnippet>
    {
        public CodeSnippetValidator()
        {
            this.RuleFor(x => x.Decription).NotEmpty().NotNull();
        }
    }
}