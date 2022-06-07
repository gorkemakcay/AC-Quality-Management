using Microsoft.AspNetCore.Mvc;
using QM.BussinessLogic.Interface.WorkOrders;

namespace WebOS.ViewComponents
{
    public class GetWorkOrders : ViewComponent
    {
        private readonly IWorkOrderService _WorkOrderService;

        public GetWorkOrders(IWorkOrderService workOrderService)
        {
            _WorkOrderService = workOrderService;
        }

        public IViewComponentResult Invoke()
        {
            var model = _WorkOrderService.GetAllWorkOrders();
            return View("GetAllWorkOrders", model);
        }
    }
}
