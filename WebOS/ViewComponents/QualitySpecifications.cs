using Microsoft.AspNetCore.Mvc;
using QM.BussinessLogic.Interface.WorkOrders;

namespace WebOS.ViewComponents
{
	public class QualitySpecifications : ViewComponent
    {
        private readonly IManuelScenarioService _ManuelScenarioService;
        public QualitySpecifications(IManuelScenarioService manuelScenarioService)
        {
            _ManuelScenarioService = manuelScenarioService;
        }

        public IViewComponentResult Invoke(int workOrderNo)
        {
            var model = _ManuelScenarioService.GetAllManuelScenarioWithWorkOrder(workOrderNo);
            return View("QualitySpecificationsList");
        }
    }
}