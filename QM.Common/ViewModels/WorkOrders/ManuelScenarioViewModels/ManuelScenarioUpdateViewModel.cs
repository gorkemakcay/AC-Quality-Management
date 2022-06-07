using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.Common.ViewModels.WorkOrders.ManuelScenarioViewModels
{
    public class ManuelScenarioUpdateViewModel
    {
        public int Id { get; set; }
        public string Entry { get; set; }
        public string Explain { get; set; }
        public string manualControlStatus { get; set; }

        public int WorkOrderId { get; set; }
    }
}
