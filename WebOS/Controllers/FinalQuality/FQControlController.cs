using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface.FinalQualities;
using QM.Common.ViewModels.FinalQualities.FQControlViewModels;

namespace WebOS.Controllers.FinalQuality
{
	public class FQControlController : Controller
    {
        private readonly IFQControlService _FQControlService;
        public FQControlController(IFQControlService fqControlService)
        {
            _FQControlService = fqControlService;
        }

        [HttpGet]
        public IActionResult GetAllFQControlsJSON(int qualityId)
        {
            var model = _FQControlService.GetAllFQControls(qualityId);
            var jSonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(jSonModel);
        }

        [HttpPost]
        public IActionResult AddFQControlJSON(FQControlAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _FQControlService.AddFQControl(model);
                var jSonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(jSonModel);
            }
            return Json(null);
        }

        [HttpPost]
        public IActionResult UpdateFQControlJSON(FQControlUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _FQControlService.UpdateFQControl(model);
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