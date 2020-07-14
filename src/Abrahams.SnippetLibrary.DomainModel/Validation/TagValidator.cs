using FluentValidation;

namespace Abrahams.SnippetLibrary.DomainModel.Validation
{
    public class TagValidator : ValidatorBase<Tag>, ITagValidator
    {
        public TagValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty().WithName($"{nameof(Tag)} {nameof(Tag.Name)}").WithMessage(RequiredErrorMessage);
        }
    }
}