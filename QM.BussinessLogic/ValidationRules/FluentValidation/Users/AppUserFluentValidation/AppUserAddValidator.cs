using FluentValidation;
using QM.Common.ViewModels.Users.AppUserViewModels;
using System;

namespace QM.BussinessLogic.ValidationRules.FluentValidation.Users.AppUserFluentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddViewModel>
    {
        public AppUserAddValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı Adı boş geçilemez!");
            RuleFor(I => I.Password).NotNull().WithMessage("Parola alanı boş geçilemez!");
            RuleFor(I => I.Email).NotNull().WithMessage("E-mail alanı boş geçilemez!").EmailAddress().WithMessage("Geçersiz e-mail adresi!");
            RuleFor(I => I.FirstName).NotNull().WithMessage("Ad alanı boş geçilemez!");
            RuleFor(I => I.LastName).NotNull().WithMessage("Soyad alanı boş geçilemez!");
            RuleFor(I => I.Gender).NotNull().WithMessage("Cinsiyet alanı boş geçilemez!");
            RuleFor(I => I.DepartmentName).NotNull().WithMessage("Departman alanı boş geçilemez!");
        }
    }
}
