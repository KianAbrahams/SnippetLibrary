﻿using FluentValidation;

namespace Abrahams.SnippetLibrary.DomainModel.Validation
{
    internal abstract class ValidatorBase<TDomainEntity> : AbstractValidator<TDomainEntity>, IValidatorBase<TDomainEntity>
    {
        public const string RequiredErrorMessage = "Please enter a '{PropertyName}'.";
    }
}