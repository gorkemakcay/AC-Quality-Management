using QM.Entities.Interface;
using System;

namespace QM.Entities.Concrete.WorkOrders
{
    public class Product : ITable
    {
        public int Id { get; set; }
        public string ProductModel { get; set; }
        public string ProductCode { get; set; }
        public string ProductSerialCode { get; set; }
        public int WorkOrderId { get; set; }
        public WorkOrder WorkOrder { get; set; }

    }
}
