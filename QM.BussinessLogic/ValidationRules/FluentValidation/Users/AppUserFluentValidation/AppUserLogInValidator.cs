using FluentValidation;
using QM.Common.ViewModels.Users.AppUserViewModels;
using System;

namespace QM.BussinessLogic.ValidationRules.FluentValidation.Users.AppUserFluentValidation
{
    public class AppUserLogInValidator : AbstractValidator<AppUserLogInViewModel>
    {
        public AppUserLogInValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı adı gereklidir!");
            RuleFor(I => I.Password).NotNull().WithMessage("Şifre gereklidir!");
        }
    }
}
