using FluentValidation;
using QM.Common.ViewModels.FinalQualities.FinalQualityViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.BussinessLogic.ValidationRules.FluentValidation.FinalQualities.FinalQualityFluentValidation
{
    public class FinalQualityAddValidator : AbstractValidator<FinalQualityAddViewModel>
    {
        public FinalQualityAddValidator()
        {
            RuleFor(I => I.Customer).NotNull().WithMessage("Gerekli");
            RuleFor(I => I.WorkOrderNo).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.MaterialName).NotNull().WithMessage("Gerekli");
            RuleFor(I => I.MaterialCode).NotNull().WithMessage("Gerekli");
            RuleFor(I => I.TechnicianName).NotNull().WithMessage("Gerekli");
            RuleFor(I => I.AcceptanceDate).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.LotStatus).NotNull().WithMessage("Gerekli");
            RuleFor(I => I.StationNo).NotNull().WithMessage("Gerekli");
            RuleFor(I => I.StationName).NotNull().WithMessage("Gerekli");
            RuleFor(I => I.TestNo).NotNull().WithMessage("Gerekli");
            RuleFor(I => I.DeliveryDate).NotEmpty().WithMessage("Gerekli");
        }
    }
}
