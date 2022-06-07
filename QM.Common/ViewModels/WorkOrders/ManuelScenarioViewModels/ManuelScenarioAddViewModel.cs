using QM.Entities.Concrete.WorkOrders;
using System;

namespace QM.Common.ViewModels.WorkOrders.ManuelScenarioViewModels
{
    public class ManuelScenarioAddViewModel
    {
        public string Entry { get; set; }
        public string Explain { get; set; }
        public string manualControlStatus { get; set; }

        public int WorkOrderId { get; set; }
    }
}
