using Abrahams.SnippetLibrary.DomainModel.Validation;
using FluentValidation;

namespace Abrahams.SnippetLibrary.Test
{
    public class TagValidator : ValidatorBase<Tag>
    {
        public TagValidator()
        {
            this.RuleFor(x => x.name).NotEmpty().WithMessage(RequiredErrorMessage);
        }
    }
}