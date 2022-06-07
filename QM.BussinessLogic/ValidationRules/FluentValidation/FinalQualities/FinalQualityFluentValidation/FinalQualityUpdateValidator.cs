using FluentValidation;
using QM.Common.ViewModels.FinalQualities.FinalQualityViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.BussinessLogic.ValidationRules.FluentValidation.FinalQualities.FinalQualityFluentValidation
{
    public class FinalQualityUpdateValidator : AbstractValidator<FinalQualityUpdateViewModel>
    {
        public FinalQualityUpdateValidator()
        {
            RuleFor(I => I.Customer).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.WorkOrderNo).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.MaterialName).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.MaterialCode).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.TechnicianName).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.AcceptanceDate).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.LotStatus).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.StationNo).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.StationName).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.TestNo).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.DeliveryDate).NotEmpty().WithMessage("Gerekli");
        }
    }
}
