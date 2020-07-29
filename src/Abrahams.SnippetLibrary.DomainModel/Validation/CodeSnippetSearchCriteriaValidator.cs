using FluentValidation;

namespace Abrahams.SnippetLibrary.DomainModel.Validation
{
    internal class CodeSnippetSearchCriteriaValidator : ValidatorBase<CodeSnippetSearchCriteria>, ICodeSnippetSearchCriteriaValidator
    {
        //TODO: add validation rule for description max length
        public CodeSnippetSearchCriteriaValidator()
        {
            this.RuleFor(x => x.Description).MaximumLength(CodeSnippet.DescriptionMaxLength);
        }
    }
}
