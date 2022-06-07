using QM.Common.ViewModels.WorkOrders.WorkOrderViewModels;
using QM.Entities.Concrete.WorkOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.BussinessLogic.Interface.WorkOrders
{
    public interface IWorkOrderService : IGenericService<WorkOrder>
    {
        Task DeleteWorkOrder(int workOrderId);
        void AddWorkOrder(WorkOrderAddViewModel model);
        void UpdateWorkOrder(WorkOrderUpdateViewModel model);
        List<WorkOrderListViewModel> GetAllWorkOrders();
        WorkOrderListViewModel GetWorkOrderDetail(int workOrderId);
        WorkOrderUpdateViewModel GetWorkOrderInfo(int workOrderId);
        List<WorkOrderListViewModel> GetWorkOrder(int workOrderId);
        List<WorkOrderListViewModel> GetOwnedWorkOrderBll(int userId);
        List<WorkOrderListViewModel> GetMontageWorkOrderBll(int userId);
        List<WorkOrderListViewModel> GetWorkOrderCount(string status);
    }
}