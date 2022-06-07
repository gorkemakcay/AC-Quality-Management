using FluentValidation;
using QM.Common.ViewModels.Users.AppRoleViewModels;
using System;

namespace QM.BussinessLogic.ValidationRules.FluentValidation.Users.AppRoleFluentValidation
{
    public class AppRoleUpdateValidator : AbstractValidator<AppRoleUpdateViewModel>
    {
        public AppRoleUpdateValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Role name is required!");
        }
    }
}
