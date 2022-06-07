using QM.Entities.Concrete.WorkOrders;
using System;

namespace QM.Common.ViewModels.WorkOrders.ProductViewModels
{
    public class ProductListViewModel
    {
        public int Id { get; set; }
        public string ProductModel { get; set; }
        public string ProductCode { get; set; }
        public string ProductSerialCode { get; set; }
        public int WorkOrderId { get; set; }
        public WorkOrder WorkOrder { get; set; }
    }
}
