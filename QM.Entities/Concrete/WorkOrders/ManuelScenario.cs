using QM.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.Entities.Concrete.WorkOrders
{
    public class ManuelScenario : ITable
    {
        public int Id { get; set; }
        public string Entry { get; set; }
        public string Explain { get; set; }
        public string manualControlStatus { get; set; }

        public int WorkOrderId { get; set; }
        public WorkOrder WorkOrder { get; set; }
    }
}
