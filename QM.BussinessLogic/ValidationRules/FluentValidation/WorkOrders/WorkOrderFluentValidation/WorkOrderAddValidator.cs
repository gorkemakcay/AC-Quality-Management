using FluentValidation;
using QM.Common.ViewModels.WorkOrders.WorkOrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.BussinessLogic.ValidationRules.FluentValidation.WorkOrders.WorkOrderFluentValidation
{
    public class WorkOrderAddValidator : AbstractValidator<WorkOrderAddViewModel>
    {
        public WorkOrderAddValidator()
        {
            RuleFor(I => I.Company).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.WorkOrderNo).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.ProjectCode).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.SalesOrderCode).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.LotStatus).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.StationNo).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.StationName).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.TestNo).NotEmpty().WithMessage("Gerekli");
            RuleFor(I => I.DeliveryDate).NotEmpty().WithMessage("Gerekli");
        }
    }
}