using FluentValidation;

namespace Abrahams.SnippetLibrary.DomainModel.Validation
{
    internal class TagValidator : ValidatorBase<Tag>, ITagValidator
    {
        public TagValidator()
        {
            this.RuleFor(x => x.Name).MaximumLength(Tag.TagMaxLength).WithMessage($"The length of 'Tag' must be {Tag.TagMaxLength} characters or fewer. You entered {Tag.TagMaxLength + 1} characters.");
            this.RuleFor(x => x.Name).NotEmpty().WithName($"{nameof(Tag)} {nameof(Tag.Name)}").WithMessage(RequiredErrorMessage);
        }
    }
}