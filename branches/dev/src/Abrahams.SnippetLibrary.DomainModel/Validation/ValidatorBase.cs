﻿using FluentValidation;

namespace Abrahams.SnippetLibrary.DomainModel.Validation
{
    public abstract class ValidatorBase<TDomainEntity> : AbstractValidator<TDomainEntity>
    {
        public const string RequiredErrorMessage = "Please enter a '{PropertyName}'.";
    }
}