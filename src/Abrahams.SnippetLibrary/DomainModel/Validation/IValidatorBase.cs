using FluentValidation;

namespace Abrahams.SnippetLibrary.DomainModel.Validation
{
    public interface IValidatorBase<TDomainEntity> : IValidator<TDomainEntity>
    {
    }
}