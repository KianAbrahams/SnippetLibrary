using FluentValidation;

namespace Abrahams.SnippetLibrary.DomainModel.Validation
{
    internal class CodeSnippetSearchCriteriaValidator : ValidatorBase<CodeSnippetSearchCriteria>, ICodeSnippetSearchCriteriaValidator
    {
        public CodeSnippetSearchCriteriaValidator()
        {
            this.RuleFor(x => x.Description).MaximumLength(CodeSnippet.DescriptionMaxLength);
        }
    }
}
