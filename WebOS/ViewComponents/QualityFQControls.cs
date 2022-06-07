using Microsoft.AspNetCore.Mvc;
using QM.BussinessLogic.Interface.FinalQualities;

namespace WebOS.ViewComponents
{
	public class QualityFQControls : ViewComponent
    {
        private readonly IFQControlService _ControlService;
        public QualityFQControls(IFQControlService controlService)
        {
            _ControlService = controlService;
        }

        public IViewComponentResult Invoke(int qualityId)
        {
            ViewBag.QualityId = qualityId;
            var model = _ControlService.GetAllFQControls(qualityId);
            return View("QualityFQControlsList");
        }
    }
}