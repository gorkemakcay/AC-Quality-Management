using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface.WorkOrders;
using QM.Common.ViewModels.WorkOrders.ManuelScenarioViewModels;

namespace WebOS.Controllers.WorkOrder
{
    public class ManuelScenarioController : Controller
    {
        private readonly IManuelScenarioService _ManuelScenarioService;
        public ManuelScenarioController(IManuelScenarioService manuelScenarioService)
        {
            _ManuelScenarioService = manuelScenarioService;
        }

        public IActionResult GetManuelScenarioInfoJSON(int workOrderId)
        {
            var model = _ManuelScenarioService.GetAllManuelScenarioWithWorkOrder(workOrderId);
            var jSonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(jSonModel);
        }

        [HttpPost]
        public IActionResult AddManuelScenarioJSON(ManuelScenarioAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _ManuelScenarioService.AddManuelScenario(model);
                var jSonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(jSonModel);
            }
            return Json(null);
        }

        [HttpPost]
        public IActionResult UpdateManuelScenarioJSON(ManuelScenarioUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _ManuelScenarioService.UpdateManuelScenario(model);
                var jSonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(jSonModel);
            }
            return Json(null);
        }
    }
}