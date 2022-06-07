using QM.Entities.Concrete.WorkOrders;
using System;

namespace QM.Common.ViewModels.WorkOrders.ManuelScenarioViewModels
{
    public class ManuelScenarioListViewModel
    {
        public int Id { get; set; }
        public string Entry { get; set; }
        public string Explain { get; set; }
        public string manualControlStatus { get; set; }

        public int WorkOrderId { get; set; }
        public WorkOrder WorkOrder { get; set; }
    }
}
