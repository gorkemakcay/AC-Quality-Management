using FluentValidation;
using QM.Common.ViewModels.Users.AppRoleViewModels;
using System;

namespace QM.BussinessLogic.ValidationRules.FluentValidation.Users.AppRoleFluentValidation
{
    public class AppRoleAddValidator : AbstractValidator<AppRoleAddViewModel>
    {
        public AppRoleAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Role name is required!");
        }
    }
}

